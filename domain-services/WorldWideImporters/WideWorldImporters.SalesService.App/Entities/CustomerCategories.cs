using System;
using System.Collections.Generic;

namespace WideWorldImporters.SalesService.App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CustomerCategories
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCategories" /> class.
        /// </summary>
        public CustomerCategories()
        {
            Customers = new HashSet<Customers>();
            SpecialDeals = new HashSet<SpecialDeals>();
        }

        /// <summary>
        /// Gets or sets the customer category identifier.
        /// </summary>
        /// <value>
        /// The customer category identifier.
        /// </value>
        public int CustomerCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the name of the customer category.
        /// </summary>
        /// <value>
        /// The name of the customer category.
        /// </value>
        public string CustomerCategoryName { get; set; }
        /// <summary>
        /// Gets or sets the last edited by.
        /// </summary>
        /// <value>
        /// The last edited by.
        /// </value>
        public int LastEditedBy { get; set; }
        /// <summary>
        /// Gets or sets the valid from.
        /// </summary>
        /// <value>
        /// The valid from.
        /// </value>
        public DateTime ValidFrom { get; set; }
        /// <summary>
        /// Gets or sets the valid to.
        /// </summary>
        /// <value>
        /// The valid to.
        /// </value>
        public DateTime ValidTo { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public virtual ICollection<Customers> Customers { get; set; }
        /// <summary>
        /// Gets or sets the special deals.
        /// </summary>
        /// <value>
        /// The special deals.
        /// </value>
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
    }
}
