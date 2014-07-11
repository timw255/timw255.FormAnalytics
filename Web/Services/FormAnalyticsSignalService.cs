using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using timw255.FormAnalytics.Models;

namespace timw255.FormAnalytics.Web.Services
{
    [ServiceContract]
    [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FormAnalyticsSignalService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "addObject", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public void AddObject(AnalyticsSignal data)
        {
            FormAnalyticsManager manager = FormAnalyticsManager.GetManager();

            var item = manager.CreateAnalyticsEvent();

            item.Signal = data.Signal;
            item.SiteId = data.SiteId;
            item.TrackingId = data.TrackingId;
            item.FormId = data.FormId;
            item.FieldName = data.FieldName;

            manager.SaveChanges();
        }
    }
}