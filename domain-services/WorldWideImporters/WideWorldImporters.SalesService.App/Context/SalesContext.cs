using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WideWorldImporters.SalesService.App.Entities;
using WideWorldImporters.SalesService.App.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WideWorldImporters.SalesService.App.Context
{
    public partial class SalesContext : DbContext
    {
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        /// <value>
        /// The orders.
        /// </value>
        public virtual DbSet<Orders> Orders { get; set; }

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly AppSettings _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesContext" /> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="logger">The logger.</param>
        public SalesContext(IOptions<AppSettings> config,
                            ILogger<SalesContext> logger)
        {
            _logger = logger;
            _config = config.Value;
        }

        /// <summary>
        /// Called when [configuring].
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.DatabaseConnectionString);
        }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuyingGroups>(entity =>
            {
                entity.HasKey(e => e.BuyingGroupId)
                    .HasName("PK_Sales_BuyingGroups");

                entity.HasIndex(e => e.BuyingGroupName)
                    .HasName("UQ_Sales_BuyingGroups_BuyingGroupName")
                    .IsUnique();

                entity.Property(e => e.BuyingGroupId)
                    .HasColumnName("BuyingGroupID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[BuyingGroupID]");

                entity.Property(e => e.BuyingGroupName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerCategories>(entity =>
            {
                entity.HasKey(e => e.CustomerCategoryId)
                    .HasName("PK_Sales_CustomerCategories");

                entity.HasIndex(e => e.CustomerCategoryName)
                    .HasName("UQ_Sales_CustomerCategories_CustomerCategoryName")
                    .IsUnique();

                entity.Property(e => e.CustomerCategoryId)
                    .HasColumnName("CustomerCategoryID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[CustomerCategoryID]");

                entity.Property(e => e.CustomerCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerTransactions>(entity =>
            {
                entity.HasKey(e => e.CustomerTransactionId)
                    .HasName("PK_Sales_CustomerTransactions");

                entity.HasIndex(e => e.TransactionDate)
                    .HasName("CX_Sales_CustomerTransactions");

                entity.HasIndex(e => new { e.TransactionDate, e.CustomerId })
                    .HasName("FK_Sales_CustomerTransactions_CustomerID");

                entity.HasIndex(e => new { e.TransactionDate, e.InvoiceId })
                    .HasName("FK_Sales_CustomerTransactions_InvoiceID");

                entity.HasIndex(e => new { e.TransactionDate, e.IsFinalized })
                    .HasName("IX_Sales_CustomerTransactions_IsFinalized");

                entity.HasIndex(e => new { e.TransactionDate, e.PaymentMethodId })
                    .HasName("FK_Sales_CustomerTransactions_PaymentMethodID");

                entity.HasIndex(e => new { e.TransactionDate, e.TransactionTypeId })
                    .HasName("FK_Sales_CustomerTransactions_TransactionTypeID");

                entity.Property(e => e.CustomerTransactionId)
                    .HasColumnName("CustomerTransactionID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[TransactionID]");

                entity.Property(e => e.AmountExcludingTax).HasColumnType("decimal");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.FinalizationDate).HasColumnType("date");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.IsFinalized)
                    .HasComputedColumnSql("case when [FinalizationDate] IS NULL then CONVERT([bit],(0)) else CONVERT([bit],(1)) end")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");

                entity.Property(e => e.OutstandingBalance).HasColumnType("decimal");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal");

                entity.Property(e => e.TransactionAmount).HasColumnType("decimal");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionTypeId).HasColumnName("TransactionTypeID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerTransactions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_CustomerTransactions_CustomerID_Sales_Customers");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.CustomerTransactions)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK_Sales_CustomerTransactions_InvoiceID_Sales_Invoices");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK_Sales_Customers");

                entity.HasIndex(e => e.AlternateContactPersonId)
                    .HasName("FK_Sales_Customers_AlternateContactPersonID");

                entity.HasIndex(e => e.BuyingGroupId)
                    .HasName("FK_Sales_Customers_BuyingGroupID");

                entity.HasIndex(e => e.CustomerCategoryId)
                    .HasName("FK_Sales_Customers_CustomerCategoryID");

                entity.HasIndex(e => e.CustomerName)
                    .HasName("UQ_Sales_Customers_CustomerName")
                    .IsUnique();

                entity.HasIndex(e => e.DeliveryCityId)
                    .HasName("FK_Sales_Customers_DeliveryCityID");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("FK_Sales_Customers_DeliveryMethodID");

                entity.HasIndex(e => e.PostalCityId)
                    .HasName("FK_Sales_Customers_PostalCityID");

                entity.HasIndex(e => e.PrimaryContactPersonId)
                    .HasName("FK_Sales_Customers_PrimaryContactPersonID");

                entity.HasIndex(e => new { e.PrimaryContactPersonId, e.IsOnCreditHold, e.CustomerId, e.BillToCustomerId })
                    .HasName("IX_Sales_Customers_Perf_20160301_06");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[CustomerID]");

                entity.Property(e => e.AccountOpenedDate).HasColumnType("date");

                entity.Property(e => e.AlternateContactPersonId).HasColumnName("AlternateContactPersonID");

                entity.Property(e => e.BillToCustomerId).HasColumnName("BillToCustomerID");

                entity.Property(e => e.BuyingGroupId).HasColumnName("BuyingGroupID");

                entity.Property(e => e.CreditLimit).HasColumnType("decimal");

                entity.Property(e => e.CustomerCategoryId).HasColumnName("CustomerCategoryID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeliveryAddressLine1)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.DeliveryAddressLine2).HasMaxLength(60);

                entity.Property(e => e.DeliveryCityId).HasColumnName("DeliveryCityID");

                entity.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");

                entity.Property(e => e.DeliveryPostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DeliveryRun).HasMaxLength(5);

                entity.Property(e => e.FaxNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PostalAddressLine1)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.PostalAddressLine2).HasMaxLength(60);

                entity.Property(e => e.PostalCityId).HasColumnName("PostalCityID");

                entity.Property(e => e.PostalPostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PrimaryContactPersonId).HasColumnName("PrimaryContactPersonID");

                entity.Property(e => e.RunPosition).HasMaxLength(5);

                entity.Property(e => e.StandardDiscountPercentage).HasColumnType("decimal");

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasColumnName("WebsiteURL")
                    .HasMaxLength(256);

                entity.HasOne(d => d.BillToCustomer)
                    .WithMany(p => p.InverseBillToCustomer)
                    .HasForeignKey(d => d.BillToCustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_Customers_BillToCustomerID_Sales_Customers");

                entity.HasOne(d => d.BuyingGroup)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.BuyingGroupId)
                    .HasConstraintName("FK_Sales_Customers_BuyingGroupID_Sales_BuyingGroups");

                entity.HasOne(d => d.CustomerCategory)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerCategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_Customers_CustomerCategoryID_Sales_CustomerCategories");
            });

            modelBuilder.Entity<InvoiceLines>(entity =>
            {
                entity.HasKey(e => e.InvoiceLineId)
                    .HasName("PK_Sales_InvoiceLines");

                entity.HasIndex(e => e.InvoiceId)
                    .HasName("FK_Sales_InvoiceLines_InvoiceID");

                entity.HasIndex(e => e.PackageTypeId)
                    .HasName("FK_Sales_InvoiceLines_PackageTypeID");

                entity.HasIndex(e => e.StockItemId)
                    .HasName("FK_Sales_InvoiceLines_StockItemID");

                entity.HasIndex(e => new { e.InvoiceId, e.StockItemId, e.Quantity, e.UnitPrice, e.LineProfit, e.LastEditedWhen })
                    .HasName("NCCX_Sales_InvoiceLines");

                entity.Property(e => e.InvoiceLineId)
                    .HasColumnName("InvoiceLineID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[InvoiceLineID]");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ExtendedPrice).HasColumnType("decimal");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");

                entity.Property(e => e.LineProfit).HasColumnType("decimal");

                entity.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");

                entity.Property(e => e.StockItemId).HasColumnName("StockItemID");

                entity.Property(e => e.TaxAmount).HasColumnType("decimal");

                entity.Property(e => e.TaxRate).HasColumnType("decimal");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceLines)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_InvoiceLines_InvoiceID_Sales_Invoices");
            });

            modelBuilder.Entity<Invoices>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK_Sales_Invoices");

                entity.HasIndex(e => e.AccountsPersonId)
                    .HasName("FK_Sales_Invoices_AccountsPersonID");

                entity.HasIndex(e => e.BillToCustomerId)
                    .HasName("FK_Sales_Invoices_BillToCustomerID");

                entity.HasIndex(e => e.ContactPersonId)
                    .HasName("FK_Sales_Invoices_ContactPersonID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Sales_Invoices_CustomerID");

                entity.HasIndex(e => e.DeliveryMethodId)
                    .HasName("FK_Sales_Invoices_DeliveryMethodID");

                entity.HasIndex(e => e.OrderId)
                    .HasName("FK_Sales_Invoices_OrderID");

                entity.HasIndex(e => e.PackedByPersonId)
                    .HasName("FK_Sales_Invoices_PackedByPersonID");

                entity.HasIndex(e => e.SalespersonPersonId)
                    .HasName("FK_Sales_Invoices_SalespersonPersonID");

                entity.HasIndex(e => new { e.ConfirmedReceivedBy, e.ConfirmedDeliveryTime })
                    .HasName("IX_Sales_Invoices_ConfirmedDeliveryTime");

                entity.Property(e => e.InvoiceId)
                    .HasColumnName("InvoiceID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[InvoiceID]");

                entity.Property(e => e.AccountsPersonId).HasColumnName("AccountsPersonID");

                entity.Property(e => e.BillToCustomerId).HasColumnName("BillToCustomerID");

                entity.Property(e => e.ConfirmedDeliveryTime)
                    .HasComputedColumnSql("TRY_CONVERT([datetime2](7),json_value([ReturnedDeliveryData],N'$.DeliveredWhen'),(126))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ConfirmedReceivedBy)
                    .HasComputedColumnSql("json_value([ReturnedDeliveryData],N'$.ReceivedBy')")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(20);

                entity.Property(e => e.DeliveryMethodId).HasColumnName("DeliveryMethodID");

                entity.Property(e => e.DeliveryRun).HasMaxLength(5);

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PackedByPersonId).HasColumnName("PackedByPersonID");

                entity.Property(e => e.RunPosition).HasMaxLength(5);

                entity.Property(e => e.SalespersonPersonId).HasColumnName("SalespersonPersonID");

                entity.HasOne(d => d.BillToCustomer)
                    .WithMany(p => p.InvoicesBillToCustomer)
                    .HasForeignKey(d => d.BillToCustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_Invoices_BillToCustomerID_Sales_Customers");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.InvoicesCustomer)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_Invoices_CustomerID_Sales_Customers");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Sales_Invoices_OrderID_Sales_Orders");
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.HasKey(e => e.OrderLineId)
                    .HasName("PK_Sales_OrderLines");

                entity.HasIndex(e => e.OrderId)
                    .HasName("FK_Sales_OrderLines_OrderID");

                entity.HasIndex(e => e.PackageTypeId)
                    .HasName("FK_Sales_OrderLines_PackageTypeID");

                entity.HasIndex(e => new { e.PickedQuantity, e.StockItemId })
                    .HasName("IX_Sales_OrderLines_AllocatedStockItems");

                entity.HasIndex(e => new { e.OrderId, e.PickedQuantity, e.StockItemId, e.PickingCompletedWhen })
                    .HasName("IX_Sales_OrderLines_Perf_20160301_02");

                entity.HasIndex(e => new { e.Quantity, e.StockItemId, e.PickingCompletedWhen, e.OrderId, e.OrderLineId })
                    .HasName("IX_Sales_OrderLines_Perf_20160301_01");

                entity.HasIndex(e => new { e.OrderId, e.StockItemId, e.Description, e.Quantity, e.UnitPrice, e.PickedQuantity })
                    .HasName("NCCX_Sales_OrderLines");

                entity.Property(e => e.OrderLineId)
                    .HasColumnName("OrderLineID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[OrderLineID]");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");

                entity.Property(e => e.StockItemId).HasColumnName("StockItemID");

                entity.Property(e => e.TaxRate).HasColumnType("decimal");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_OrderLines_OrderID_Sales_Orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Sales_Orders");

                entity.HasIndex(e => e.ContactPersonId)
                    .HasName("FK_Sales_Orders_ContactPersonID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Sales_Orders_CustomerID");

                entity.HasIndex(e => e.PickedByPersonId)
                    .HasName("FK_Sales_Orders_PickedByPersonID");

                entity.HasIndex(e => e.SalespersonPersonId)
                    .HasName("FK_Sales_Orders_SalespersonPersonID");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[OrderID]");

                entity.Property(e => e.BackorderOrderId).HasColumnName("BackorderOrderID");

                entity.Property(e => e.ContactPersonId).HasColumnName("ContactPersonID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerPurchaseOrderNumber).HasMaxLength(20);

                entity.Property(e => e.ExpectedDeliveryDate).HasColumnType("date");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.PickedByPersonId).HasColumnName("PickedByPersonID");

                entity.Property(e => e.SalespersonPersonId).HasColumnName("SalespersonPersonID");

                entity.HasOne(d => d.BackorderOrder)
                    .WithMany(p => p.InverseBackorderOrder)
                    .HasForeignKey(d => d.BackorderOrderId)
                    .HasConstraintName("FK_Sales_Orders_BackorderOrderID_Sales_Orders");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Sales_Orders_CustomerID_Sales_Customers");
            });

            modelBuilder.Entity<SpecialDeals>(entity =>
            {
                entity.HasKey(e => e.SpecialDealId)
                    .HasName("PK_Sales_SpecialDeals");

                entity.HasIndex(e => e.BuyingGroupId)
                    .HasName("FK_Sales_SpecialDeals_BuyingGroupID");

                entity.HasIndex(e => e.CustomerCategoryId)
                    .HasName("FK_Sales_SpecialDeals_CustomerCategoryID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("FK_Sales_SpecialDeals_CustomerID");

                entity.HasIndex(e => e.StockGroupId)
                    .HasName("FK_Sales_SpecialDeals_StockGroupID");

                entity.HasIndex(e => e.StockItemId)
                    .HasName("FK_Sales_SpecialDeals_StockItemID");

                entity.Property(e => e.SpecialDealId)
                    .HasColumnName("SpecialDealID")
                    .HasDefaultValueSql("NEXT VALUE FOR [Sequences].[SpecialDealID]");

                entity.Property(e => e.BuyingGroupId).HasColumnName("BuyingGroupID");

                entity.Property(e => e.CustomerCategoryId).HasColumnName("CustomerCategoryID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DealDescription)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LastEditedWhen).HasDefaultValueSql("sysdatetime()");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.StockGroupId).HasColumnName("StockGroupID");

                entity.Property(e => e.StockItemId).HasColumnName("StockItemID");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal");

                entity.HasOne(d => d.BuyingGroup)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.BuyingGroupId)
                    .HasConstraintName("FK_Sales_SpecialDeals_BuyingGroupID_Sales_BuyingGroups");

                entity.HasOne(d => d.CustomerCategory)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.CustomerCategoryId)
                    .HasConstraintName("FK_Sales_SpecialDeals_CustomerCategoryID_Sales_CustomerCategories");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SpecialDeals)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Sales_SpecialDeals_CustomerID_Sales_Customers");
            });
        }
    }
}
