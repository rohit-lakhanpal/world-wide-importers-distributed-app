using System;

namespace WideWorldImporters.SalesService.App.Entities
{
    public partial class SpecialDeals
    {
        /// <summary>
        /// Gets or sets the special deal identifier.
        /// </summary>
        /// <value>
        /// The special deal identifier.
        /// </value>
        public int SpecialDealId { get; set; }
        /// <summary>
        /// Gets or sets the stock item identifier.
        /// </summary>
        /// <value>
        /// The stock item identifier.
        /// </value>
        public int? StockItemId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int? CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the buying group identifier.
        /// </summary>
        /// <value>
        /// The buying group identifier.
        /// </value>
        public int? BuyingGroupId { get; set; }
        /// <summary>
        /// Gets or sets the customer category identifier.
        /// </summary>
        /// <value>
        /// The customer category identifier.
        /// </value>
        public int? CustomerCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the stock group identifier.
        /// </summary>
        /// <value>
        /// The stock group identifier.
        /// </value>
        public int? StockGroupId { get; set; }
        /// <summary>
        /// Gets or sets the deal description.
        /// </summary>
        /// <value>
        /// The deal description.
        /// </value>
        public string DealDescription { get; set; }
        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// Gets or sets the discount amount.
        /// </summary>
        /// <value>
        /// The discount amount.
        /// </value>
        public decimal? DiscountAmount { get; set; }
        /// <summary>
        /// Gets or sets the discount percentage.
        /// </summary>
        /// <value>
        /// The discount percentage.
        /// </value>
        public decimal? DiscountPercentage { get; set; }
        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal? UnitPrice { get; set; }
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
        /// Gets or sets the buying group.
        /// </summary>
        /// <value>
        /// The buying group.
        /// </value>
        public virtual BuyingGroups BuyingGroup { get; set; }
        /// <summary>
        /// Gets or sets the customer category.
        /// </summary>
        /// <value>
        /// The customer category.
        /// </value>
        public virtual CustomerCategories CustomerCategory { get; set; }
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual Customers Customer { get; set; }
    }
}
