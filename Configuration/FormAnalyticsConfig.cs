using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Web.Configuration;
using timw255.FormAnalytics.Data.EntityFramework;

namespace timw255.FormAnalytics.Configuration
{
    /// <summary>
    /// Represents the configuration section for FormAnalytics module.
    /// </summary>
    [ObjectInfo(Title = "FormAnalytics Config Title", Description = "FormAnalytics Config Description")]
    public class FormAnalyticsConfig : ModuleConfigBase
    {
        #region Public and overriden methods
        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(providers)
            {
                Name = "FormAnalyticsEFDataProvider",
                Title = "Default Products",
                Description = "A provider that stores products data in database using Entity Framework.",
                ProviderType = typeof(FormAnalyticsEFDataProvider),
                Parameters = new NameValueCollection() { { "applicationName", "/FormAnalytics" } }
            });
        }

        /// <summary>
        /// Gets or sets the name of the default data provider. 
        /// </summary>
        [DescriptionResource(typeof(ConfigDescriptions), "DefaultProvider")]
        [ConfigurationProperty("defaultProvider", DefaultValue = "FormAnalyticsEFDataProvider")]
        public override string DefaultProvider
        {
            get
            {
                return (string)this["defaultProvider"];
            }
            set
            {
                this["defaultProvider"] = value;
            }
        }
        #endregion
    }
}