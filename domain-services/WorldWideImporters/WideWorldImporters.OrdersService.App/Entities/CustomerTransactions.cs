using System;

namespace WideWorldImporters.SalesService.App.Entities
{
    public partial class CustomerTransactions
    {
        /// <summary>
        /// Gets or sets the customer transaction identifier.
        /// </summary>
        /// <value>
        /// The customer transaction identifier.
        /// </value>
        public int CustomerTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the transaction type identifier.
        /// </summary>
        /// <value>
        /// The transaction type identifier.
        /// </value>
        public int TransactionTypeId { get; set; }
        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        /// <value>
        /// The invoice identifier.
        /// </value>
        public int? InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets the payment method identifier.
        /// </summary>
        /// <value>
        /// The payment method identifier.
        /// </value>
        public int? PaymentMethodId { get; set; }
        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>
        /// The transaction date.
        /// </value>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// Gets or sets the amount excluding tax.
        /// </summary>
        /// <value>
        /// The amount excluding tax.
        /// </value>
        public decimal AmountExcludingTax { get; set; }
        /// <summary>
        /// Gets or sets the tax amount.
        /// </summary>
        /// <value>
        /// The tax amount.
        /// </value>
        public decimal TaxAmount { get; set; }
        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <value>
        /// The transaction amount.
        /// </value>
        public decimal TransactionAmount { get; set; }
        /// <summary>
        /// Gets or sets the outstanding balance.
        /// </summary>
        /// <value>
        /// The outstanding balance.
        /// </value>
        public decimal OutstandingBalance { get; set; }
        /// <summary>
        /// Gets or sets the finalization date.
        /// </summary>
        /// <value>
        /// The finalization date.
        /// </value>
        public DateTime? FinalizationDate { get; set; }
        /// <summary>
        /// Gets or sets the is finalized.
        /// </summary>
        /// <value>
        /// The is finalized.
        /// </value>
        public bool? IsFinalized { get; set; }
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
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public virtual Customers Customer { get; set; }
        /// <summary>
        /// Gets or sets the invoice.
        /// </summary>
        /// <value>
        /// The invoice.
        /// </value>
        public virtual Invoices Invoice { get; set; }
    }
}
