using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace timw255.FormAnalytics.Web.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFormAnalyticsDataService" in both code and config file together.
    [ServiceContract]
    public interface IFormAnalyticsDataService
    {
        [OperationContract]
        void DoWork();
    }
}
