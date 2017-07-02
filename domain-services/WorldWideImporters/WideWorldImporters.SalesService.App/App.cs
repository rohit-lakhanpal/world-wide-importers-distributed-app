using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WideWorldImporters.Common.Lib.Common;
using WideWorldImporters.Common.Lib.Dto.Base;
using WideWorldImporters.SalesService.App.Models;

namespace WideWorldImporters.SalesService.App
{
    /// <summary>
    /// 
    /// </summary>
    public class App
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The logger factory
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;
        /// <summary>
        /// The configuration
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        private AppSettings _config { get { return _configOptions.Value; } }
        /// <summary>
        /// The configuration options
        /// </summary>
        private readonly IOptions<AppSettings> _configOptions;
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;
        /// <summary>
        /// The application namespace
        /// </summary>
        private readonly string _appNamespace;

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public App(IOptions<AppSettings> config, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            _configOptions = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<App>();
            _appNamespace = Assembly.GetEntryAssembly().GetName().Name;
            _serviceProvider = serviceProvider;
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            //TaskFactory tf = 
            // initiate each listener
            // todo: later initiate x number of listeners based on config values
            GetTypesInNamespace(Assembly.GetEntryAssembly(), "WideWorldImporters.SalesService.App.Workers").ToList().ForEach(type =>
            {
                AddEventListeners(type);
            });            

            // keep running 
            // todo: refactor
            while (true)
            {
                System.Console.ReadKey();
            }
        }

        /// <summary>
        /// Adds the event echo listeners.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="workers">The workers.</param>
        public void AddEventEchoListeners(Type type, int workers = 1)
        {
            for (int i = 0; i < 3; i++)
            {
                Task.Run(() =>
                {
                    var wkrId = Guid.NewGuid().ToString();
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: "wideworldimporters.salesservice.app.orderinfo.request", durable: false, exclusive: false, autoDelete: false, arguments: null);
                        channel.BasicQos(0, 1, false);
                        var consumer = new EventingBasicConsumer(channel);
                        channel.BasicConsume(queue: "wideworldimporters.salesservice.app.orderinfo.request", noAck: false, consumer: consumer);
                        Console.WriteLine($" [{wkrId}] Awaiting RPC requests");

                        consumer.Received += (model, ea) =>
                        {
                            string response = null;

                            var body = ea.Body;
                            var props = ea.BasicProperties;
                            var replyProps = channel.CreateBasicProperties();
                            replyProps.CorrelationId = props.CorrelationId;

                            try
                            {
                                var message = Encoding.UTF8.GetString(body);
                                //int n = int.Parse(message);
                                var ms = $">> {wkrId} got {message}";
                                Console.WriteLine(ms);
                                response = ms; // fib(n).ToString();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(" [.] " + e.Message);
                                response = "";
                            }
                            finally
                            {
                                var responseBytes = Encoding.UTF8.GetBytes(response);
                                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                            }
                        };

                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                    }
                });
            }

        }

        /// <summary>
        /// Adds the event listeners.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="workers">The workers.</param>
        public void AddEventListeners(Type type, int workers = 1)
        {
            // validate queue names
            if (type.Name.Contains("<") || type.Name.Contains(">") || type.Name.Contains("__"))
            {
                return;
            }

            // Todo: Refactor
            for (int i = 1; i <= workers; i++)
            {
                Task.Run(() =>
                {
                    // set responder
                    var queueName = $"{_appNamespace}.{type.Name}.request".ToLower();
                    //var queueName = "wideworldimporters.salesservice.app.orderinfo.request";
                    var wkrId = Guid.NewGuid().ToString();
                    var responder = $"{queueName}:{wkrId}";

                    var factory = new ConnectionFactory()
                    {
                        HostName = _config.QueueHost,
                        Port = (int)_config.QueuePort,
                        UserName = _config.QueueUserName,
                        Password = _config.QueuePassword
                    };


                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                        channel.BasicQos(0, 1, false);
                        var consumer = new EventingBasicConsumer(channel);
                        channel.BasicConsume(queue: queueName, noAck: false, consumer: consumer);

                        _logger.LogInformation($"Awaiting requests for {queueName}");

                        consumer.Received += (model, ea) =>
                        {
                            // log start
                            _logger.LogInformation($"Message received on {queueName}");

                            string response = null;
                            var body = ea.Body;
                            var props = ea.BasicProperties;
                            var replyProps = channel.CreateBasicProperties();
                            replyProps.CorrelationId = props.CorrelationId;
                            RequestBaseDto requestBase = null;
                            try
                            {
                                // fetch & log message
                                var request = Encoding.UTF8.GetString(body);
                                _logger.LogDebug($"{request}");
                                requestBase = JsonConvert.DeserializeObject<RequestBaseDto>(request);

                                // process request & respond                 
                                var processor = _serviceProvider.GetService(type) as IRequestResolver;
                                var responseBytes = processor.ProcessRequest(request, responder);
                                response = Encoding.UTF8.GetString(responseBytes);
                                _logger.LogDebug($"Sending response: {response}");
                            }
                            catch (Exception e)
                            {
                                _logger.LogError($"Error at {responder}: {e.Message}");
                                
                                response = JsonConvert.SerializeObject(new ResponseBaseDto()
                                {                                    
                                    Header = new ResponseBaseHeaderDto
                                    {
                                        StatusCode = System.Net.HttpStatusCode.InternalServerError,
                                        ErrorDescription = e.Message,
                                        RespondedBy = responder,
                                        ResponsetId = props.ReplyTo,
                                        Request = requestBase?.Header
                                    },
                                    
                                });
                            }
                            finally
                            {
                                var responseBytes = Encoding.UTF8.GetBytes(response);
                                channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                            }
                        };

                        Console.WriteLine(" Press [enter] to exit.");
                        Console.ReadLine();
                    }
                });
            }

        }

    }
}
