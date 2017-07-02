using Microsoft.Extensions.Logging;
using System;

namespace WideWorldImporters.OrdersService.App.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrdersQueryRepositoryService
    {
        /// <summary>
        /// Works this instance.
        /// </summary>
        void Work();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="WideWorldImporters.OrdersService.App.Services.IOrdersQueryRepositoryService" />
    /// <seealso cref="IDisposable" />
    public class OrdersQueryRepositoryService : IOrdersQueryRepositoryService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersQueryRepositoryService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public OrdersQueryRepositoryService(ILogger<OrdersQueryRepositoryService> logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Works this instance.
        /// </summary>
        public void Work()
        {
            _logger.LogInformation("Doing work.");
        }
    }
}
