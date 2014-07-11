using System;
using System.Linq;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Decorators;
using timw255.FormAnalytics.Data.EntityFramework.Decorators;

namespace timw255.FormAnalytics.Data.EntityFramework
{
    [DataProviderDecorator(typeof(FormAnalyticsEFDataProviderDecorator))]
    public interface IFormAnalyticsEFDataProvider : IDataProviderBase
    {
        #region Methods
        /// <summary>
        /// Gets or sets the provider context.
        /// </summary>
        /// <value>The provider context.</value>
        FormAnalyticsEFDataProviderContext ProviderContext { get; set; }

        /// <summary>
        /// Gets the db context.
        /// </summary>
        /// <value>The db context.</value>
        FormAnalyticsEFDbContext Context { get; }
        #endregion
    }
}
