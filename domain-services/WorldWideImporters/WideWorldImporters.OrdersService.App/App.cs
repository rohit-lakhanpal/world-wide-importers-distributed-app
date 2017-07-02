using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WideWorldImporters.OrdersService.App.Models;
using WideWorldImporters.OrdersService.App.Services;

namespace WideWorldImporters.OrdersService.App
{
    public class App
    {
        /// <summary>
        /// The test service
        /// </summary>
        private readonly ITestService _testService;
        /// <summary>
        /// The orders service
        /// </summary>
        private readonly IOrdersQueryRepositoryService _ordersService;
        /// <summary>
        /// The logger{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly ILogger<App> _logger;
        /// <summary>
        /// The configuration{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        private readonly AppSettings _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        /// <param name="testService">The test service.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public App(ITestService testService,
            IOrdersQueryRepositoryService ordersService,
                    IOptions<AppSettings> config,
                    ILogger<App> logger)
        {
            _testService = testService;
            _ordersService = ordersService;
            _logger = logger;
            _config = config.Value;
        }

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.ConsoleTitle}");
            _testService.Run();
            _ordersService.Work();
            System.Console.ReadKey();
        }
    }
}
