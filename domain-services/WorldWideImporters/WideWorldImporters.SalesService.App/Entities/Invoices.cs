using System;
using System.Collections.Generic;

namespace WideWorldImporters.SalesService.App.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Invoices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Invoices" /> class.
        /// </summary>
        public Invoices()
        {
            CustomerTransactions = new HashSet<CustomerTransactions>();
            InvoiceLines = new HashSet<InvoiceLines>();
        }

        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public int InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the bill to customer identifier.
        /// </summary>
        /// <value>
        /// The bill to customer identifier.
        /// </value>
        public int BillToCustomerId { get; set; }
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        public int? OrderId { get; set; }
        /// <summary>
        /// Gets or sets the delivery method identifier.
        /// </summary>
        /// <value>
        /// The delivery method identifier.
        /// </value>
        public int DeliveryMethodId { get; set; }
        /// <summary>
        /// Gets or sets the contact person identifier.
        /// </summary>
        /// <value>
        /// The contact person identifier.
        /// </value>
        public int ContactPersonId { get; set; }
        /// <summary>
        /// Gets or sets the accounts person identifier.
        /// </summary>
        /// <value>
        /// The accounts person identifier.
        /// </value>
        public int AccountsPersonId { get; set; }
        /// <summary>
        /// Gets or sets the salesperson person identifier.
        /// </summary>
        /// <value>
        /// The salesperson person identifier.
        /// </value>
        public int SalespersonPersonId { get; set; }
        /// <summary>
        /// Gets or sets the packed by person identifier.
        /// </summary>
        /// <value>
        /// The packed by person identifier.
        /// </value>
        public int PackedByPersonId { get; set; }
        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        /// <value>
        /// The invoice date.
        /// </value>
        public DateTime InvoiceDate { get; set; }
        /// <summary>
        /// Gets or sets the customer purchase order number.
        /// </summary>
        /// <value>
        /// The customer purchase order number.
        /// </value>
        public string CustomerPurchaseOrderNumber { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is credit note.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is credit note; otherwise, <c>false</c>.
        /// </value>
        public bool IsCreditNote { get; set; }
        /// <summary>
        /// Gets or sets the credit note reason.
        /// </summary>
        /// <value>
        /// The credit note reason.
        /// </value>
        public string CreditNoteReason { get; set; }
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
        /// Gets or sets the total dry items.
        /// </summary>
        /// <value>
        /// The total dry items.
        /// </value>
        public int TotalDryItems { get; set; }
        /// <summary>
        /// Gets or sets the total chiller items.
        /// </summary>
        /// <value>
        /// The total chiller items.
        /// </value>
        public int TotalChillerItems { get; set; }
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
        /// Gets or sets the returned delivery data.
        /// </summary>
        /// <value>
        /// The returned delivery data.
        /// </value>
        public string ReturnedDeliveryData { get; set; }
        /// <summary>
        /// Gets or sets the confirmed delivery time.
        /// </summary>
        /// <value>
        /// The confirmed delivery time.
        /// </value>
        public DateTime? ConfirmedDeliveryTime { get; set; }
        /// <summary>
        /// Gets or sets the confirmed received by.
        /// </summary>
        /// <value>
        /// The confirmed received by.
        /// </value>
        public string ConfirmedReceivedBy { get; set; }
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
        /// Gets or sets the customer transactions.
        /// </summary>
        /// <value>
        /// The customer transactions.
        /// </value>
        public virtual ICollection<CustomerTransactions> CustomerTransactions { get; set; }
        /// <summary>
        /// Gets or sets the invoice lines.
        /// </summary>
        /// <value>
        /// The invoice lines.
        /// </value>
        public virtual ICollection<InvoiceLines> InvoiceLines { get; set; }
        /// <summary>
        /// Gets or sets the bill to customer.
        /// </summary>
        /// <value>
        /// The bill to customer.
        /// </value>
        public virtual Customers BillToCustomer { get; set; }
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual Customers Customer { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public virtual Orders Order { get; set; }
    }
}
