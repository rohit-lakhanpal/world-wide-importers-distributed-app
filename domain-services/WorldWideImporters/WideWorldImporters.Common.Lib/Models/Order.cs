using System.Collections.Generic;

namespace WideWorldImporters.Common.Lib.Models
{


    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<OrderItems> Items { get; set; }
    }
}
