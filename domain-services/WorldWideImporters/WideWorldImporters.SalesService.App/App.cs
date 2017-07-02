using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WideWorldImporters.SalesService.App.Context;
using WideWorldImporters.SalesService.App.Models;
using WideWorldImporters.SalesService.App.Services;

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
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public App(IOptions<AppSettings> config, ILoggerFactory loggerFactory)
        {
            _configOptions = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<App>();
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.ConsoleTitle}");
            System.Console.ReadKey();
        }
    }
}
