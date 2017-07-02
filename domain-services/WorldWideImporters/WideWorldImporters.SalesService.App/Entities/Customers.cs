using System;
using System.Collections.Generic;

namespace WideWorldImporters.SalesService.App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Customers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customers" /> class.
        /// </summary>
        public Customers()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InvoicesBillToCustomer = new HashSet<Invoices>();
            InvoicesCustomer = new HashSet<Invoices>();
            Orders = new HashSet<Orders>();
            SpecialDeals = new HashSet<SpecialDeals>();
        }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the bill to customer identifier.
        /// </summary>
        /// <value>
        /// The bill to customer identifier.
        /// </value>
        public int BillToCustomerId { get; set; }
        /// <summary>
        /// Gets or sets the customer category identifier.
        /// </summary>
        /// <value>
        /// The customer category identifier.
        /// </value>
        public int CustomerCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the buying group identifier.
        /// </summary>
        /// <value>
        /// The buying group identifier.
        /// </value>
        public int? BuyingGroupId { get; set; }
        /// <summary>
        /// Gets or sets the primary contact person identifier.
        /// </summary>
        /// <value>
        /// The primary contact person identifier.
        /// </value>
        public int PrimaryContactPersonId { get; set; }
        /// <summary>
        /// Gets or sets the alternate contact person identifier.
        /// </summary>
        /// <value>
        /// The alternate contact person identifier.
        /// </value>
        public int? AlternateContactPersonId { get; set; }
        /// <summary>
        /// Gets or sets the delivery method identifier.
        /// </summary>
        /// <value>
        /// The delivery method identifier.
        /// </value>
        public int DeliveryMethodId { get; set; }
        /// <summary>
        /// Gets or sets the delivery city identifier.
        /// </summary>
        /// <value>
        /// The delivery city identifier.
        /// </value>
        public int DeliveryCityId { get; set; }
        /// <summary>
        /// Gets or sets the postal city identifier.
        /// </summary>
        /// <value>
        /// The postal city identifier.
        /// </value>
        public int PostalCityId { get; set; }
        /// <summary>
        /// Gets or sets the credit limit.
        /// </summary>
        /// <value>
        /// The credit limit.
        /// </value>
        public decimal? CreditLimit { get; set; }
        /// <summary>
        /// Gets or sets the account opened date.
        /// </summary>
        /// <value>
        /// The account opened date.
        /// </value>
        public DateTime AccountOpenedDate { get; set; }
        /// <summary>
        /// Gets or sets the standard discount percentage.
        /// </summary>
        /// <value>
        /// The standard discount percentage.
        /// </value>
        public decimal StandardDiscountPercentage { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is statement sent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is statement sent; otherwise, <c>false</c>.
        /// </value>
        public bool IsStatementSent { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is on credit hold.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is on credit hold; otherwise, <c>false</c>.
        /// </value>
        public bool IsOnCreditHold { get; set; }
        /// <summary>
        /// Gets or sets the payment days.
        /// </summary>
        /// <value>
        /// The payment days.
        /// </value>
        public int PaymentDays { get; set; }
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the fax number.
        /// </summary>
        /// <value>
        /// The fax number.
        /// </value>
        public string FaxNumber { get; set; }
        /// <summary>
        /// Gets or sets the delivery run.
        /// </summary>
        /// <value>
        /// The delivery run.
        /// </value>
        public string DeliveryRun { get; set; }
        /// <summary>
        /// Gets or sets the run position.
        /// </summary>
        /// <value>
        /// The run position.
        /// </value>
        public string RunPosition { get; set; }
        /// <summary>
        /// Gets or sets the website URL.
        /// </summary>
        /// <value>
        /// The website URL.
        /// </value>
        public string WebsiteUrl { get; set; }
        /// <summary>
        /// Gets or sets the delivery address line1.
        /// </summary>
        /// <value>
        /// The delivery address line1.
        /// </value>
        public string DeliveryAddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the delivery address line2.
        /// </summary>
        /// <value>
        /// The delivery address line2.
        /// </value>
        public string DeliveryAddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the delivery postal code.
        /// </summary>
        /// <value>
        /// The delivery postal code.
        /// </value>
        public string DeliveryPostalCode { get; set; }
        /// <summary>
        /// Gets or sets the postal address line1.
        /// </summary>
        /// <value>
        /// The postal address line1.
        /// </value>
        public string PostalAddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets the postal address line2.
        /// </summary>
        /// <value>
        /// The postal address line2.
        /// </value>
        public string PostalAddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets the postal postal code.
        /// </summary>
        /// <value>
        /// The postal postal code.
        /// </value>
        public string PostalPostalCode { get; set; }
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
        /// Gets or sets the customer transactions.
        /// </summary>
        /// <value>
        /// The customer transactions.
        /// </value>
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        /// <summary>
        /// Gets or sets the invoices bill to customer.
        /// </summary>
        /// <value>
        /// The invoices bill to customer.
        /// </value>
        public virtual ICollection<Invoices> InvoicesBillToCustomer { get; set; }
        /// <summary>
        /// Gets or sets the invoices customer.
        /// </summary>
        /// <value>
        /// The invoices customer.
        /// </value>
        public virtual ICollection<Invoices> InvoicesCustomer { get; set; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public virtual ICollection<Orders> Orders { get; set; }
        /// <summary>
        /// Gets or sets the special deals.
        /// </summary>
        /// <value>
        /// The special deals.
        /// </value>
        public virtual ICollection<SpecialDeals> SpecialDeals { get; set; }
        /// <summary>
        /// Gets or sets the bill to customer.
        /// </summary>
        /// <value>
        /// The bill to customer.
        /// </value>
        public virtual Customers BillToCustomer { get; set; }
        /// <summary>
        /// Gets or sets the inverse bill to customer.
        /// </summary>
        /// <value>
        /// The inverse bill to customer.
        /// </value>
        public virtual ICollection<Customers> InverseBillToCustomer { get; set; }
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
    }
}
