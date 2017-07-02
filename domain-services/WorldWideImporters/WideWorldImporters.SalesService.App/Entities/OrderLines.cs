using System;

namespace WideWorldImporters.SalesService.App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OrderLines
    {
        /// <summary>
        /// Gets or sets the order line identifier.
        /// </summary>
        /// <value>
        /// The order line identifier.
        /// </value>
        public int OrderLineId { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the stock item identifier.
        /// </summary>
        /// <value>
        /// The stock item identifier.
        /// </value>
        public int StockItemId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the package type identifier.
        /// </summary>
        /// <value>
        /// The package type identifier.
        /// </value>
        public int PackageTypeId { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// Gets or sets the tax rate.
        /// </summary>
        /// <value>
        /// The tax rate.
        /// </value>
        public decimal TaxRate { get; set; }
        /// <summary>
        /// Gets or sets the picked quantity.
        /// </summary>
        /// <value>
        /// The picked quantity.
        /// </value>
        public int PickedQuantity { get; set; }
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
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public virtual Orders Order { get; set; }
    }
}
