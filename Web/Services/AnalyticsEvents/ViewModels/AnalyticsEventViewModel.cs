using System;
using System.Runtime.Serialization;
using Telerik.Sitefinity.Localization;

namespace timw255.FormAnalytics.Web.Services.AnalyticsEvents.ViewModels
{
    /// <summary>
    /// A view model for the AnalyticsEvent class.
    /// This view model is used by the services.
    /// </summary>
    [DataContract]
    public class AnalyticsEventViewModel
    {
        #region Properties
        /// <summary>
        /// Gets the unique identity of the data item.
        /// </summary>
        /// <value>The id.</value>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>The last modified.</value>
        [DataMember]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>The date created.</value>
        [DataMember]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the SiteId.
        /// </summary>
        [DataMember]
        public string SiteId { get; set; }

        /// <summary>
        /// Gets or sets the Signal.
        /// </summary>
        [DataMember]
        public string Signal { get; set; }

        /// <summary>
        /// Gets or sets the TrackingID.
        /// </summary>
        [DataMember]
        public string TrackingId { get; set; }

        /// <summary>
        /// Gets or sets the FormId.
        /// </summary>
        [DataMember]
        public string FormId { get; set; }

        /// <summary>
        /// Gets or sets the FieldName.
        /// </summary>
        [DataMember]
        public string FieldName { get; set; }

        #endregion

        #region Labels and messages
        /// <summary>
        /// Gets the localized text for "actions" label
        /// </summary>
        [DataMember]
        public string ActionsLabel
        {
            get
            {
                return Res.Get<FormAnalyticsResources>().ActionsLabel;
            }
            set
            {
                // do nothing; serializer requirement
            }
        }

        /// <summary>
        /// Gets the localized text for the "delete" label
        /// </summary>
        [DataMember]
        public string DeleteLabel
        {
            get
            {
                return Res.Get<FormAnalyticsResources>().DeleteLabel;
            }
            set
            {
                // do nothing; serializer requirement
            }
        }
        #endregion
    }
}