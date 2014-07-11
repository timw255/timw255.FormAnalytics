using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using Telerik.Sitefinity.Web.Services;
using timw255.FormAnalytics.Models;
using timw255.FormAnalytics.Web.Services.AnalyticsEvents.ViewModels;

namespace timw255.FormAnalytics.Web.Services.AnalyticsEvents
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class AnalyticsEventsService : IAnalyticsEventsService
    {
        #region IAnalyticsEvents
        /// <inheritdoc/>
        public CollectionContext<AnalyticsEventViewModel> GetAnalyticsEvents(string provider, string sortExpression, int skip, int take, string filter)
        {
            ServiceUtility.DisableCache();
            return this.GetAnalyticsEventsInternal(provider, sortExpression, skip, take, filter);
        }

        /// <inheritdoc/>
        public CollectionContext<AnalyticsEventViewModel> GetAnalyticsEventsInXml(string provider, string sortExpression, int skip, int take, string filter)
        {
            ServiceUtility.DisableCache();
            return this.GetAnalyticsEventsInternal(provider, sortExpression, skip, take, filter);
        }

        /// <inheritdoc/>
        public ItemContext<AnalyticsEventViewModel> SaveAnalyticsEvent(ItemContext<AnalyticsEventViewModel> context, string analyticsEventId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.SaveAnalyticsEventInternal(context, analyticsEventId, provider);
        }

        /// <inheritdoc/>
        public ItemContext<AnalyticsEventViewModel> SaveAnalyticsEventInXml(ItemContext<AnalyticsEventViewModel> context, string analyticsEventId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.SaveAnalyticsEventInternal(context, analyticsEventId, provider);
        }

        /// <inheritdoc/>
        public bool DeleteAnalyticsEvent(string analyticsEventId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.DeleteAnalyticsEventInternal(analyticsEventId, provider);
        }

        /// <inheritdoc/>
        public bool DeleteAnalyticsEventInXml(string analyticsEventId, string provider)
        {
            ServiceUtility.DisableCache();
            return this.DeleteAnalyticsEventInternal(analyticsEventId, provider);
        }

        /// <inheritdoc/>
        public bool BatchDeleteAnalyticsEvents(string[] ids, string provider)
        {
            ServiceUtility.DisableCache();
            return this.BatchDeleteAnalyticsEventsInternal(ids, provider);
        }

        /// <inheritdoc/>
        public bool BatchDeleteAnalyticsEventsInXml(string[] ids, string provider)
        {
            ServiceUtility.DisableCache();
            return this.BatchDeleteAnalyticsEventsInternal(ids, provider);
        }

        /// <inheritdoc/>
        public ItemContext<AnalyticsEventViewModel> GetAnalyticsEvent(string analyticsEventId)
        {
            ServiceUtility.DisableCache();
            return this.GetAnalyticsEventInternal(analyticsEventId);
        }

        /// <inheritdoc/>
        public ItemContext<AnalyticsEventViewModel> GetAnalyticsEventInXml(string analyticsEventId)
        {
            ServiceUtility.DisableCache();
            return this.GetAnalyticsEventInternal(analyticsEventId);
        }

        /// <inheritdoc/>
        public CollectionContext<AnalyticsEventPropertyViewModel> GetProperties()
        {
            ServiceUtility.DisableCache();
            return this.GetPropertiesInternal();
        }
        #endregion

        #region Non-public methods
        /// <summary>
        /// Gets the analyticsEvents internal.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private CollectionContext<AnalyticsEventViewModel> GetAnalyticsEventsInternal(string provider, string sortExpression, int skip, int take, string filter)
        {
            var manager = FormAnalyticsManager.GetManager(provider);
            var analyticsEvents = manager.GetAnalyticsEvents();

            var totalCount = analyticsEvents.Count();

            if (!string.IsNullOrEmpty(sortExpression))
                analyticsEvents = analyticsEvents.OrderBy(sortExpression);

            if (!string.IsNullOrEmpty(filter))
                analyticsEvents = analyticsEvents.Where(filter);

            if (skip > 0)
                analyticsEvents = analyticsEvents.Skip(skip);

            if (take > 0)
                analyticsEvents = analyticsEvents.Take(take);

            var analyticsEventsList = new List<AnalyticsEventViewModel>();

            foreach (var analyticsEvent in analyticsEvents)
            {
                var analyticsEventViewModel = new AnalyticsEventViewModel();
                AnalyticsEventsViewModelTranslator.ToViewModel(analyticsEvent, analyticsEventViewModel, manager);
                analyticsEventsList.Add(analyticsEventViewModel);
            }

            return new CollectionContext<AnalyticsEventViewModel>(analyticsEventsList) { TotalCount = totalCount };
        }

        /// <summary>
        /// Saves the analyticsEvent internal.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="analyticsEventId">The analyticsEvent id.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private ItemContext<AnalyticsEventViewModel> SaveAnalyticsEventInternal(ItemContext<AnalyticsEventViewModel> context, string analyticsEventId, string provider)
        {
            var manager = FormAnalyticsManager.GetManager(provider);
            var id = new Guid(analyticsEventId);

            AnalyticsEvent analyticsEvent = null;

            if (id == Guid.Empty)
                analyticsEvent = manager.CreateAnalyticsEvent();
            else
                analyticsEvent = manager.GetAnalyticsEvent(id);

            AnalyticsEventsViewModelTranslator.ToModel(context.Item, analyticsEvent, manager);

            if (id != Guid.Empty)
                manager.UpdateAnalyticsEvent(analyticsEvent);

            manager.SaveChanges();
            AnalyticsEventsViewModelTranslator.ToViewModel(analyticsEvent, context.Item, manager);
            return context;
        }

        /// <summary>
        /// Deletes the analyticsEvent internal.
        /// </summary>
        /// <param name="analyticsEventId">The analyticsEvent id.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private bool DeleteAnalyticsEventInternal(string analyticsEventId, string provider)
        {
            var manager = FormAnalyticsManager.GetManager(provider);
            manager.DeleteAnalyticsEvent(manager.GetAnalyticsEvent(new Guid(analyticsEventId)));
            manager.SaveChanges();

            return true;
        }

        /// <summary>
        /// Batches the delete analyticsEvents internal.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private bool BatchDeleteAnalyticsEventsInternal(string[] ids, string provider)
        {
            var manager = FormAnalyticsManager.GetManager(provider);
            foreach (var stringId in ids)
            {
                var analyticsEventId = new Guid(stringId);
                manager.DeleteAnalyticsEvent(manager.GetAnalyticsEvent(analyticsEventId));
            }
            manager.SaveChanges();

            return true;
        }

        /// <summary>
        /// Gets the analyticsEvent internal.
        /// </summary>
        /// <param name="analyticsEventId">The analyticsEvent id.</param>
        /// <returns></returns>
        private ItemContext<AnalyticsEventViewModel> GetAnalyticsEventInternal(string analyticsEventId)
        {
            var analyticsEventIdGuid = new Guid(analyticsEventId);
            var manager = FormAnalyticsManager.GetManager();

            var analyticsEvent = manager.GetAnalyticsEvent(analyticsEventIdGuid);
            var analyticsEventViewModel = new AnalyticsEventViewModel();
            AnalyticsEventsViewModelTranslator.ToViewModel(analyticsEvent, analyticsEventViewModel, manager);

            return new ItemContext<AnalyticsEventViewModel>()
            {
                Item = analyticsEventViewModel
            };
        }

        /// <summary>
        /// Gets the properties internal.
        /// </summary>
        /// <returns></returns>
        private CollectionContext<AnalyticsEventPropertyViewModel> GetPropertiesInternal()
        {
            List<AnalyticsEventPropertyViewModel> properties = new List<AnalyticsEventPropertyViewModel>();
            foreach (var property in typeof(timw255.FormAnalytics.Models.AnalyticsEvent).GetProperties())
            {
                if (!this.systemProperties.Contains(property.Name))
                {
                    properties.Add(new AnalyticsEventPropertyViewModel() { Name = property.Name });
                }
            }
            return new CollectionContext<AnalyticsEventPropertyViewModel>(properties) { TotalCount = properties.Count() };
        }
        #endregion

        #region Non-public Fields
        private readonly IEnumerable<string> systemProperties = new List<string>()
        {
            "Id", "Transaction", "ApplicationName", "Provider",
        };
        #endregion
    }
}