using System;
using System.Linq;
using Telerik.Sitefinity.Data;
using timw255.FormAnalytics.Models;

namespace timw255.FormAnalytics
{
    public abstract class FormAnalyticsDataProvider : DataProviderBase
    {
        #region Public and overriden methods
        /// <summary>
        /// Gets the known types.
        /// </summary>
        public override Type[] GetKnownTypes()
        {
            if (knownTypes == null)
            {
                knownTypes = new Type[]
                {
                    typeof(AnalyticsEvent)
                };
            }
            return knownTypes;
        }

        /// <summary>
        /// Gets the root key.
        /// </summary>
        /// <value>The root key.</value>
        public override string RootKey
        {
            get
            {
                return "FormAnalyticsDataProvider";
            }
        }
        #endregion

        #region Abstract methods
        /// <summary>
        /// Creates a new AnalyticsEvent and returns it.
        /// </summary>
        /// <returns>The new AnalyticsEvent.</returns>
        public abstract AnalyticsEvent CreateAnalyticsEvent();

        /// <summary>
        /// Gets a AnalyticsEvent by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The AnalyticsEvent.</returns>
        public abstract AnalyticsEvent GetAnalyticsEvent(Guid id);

        /// <summary>
        /// Gets a query of all the AnalyticsEvent items.
        /// </summary>
        /// <returns>The AnalyticsEvent items.</returns>
        public abstract IQueryable<AnalyticsEvent> GetAnalyticsEvents();

        /// <summary>
        /// Updates the AnalyticsEvent.
        /// </summary>
        /// <param name="entity">The AnalyticsEvent entity.</param>
        public abstract void UpdateAnalyticsEvent(AnalyticsEvent entity);

        /// <summary>
        /// Deletes the AnalyticsEvent.
        /// </summary>
        /// <param name="entity">The AnalyticsEvent entity.</param>
        public abstract void DeleteAnalyticsEvent(AnalyticsEvent entity);
        #endregion

        #region Private fields and constants
        private static Type[] knownTypes;
        #endregion
    }
}