namespace WideWorldImporters.SalesService.App.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AppSettings
    {

        /// <summary>
        /// Sets header title in console window
        /// </summary>
        /// <value>
        /// The console title.
        /// </value>
        public string ConsoleTitle { get; set; }

        /// <summary>
        /// Gets or sets the database connection string.
        /// </summary>
        /// <value>
        /// The database connection string.
        /// </value>
        public string DatabaseConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the queue host.
        /// </summary>
        /// <value>
        /// The queue host.
        /// </value>
        public string QueueHost { get; set; }

        /// <summary>
        /// Gets or sets the queue port.
        /// </summary>
        /// <value>
        /// The queue port.
        /// </value>
        public int? QueuePort { get; set; }

        /// <summary>
        /// Gets or sets the name of the queue user.
        /// </summary>
        /// <value>
        /// The name of the queue user.
        /// </value>
        public string QueueUserName { get; set; }

        /// <summary>
        /// Gets or sets the queue password.
        /// </summary>
        /// <value>
        /// The queue password.
        /// </value>
        public string QueuePassword { get; set; }

    }
}
