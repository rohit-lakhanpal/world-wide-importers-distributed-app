using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WideWorldImporters.Common.Lib.Dto.Order;
using WideWorldImporters.SalesService.App.Context;
using WideWorldImporters.SalesService.App.Entities;
using WideWorldImporters.SalesService.App.Models;

namespace WideWorldImporters.SalesService.App.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrdersQueryRepositoryService
    {
        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        OrderDto GetOrder(int orderId);

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        Task<OrderDto> GetOrderByIdAsync(int orderId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="WideWorldImporters.SalesService.App.Services.IOrdersQueryRepositoryService" />
    /// <seealso cref="IDisposable" />
    public class OrdersQueryRepositoryService : IOrdersQueryRepositoryService
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IOptions<AppSettings> _config;
        /// <summary>
        /// The sales logger
        /// </summary>
        private readonly ILogger<SalesContext> _salesLogger;


        /// <summary>
        /// Gets or sets the sales context.
        /// </summary>
        /// <value>
        /// The sales context.
        /// </value>
        public SalesContext _salesContext { get; set; }


        private readonly IServiceProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersQueryRepositoryService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="salesContext">The sales context.</param>
        public OrdersQueryRepositoryService(ILogger<OrdersQueryRepositoryService> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;           
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public OrderDto GetOrder(int orderId)
        {
            OrderDto dto = null;

            var scopeFactory = _provider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<SalesContext>())
            {
                var model = context.Orders.Find(orderId);
                var modelJson = JsonConvert.SerializeObject(model);
                dto = JsonConvert.DeserializeObject<OrderDto>(modelJson);
                //dto = Mapper.Map<OrderDto>(model); //TODO: use automapper
            }
            return dto;
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns></returns>
        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {   
            Orders entity;
            OrderDto dto = null;

            using (var context = _salesContext)
            {
                entity = await context.Orders.FindAsync(orderId);
            }

            try
            {
                var x = JsonConvert.SerializeObject(entity);
                //dto = Mapper.Map<OrderDto>(entity);
                dto = JsonConvert.DeserializeObject<OrderDto>(x);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return dto;
        }
    }
}
