using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using Telerik.Sitefinity.Utilities.MS.ServiceModel.Web;
using Telerik.Sitefinity.Web.Services;
using timw255.FormAnalytics.Web.Services.AnalyticsEvents.ViewModels;

namespace timw255.FormAnalytics.Web.Services.AnalyticsEvents
{
    /// <summary>
    /// Provides contracts for loading and manipulating FormAnalytics data items (e.g. analyticsEvents)
    /// </summary>
    [ServiceContract]
    public interface IAnalyticsEventsService
    {
        /// <summary>
        /// Gets all analyticsEvents for the given provider. The results are returned in JSON format.
        /// </summary>
        /// <param name="provider">Name of the provider from which the analyticsEvents ought to be retrieved.</param>
        /// <param name="sortExpression">Sort expression used to order the analyticsEvents.</param>
        /// <param name="skip">Number of analyticsEvents to skip in result set. (used for paging)</param>
        /// <param name="take">Number of analyticsEvents to take in the result set. (used for paging)</param>
        /// <param name="filter">Dynamic LINQ expression used to filter the wanted result set.</param>
        /// <returns>
        /// Collection context object of <see cref="AnalyticsEventViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets all analyticsEvents of the FormAnalytics module for the given provider. The results are returned in JSON format.")]
        [WebGet(UriTemplate = "/?provider={provider}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        CollectionContext<AnalyticsEventViewModel> GetAnalyticsEvents(string provider, string sortExpression, int skip, int take, string filter);

        /// <summary>
        /// Gets all analyticsEvents for the given provider. The results are returned in XML format.
        /// </summary>
        /// <param name="provider">Name of the provider from which the analyticsEvents ought to be retrieved.</param>
        /// <param name="sortExpression">Sort expression used to order the analyticsEvents.</param>
        /// <param name="skip">Number of analyticsEvents to skip in result set. (used for paging)</param>
        /// <param name="take">Number of analyticsEvents to take in the result set. (used for paging)</param>
        /// <param name="filter">Dynamic LINQ expression used to filter the wanted result set.</param>
        /// <returns>
        /// Collection context object of <see cref="AnalyticsEventViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets all analyticsEvents of the FormAnalytics module for the given provider. The results are returned in XML format.")]
        [WebGet(UriTemplate = "/xml/?provider={provider}&sortExpression={sortExpression}&skip={skip}&take={take}&filter={filter}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        CollectionContext<AnalyticsEventViewModel> GetAnalyticsEventsInXml(string provider, string sortExpression, int skip, int take, string filter);

        /// <summary>
        /// Gets the analyticsEvent by it's id. The results are returned in JSON format.
        /// </summary>
        /// <param name="analyticsEventId">Id of the analyticsEvent to be retrieved.</param>
        /// <returns>
        /// Item context object of <see cref="AnalyticsEventViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets the analyticsEvent by it's id. The results are returned in JSON format.")]
        [WebGet(UriTemplate = "/{analyticsEventId}/", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ItemContext<AnalyticsEventViewModel> GetAnalyticsEvent(string analyticsEventId);

        /// <summary>
        /// Gets the analyticsEvent by it's id. The results are returned in JSON format.
        /// </summary>
        /// <param name="analyticsEventId">Id of the analyticsEvent to be retrieved.</param>
        /// <returns>
        /// Item context object of <see cref="AnalyticsEventViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Gets the analyticsEvent by it's id. The results are returned in JSON format.")]
        [WebGet(UriTemplate = "/xml/{analyticsEventId}/", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ItemContext<AnalyticsEventViewModel> GetAnalyticsEventInXml(string analyticsEventId);

        /// <summary>
        /// Saves a analyticsEvent. If the analyticsEvent with specified id exists that analyticsEvent will be updated; otherwise new analyticsEvent will be created.
        /// The saved analyticsEvent is returned in JSON format.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="analyticsEventId">The analyticsEvent id.</param>
        /// <param name="provider">The provider name through which the analyticsEvent ought to be saved.</param>
        /// <returns>The saved analyticsEvent.</returns>
        [WebHelp(Comment = "Saves a analyticsEvent. If the analyticsEvent with specified id exists that analyticsEvent will be updated; otherwise new analyticsEvent will be created. The saved analyticsEvent is returned in JSON format.")]
        [WebInvoke(Method = "PUT", UriTemplate = "/{analyticsEventId}/?provider={provider}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        ItemContext<AnalyticsEventViewModel> SaveAnalyticsEvent(ItemContext<AnalyticsEventViewModel> context, string analyticsEventId, string provider);

        /// <summary>
        /// Saves a analyticsEvent. If the analyticsEvent with specified id exists that analyticsEvent will be updated; otherwise new analyticsEvent will be created.
        /// The saved analyticsEvent is returned in XML format.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="analyticsEventId">The analyticsEvent id.</param>
        /// <param name="provider">The provider name through which the analyticsEvent ought to be saved.</param>
        /// <returns>The saved analyticsEvent.</returns>
        [WebHelp(Comment = "Saves a analyticsEvent. If the analyticsEvent with specified id exists that analyticsEvent will be updated; otherwise new analyticsEvent will be created. The saved analyticsEvent is returned in XML format.")]
        [WebInvoke(Method = "PUT", UriTemplate = "/xml/{analyticsEventId}/?provider={provider}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        ItemContext<AnalyticsEventViewModel> SaveAnalyticsEventInXml(ItemContext<AnalyticsEventViewModel> context, string analyticsEventId, string provider);

        /// <summary>
        /// Deletes the analyticsEvent.
        /// </summary>
        /// <param name="analyticsEventId">The analyticsEvent id.</param>
        /// <param name="provider">The provider.</param>
        [WebHelp(Comment = "Deletes the analyticsEvent.")]
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/{analyticsEventId}/?provider={provider}", ResponseFormat = WebMessageFormat.Json)]
        bool DeleteAnalyticsEvent(string analyticsEventId, string provider);

        /// <summary>
        /// Deletes the analyticsEvent.
        /// </summary>
        /// <param name="analyticsEventId">The analyticsEvent id.</param>
        /// <param name="provider">The provider.</param>
        [WebHelp(Comment = "Deletes the analyticsEvent.")]
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/xml/{analyticsEventId}/?provider={provider}", ResponseFormat = WebMessageFormat.Xml)]
        bool DeleteAnalyticsEventInXml(string analyticsEventId, string provider);

        /// <summary>
        /// Deletes a collection of analyticsEvents. Result is returned in JSON format.
        /// </summary>
        /// <param name="ids">An array of the ids of the analyticsEvents to delete.</param>
        /// <param name="provider">The name of the analyticsEvents provider.</param>
        /// <returns>True if all analyticsEvents have been deleted; otherwise false.</returns>
        [WebHelp(Comment = "Deletes multiple analyticsEvents.")]
        [WebInvoke(Method = "POST", UriTemplate = "/batch/?provider={provider}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool BatchDeleteAnalyticsEvents(string[] ids, string provider);

        /// <summary>
        /// Deletes a collection of analyticsEvents. Result is returned in XML format.
        /// </summary>
        /// <param name="ids">An array of the ids of the analyticsEvents to delete.</param>
        /// <param name="provider">The name of the analyticsEvents provider.</param>
        /// <returns>True if all analyticsEvents have been deleted; otherwise false.</returns>
        [WebHelp(Comment = "Deletes multiple analyticsEvents.")]
        [WebInvoke(Method = "POST", UriTemplate = "/xml/batch/?provider={provider}", ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool BatchDeleteAnalyticsEventsInXml(string[] ids, string provider);

        /// <summary>
        /// Gets the properties for the model. The results are returned in JSON format.
        /// </summary>
        /// <returns>
        /// Collection context object of <see cref="AnalyticsEventPropertyViewModel"/> objects.
        /// </returns>
        [WebHelp(Comment = "Get analyticsEvent properties.")]
        [WebGet(UriTemplate = "/model/properties/", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        CollectionContext<AnalyticsEventPropertyViewModel> GetProperties();

    }
}