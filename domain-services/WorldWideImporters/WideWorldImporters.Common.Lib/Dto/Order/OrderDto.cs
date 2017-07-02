using System;

namespace WideWorldImporters.Common.Lib.Dto.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the salesperson person identifier.
        /// </summary>
        /// <value>
        /// The salesperson person identifier.
        /// </value>
        public int SalespersonPersonId { get; set; }
        /// <summary>
        /// Gets or sets the picked by person identifier.
        /// </summary>
        /// <value>
        /// The picked by person identifier.
        /// </value>
        public int? PickedByPersonId { get; set; }
        /// <summary>
        /// Gets or sets the contact person identifier.
        /// </summary>
        /// <value>
        /// The contact person identifier.
        /// </value>
        public int ContactPersonId { get; set; }
        /// <summary>
        /// Gets or sets the backorder order identifier.
        /// </summary>
        /// <value>
        /// The backorder order identifier.
        /// </value>
        public int? BackorderOrderId { get; set; }
        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>
        /// The order date.
        /// </value>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Gets or sets the expected delivery date.
        /// </summary>
        /// <value>
        /// The expected delivery date.
        /// </value>
        public DateTime ExpectedDeliveryDate { get; set; }
        /// <summary>
        /// Gets or sets the customer purchase order number.
        /// </summary>
        /// <value>
        /// The customer purchase order number.
        /// </value>
        public string CustomerPurchaseOrderNumber { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is undersupply backordered.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is undersupply backordered; otherwise, <c>false</c>.
        /// </value>
        public bool IsUndersupplyBackordered { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Comments { get; set; }
        /// <summary>
        /// Gets or sets the delivery instructions.
        /// </summary>
        /// <value>
        /// The delivery instructions.
        /// </value>
        public string DeliveryInstructions { get; set; }
        /// <summary>
        /// Gets or sets the internal comments.
        /// </summary>
        /// <value>
        /// The internal comments.
        /// </value>
        public string InternalComments { get; set; }
        /// <summary>
        /// Gets or sets the picking completed when.
        /// </summary>
        /// <value>
        /// The picking completed when.
        /// </value>
        public DateTime? PickingCompletedWhen { get; set; }
        /// <summary>
        /// Gets or sets the last edited by.
        /// </summary>
        /// <value>
        /// The last edited by.
        /// </value>
        public int LastEditedBy { get; set; }
        /// <summary>
        /// Gets or sets the last edited when.
        /// </summary>
        /// <value>
        /// The last edited when.
        /// </value>
        public DateTime LastEditedWhen { get; set; }

        /// <summary>
        /// Gets or sets the order lines.
        /// </summary>
        /// <value>
        /// The order lines.
        /// </value>
        //public IEnumerable<OrderLineDto> OrderLines { get; set; }
    }
}
