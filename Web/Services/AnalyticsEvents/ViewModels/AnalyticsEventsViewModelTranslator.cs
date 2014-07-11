using System;
using System.Linq;
using timw255.FormAnalytics.Models;

namespace timw255.FormAnalytics.Web.Services.AnalyticsEvents.ViewModels
{
    /// <summary>
    /// Provides methods for translating view models to models and vice versa for the FormAnalytics module.
    /// </summary>
    public static class AnalyticsEventsViewModelTranslator
    {
        #region AnalyticsEvent
        /// <summary>
        /// Translates AnalyticsEvent view model to AnalyticsEvent model.
        /// </summary>
        /// <param name="source">
        /// An instance of the <see cref="AnalyticsEventViewModel"/>.
        /// </param>
        /// <param name="target">
        /// An instance of the <see cref="AnalyticsEvent"/>.
        /// </param>
        public static void ToModel(AnalyticsEventViewModel source, AnalyticsEvent target, FormAnalyticsManager manager)
        {
            target.SiteId = source.SiteId;
            target.Signal = source.Signal;
            target.TrackingId = source.TrackingId;
            target.FormId = source.FormId;
            target.FieldName = source.FieldName;
        }

        /// <summary>
        /// Translates AnalyticsEvent to AnalyticsEvent view model.
        /// </summary>
        /// <param name="source">
        /// An instance of the <see cref="AnalyticsEvent"/>.
        /// </param>
        /// <param name="target">
        /// An instance of the <see cref="AnalyticsEventViewModel"/>.
        /// </param>
        public static void ToViewModel(AnalyticsEvent source, AnalyticsEventViewModel target, FormAnalyticsManager manager)
        {
            target.Id = source.Id;
            target.LastModified = source.LastModified;
            target.DateCreated = source.DateCreated;

            target.SiteId = source.SiteId;
            target.Signal = source.Signal;
            target.TrackingId = source.TrackingId;
            target.FormId = source.FormId;
            target.FieldName = source.FieldName;
        }
        #endregion
    }
}
