using System;
using System.Collections.Generic;

namespace WideWorldImporters.SalesService.App.Entities
{
    public partial class BuyingGroups
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuyingGroups" /> class.
        /// </summary>
        public BuyingGroups()
        {
            Customers = new HashSet<Customers>();
            SpecialDeals = new HashSet<SpecialDeals>();
        }

        /// <summary>
        /// Gets or sets the buying group identifier.
        /// </summary>
        /// <value>
        /// The buying group identifier.
        /// </value>
        public int BuyingGroupId { get; set; }
        /// <summary>
        /// Gets or sets the name of the buying group.
        /// </summary>
        /// <value>
        /// The name of the buying group.
        /// </value>
        public string BuyingGroupName { get; set; }
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
