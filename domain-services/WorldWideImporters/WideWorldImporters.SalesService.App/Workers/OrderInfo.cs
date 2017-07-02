using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using WideWorldImporters.Common.Lib.Common;
using WideWorldImporters.Common.Lib.Dto.Order;
using WideWorldImporters.SalesService.App.Helpers;
using WideWorldImporters.SalesService.App.Models;
using WideWorldImporters.SalesService.App.Services;
using System;

namespace WideWorldImporters.SalesService.App.Workers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="WideWorldImporters.Common.Lib.Common.IRequestResolver" />
    public class OrderInfo : IRequestResolver
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
        /// The orders repo
        /// </summary>
        private IOrdersQueryRepositoryService _ordersRepo;

        public OrderInfo(IOptions<AppSettings> config, ILoggerFactory loggerFactory, IOrdersQueryRepositoryService ordersRepo)
        {
            _configOptions = config;
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<OrderInfo>();
            _ordersRepo = ordersRepo;
        }

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responderIdentity">The responder identity.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<byte[]> ProcessRequestAsync(string requestMessage, string responderIdentity)
        {
            // log request
            _logger.LogDebug("Begin processing request");
            byte[] response = null;

            // convert the request message to appropriate request object
            // todo: error handling here!
            var request = JsonConvert.DeserializeObject<OrderInfoRequestDto>(requestMessage);

            // check which method to call
            if (request.Body.RequestType == OrderInfoRequestType.REQUEST_BY_ID)
            {   
                var q = int.Parse(request.Body.RequestQuery); // todo: error handling
                // todo: check if new instance of _ordersRepo needs creating??
                var orderDto = await _ordersRepo.GetOrderByIdAsync(q);
                
                var responseMessage = JsonConvert.SerializeObject(request.ToDto(orderDto, responderIdentity));
                response = Encoding.UTF8.GetBytes(responseMessage);
            }
            
            return response;
        }

        /// <summary>
        /// Processes the request asynchronous.
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responderIdentity">The responder identity.</param>
        /// <returns></returns>
        public byte[] ProcessRequest(string requestMessage, string responderIdentity)
        {
            // log request
            _logger.LogDebug("Begin processing request");
            byte[] response = null;

            // convert the request message to appropriate request object
            // todo: error handling here!
            var request = JsonConvert.DeserializeObject<OrderInfoRequestDto>(requestMessage);

            // check which method to call
            if (request.Body.RequestType == OrderInfoRequestType.REQUEST_BY_ID)
            {
                var q = int.Parse(request.Body.RequestQuery); // todo: error handling
                // todo: check if new instance of _ordersRepo needs creating??
                var orderDto =  _ordersRepo.GetOrder(q);

                var responseMessage = JsonConvert.SerializeObject(request.ToDto(orderDto, responderIdentity));
                response = Encoding.UTF8.GetBytes(responseMessage);
            }

            return response;
        }
    }
}
