using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using timw255.FormAnalytics.Data.EntityFramework.EntityConfigurations;
using timw255.FormAnalytics.Models;

namespace timw255.FormAnalytics.Data.EntityFramework
{
    public class FormAnalyticsEFDbContext : DbContext, IFormAnalyticsEFDbContext
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAnalyticsEFDbContext" /> class.
        /// </summary>
        public FormAnalyticsEFDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAnalyticsEFDbContext" /> class.
        /// </summary>
        /// <param name="dbConnectionString">The db connection string.</param>
        public FormAnalyticsEFDbContext(string dbConnectionString)
            : base(dbConnectionString)
        {
        }
        #endregion

        #region Properties

        private DbContextTransaction Transaction { get; set; }

        #endregion

        #region IFormAnalyticsEFDbContext

        public DbContextTransaction BeginTransaction()
        {
            if (this.Transaction != null)
            {
                this.Transaction.Dispose();
                this.Transaction = null;
            }
            this.Transaction = this.Database.BeginTransaction();
            return this.Transaction;
        }

        public void RollbackTransaction()
        {
            if (this.Transaction != null)
            {
                try
                {
                    this.Transaction.Rollback();
                }
                finally
                {
                    this.Transaction.Dispose();
                    this.Transaction = null;
                }
            }
        }

        public void CommitTransaction()
        {
            if (this.Transaction != null)
                this.Transaction.Commit();
        }
        #endregion

        #region Entities
        /// <summary>
        /// Gets or sets the AnalyticsEvents.
        /// </summary>
        /// <value>The AnalyticsEvents.</value>
        public DbSet<AnalyticsEvent> AnalyticsEvents { get; set; }
        #endregion

        #region DbContext method overrides
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnalyticsEventTypeConfiguration());
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Transaction != null)
            {
                this.Transaction.Dispose();
                this.Transaction = null;
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}