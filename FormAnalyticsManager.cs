using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using timw255.FormAnalytics.Configuration;
using timw255.FormAnalytics.Models;

namespace timw255.FormAnalytics
{
    public class FormAnalyticsManager : ManagerBase<FormAnalyticsDataProvider>
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="FormAnalyticsManager" /> class.
        /// </summary>
        public FormAnalyticsManager()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAnalyticsManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        public FormAnalyticsManager(string providerName)
            : base(providerName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FormAnalyticsManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        public FormAnalyticsManager(string providerName, string transactionName)
            : base(providerName, transactionName)
        {
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the default provider delegate.
        /// </summary>
        /// <value>The default provider delegate.</value>
        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get
            {
                return () => Config.Get<FormAnalyticsConfig>().DefaultProvider;
            }
        }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        public override string ModuleName
        {
            get
            {
                return FormAnalyticsModule.ModuleName;
            }
        }

        /// <summary>
        /// Gets the providers settings.
        /// </summary>
        /// <value>The providers settings.</value>
        protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
        {
            get
            {
                return Config.Get<FormAnalyticsConfig>().Providers;
            }
        }

        /// <summary>
        /// Get an instance of the timw255.FormAnalytics manager using the default provider.
        /// </summary>
        /// <returns>Instance of the timw255.FormAnalytics manager</returns>
        public static FormAnalyticsManager GetManager()
        {
            return ManagerBase<FormAnalyticsDataProvider>.GetManager<FormAnalyticsManager>();
        }

        /// <summary>
        /// Get an instance of the timw255.FormAnalytics manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <returns>Instance of the timw255.FormAnalytics manager</returns>
        public static FormAnalyticsManager GetManager(string providerName)
        {
            return ManagerBase<FormAnalyticsDataProvider>.GetManager<FormAnalyticsManager>(providerName);
        }

        /// <summary>
        /// Get an instance of the timw255.FormAnalytics manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        /// <returns>Instance of the timw255.FormAnalytics manager</returns>
        public static FormAnalyticsManager GetManager(string providerName, string transactionName)
        {
            return ManagerBase<FormAnalyticsDataProvider>.GetManager<FormAnalyticsManager>(providerName, transactionName);
        }

        /// <summary>
        /// Creates a AnalyticsEvent.
        /// </summary>
        /// <returns>The created AnalyticsEvent.</returns>
        public AnalyticsEvent CreateAnalyticsEvent()
        {
            return this.Provider.CreateAnalyticsEvent();
        }

        /// <summary>
        /// Updates the AnalyticsEvent.
        /// </summary>
        /// <param name="entity">The AnalyticsEvent entity.</param>
        public void UpdateAnalyticsEvent(AnalyticsEvent entity)
        {
            this.Provider.UpdateAnalyticsEvent(entity);
        }

        /// <summary>
        /// Deletes the AnalyticsEvent.
        /// </summary>
        /// <param name="entity">The AnalyticsEvent entity.</param>
        public void DeleteAnalyticsEvent(AnalyticsEvent entity)
        {
            this.Provider.DeleteAnalyticsEvent(entity);
        }

        /// <summary>
        /// Gets the AnalyticsEvent by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The AnalyticsEvent.</returns>
        public AnalyticsEvent GetAnalyticsEvent(Guid id)
        {
            return this.Provider.GetAnalyticsEvent(id);
        }

        /// <summary>
        /// Gets a query of all the AnalyticsEvent items.
        /// </summary>
        /// <returns>The AnalyticsEvent items.</returns>
        public IQueryable<AnalyticsEvent> GetAnalyticsEvents()
        {
            return this.Provider.GetAnalyticsEvents();
        }
        #endregion
    }
}