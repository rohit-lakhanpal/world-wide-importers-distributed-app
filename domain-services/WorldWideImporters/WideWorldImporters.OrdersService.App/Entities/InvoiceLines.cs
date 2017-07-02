using System;

namespace WideWorldImporters.SalesService.App.Entities
{
    public partial class InvoiceLines
    {
        /// <summary>
        /// Gets or sets the invoice line identifier.
        /// </summary>
        /// <value>
        /// The invoice line identifier.
        /// </value>
        public int InvoiceLineId { get; set; }
        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public int InvoiceId { get; set; }
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
        /// Gets or sets the tax amount.
        /// </summary>
        /// <value>
        /// The tax amount.
        /// </value>
        public decimal TaxAmount { get; set; }
        /// <summary>
        /// Gets or sets the line profit.
        /// </summary>
        /// <value>
        /// The line profit.
        /// </value>
        public decimal LineProfit { get; set; }
        /// <summary>
        /// Gets or sets the extended price.
        /// </summary>
        /// <value>
        /// The extended price.
        /// </value>
        public decimal ExtendedPrice { get; set; }
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
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        public virtual Invoices Invoice { get; set; }
    }
}
