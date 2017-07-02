using System.Collections.Generic;

namespace WideWorldImporters.Common.Lib.Dto.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderInfoResponseBodyDto
    {
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}
