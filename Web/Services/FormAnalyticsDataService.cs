using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace timw255.FormAnalytics.Web.Services
{
    [ServiceContract]
    [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FormAnalyticsDataService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "fieldData", ResponseFormat = WebMessageFormat.Json)]
        public List<DataSequenceItem> FieldData()
        {
            FormAnalyticsManager manager = FormAnalyticsManager.GetManager();

            var data = manager.GetAnalyticsEvents();

            var fields = data.Select(ae => ae.FieldName).Distinct().ToArray();

            List<DataSequenceItem> response = new List<DataSequenceItem>();

            var random = new Random();

            for (var i = 0; i < fields.Count(); i++)
            {
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                string fn = fields[i];
                response.Add(new DataSequenceItem() { FieldName = fn, Count = data.Where(ae => ae.FieldName == fn && ae.Signal == "FieldCompleted").Count() });
            }


            return response;
        }
    }

    [DataContract]
    public class DataSequenceItem
    {
        [DataMember(Name="field_name")]
        public string FieldName { get; set; }

        [DataMember(Name="count")]
        public int Count { get; set; }

        [DataMember(Name = "color", EmitDefaultValue = false)]
        public string Color { get; set; }
    }
}
