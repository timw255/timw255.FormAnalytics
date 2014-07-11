using System;
using System.Linq;
using System.Runtime.Serialization;

namespace timw255.FormAnalytics.Web.Services.AnalyticsEvents.ViewModels
{
    /// <summary>
    /// A view model for the analyticsEvent properties.
    /// This view model is used by the services.
    /// </summary>
    [DataContract]
    public class AnalyticsEventPropertyViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name
        {
            get;
            set;
        }
    }
}
