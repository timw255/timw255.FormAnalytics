using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;
using Telerik.Sitefinity.Model;

namespace timw255.FormAnalytics.Models
{
    public class AnalyticsEvent : IDataItem
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsEvent" /> class.
        /// </summary>
        public AnalyticsEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyticsEvent" /> class.
        /// </summary>
        /// <param name="id">The AnalyticsEvent ID.</param>
        /// <param name="applicationName">Name of the application.</param>
        public AnalyticsEvent(Guid id, string applicationName)
        {
            this.Id = id;
            this.ApplicationName = applicationName;
            this.DateCreated = DateTime.UtcNow;
            this.LastModified = DateTime.UtcNow;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the application to which this data item belongs to.
        /// </summary>
        /// <value>The name of the application.</value>
        public string ApplicationName
        {
            get
            {
                return this.applicationName;
            }
            set
            {
                this.applicationName = value;
            }
        }

        /// <summary>
        /// The data provider this item was instantiated(retrieved or created) with.
        /// </summary>
        public object Provider
        {
            get
            {
                return this.provider;
            }
            set
            {
                this.provider = value;
            }
        }

        /// <summary>
        /// The transaction scope this item belongs to or null. This property is set by the specific forums provider implementation
        /// </summary>
        public object Transaction
        {
            get
            {
                return this.transaction;
            }
            set
            {
                this.transaction = value;
            }
        }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the time this item was last modified.
        /// </summary>
        /// <value>The last modified time.</value>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets the unique identity of the AnalyticsEvent.
        /// </summary>
        /// <value>The id.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the SiteId.
        /// </summary>
        public string SiteId { get; set; }

        /// <summary>
        /// Gets or sets the Signal.
        /// </summary>
        public string Signal { get; set; }

        /// <summary>
        /// Gets or sets the TrackingID.
        /// </summary>
        public string TrackingId { get; set; }

        /// <summary>
        /// Gets or sets the FormID.
        /// </summary>
        public string FormId { get; set; }

        /// <summary>
        /// Gets or sets the field name.
        /// </summary>
        public string FieldName { get; set; }

        #endregion

        #region Private fields and constants
        private string applicationName;
        private object provider;
        private object transaction;
        #endregion
    }
}