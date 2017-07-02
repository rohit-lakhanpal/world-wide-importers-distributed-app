using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WideWorldImporters.SalesService.App.Models;
using WideWorldImporters.SalesService.App.Services;
using WideWorldImporters.SalesService.App.Context;
using System;
using System.Reflection;
using Microsoft.Extensions.Options;
using WideWorldImporters.Common.Lib.Dto.Order;
using AutoMapper;

namespace WideWorldImporters.SalesService.App
{
    /// <summary>
    /// This program manages the "Sales" schema for the "WideWorldImporters" database.S
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static ILogger<Program> logger;

        /// <summary>
        /// The service provider
        /// </summary>
        private static IServiceProvider serviceProvider;

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            // initialise startup logger
            InitialiseStartupLogger();

            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // check startup criteria met
            var x = serviceProvider.GetService<IOptions<AppSettings>>().Value as AppSettings;
            //serviceProvider.
            CheckStartupCriteria(x);

            // run app
            serviceProvider.GetService<App>().Run();

            // wait
            while (true)
            {
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Initialises the startup logger.
        /// </summary>
        private static void InitialiseStartupLogger()
        {
            logger = new LoggerFactory().AddConsole()
                .AddDebug().CreateLogger<Program>();
            logger.LogInformation("Application started & logger initialised");
        }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();

            // build configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", true);
            builder.AddEnvironmentVariables();
            var configuration = builder.Build();
            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("WwiSalesServiceConfiguration"));

            // add services
            serviceCollection.AddTransient<IOrdersQueryRepositoryService, OrdersQueryRepositoryService>();
            serviceCollection.AddDbContext<SalesContext>();

            // add app
            serviceCollection.AddTransient<App>();

            // create service provider
            serviceProvider = serviceCollection.BuildServiceProvider();

            // initialise automapper
            InitialiseAutoMapper();
        }

        /// <summary>
        /// Checks the startup criteria.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void CheckStartupCriteria(AppSettings config)
        {
            var properties = config.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                logger.LogInformation($"Config Key [{property.Name}] has Value [{property.GetValue(config).ToString()}]");
            }

            ConfigureConsole(config);
        }

        /// <summary>
        /// Configures the console.
        /// </summary>
        /// <param name="config">The configuration.</param>
        private static void ConfigureConsole(AppSettings config)
        {
            System.Console.Title = config.ConsoleTitle;
        }

        /// <summary>
        /// Initialises the automatic mapper.
        /// </summary>
        private static void InitialiseAutoMapper()
        {
            // TODO: Add automapper
        }
    }
}
