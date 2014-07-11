using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using timw255.FormAnalytics.Models;

namespace timw255.FormAnalytics.Data.EntityFramework.EntityConfigurations
{
    public class AnalyticsEventTypeConfiguration : EntityTypeConfiguration<AnalyticsEvent>
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsEventTypeConfiguration" /> class.
        /// </summary>
        public AnalyticsEventTypeConfiguration()
        {
            this.ToTable("FormAnalytics_AnalyticsEvents");
            this.HasKey(x => x.Id);
            this.Property(x => x.SiteId).IsRequired().HasMaxLength(255);
            this.Property(x => x.Signal).IsRequired().HasMaxLength(255);
            this.Property(x => x.TrackingId).IsRequired().HasMaxLength(255);
            this.Property(x => x.FormId).IsRequired().HasMaxLength(255);
            this.Property(x => x.FieldName).IsRequired().HasMaxLength(255);
            this.Property(x => x.LastModified);
            this.Property(x => x.ApplicationName);
        }
        #endregion
    }
}