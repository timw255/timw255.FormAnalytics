using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace timw255.FormAnalytics.Models
{
    [DataContract]
    public class AnalyticsSignal
    {
        [DataMember(Name="site_id")]
        public string SiteId { get; set; }

        [DataMember(Name = "signal")]
        public string Signal { get; set; }

        [DataMember(Name = "form_id")]
        public string FormId { get; set; }

        [DataMember(Name = "field_name")]
        public string FieldName { get; set; }

        [DataMember(Name = "tracking_id")]
        public string TrackingId { get; set; }
    }
}
