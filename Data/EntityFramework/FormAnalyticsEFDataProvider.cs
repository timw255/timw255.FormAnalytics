using System;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using Telerik.Microsoft.Practices.Unity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Data.Decorators;
using timw255.FormAnalytics.Data.EntityFramework.Decorators;
using timw255.FormAnalytics.Models;


namespace timw255.FormAnalytics.Data.EntityFramework
{
    public class FormAnalyticsEFDataProvider : FormAnalyticsDataProvider, IFormAnalyticsEFDataProvider
    {
        #region FormAnalyticsDataProvider
        protected override void Initialize(string providerName, NameValueCollection config, Type managerType, bool initializeDecorator)
        {
            if (!ObjectFactory.IsTypeRegistered(typeof(FormAnalyticsEFDataProviderDecorator)))
                ObjectFactory.Container.RegisterType<IDataProviderDecorator, FormAnalyticsEFDataProviderDecorator>(typeof(FormAnalyticsEFDataProviderDecorator).FullName);

            base.Initialize(providerName, config, managerType, initializeDecorator);
        }

        public override IQueryable<AnalyticsEvent> GetAnalyticsEvents()
        {
            return this.Context.AnalyticsEvents.Where(p => p.ApplicationName == this.ApplicationName);
        }

        public override AnalyticsEvent GetAnalyticsEvent(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be Empty Guid");

            return this.Context.AnalyticsEvents.Find(id);
        }

        public override AnalyticsEvent CreateAnalyticsEvent()
        {
            Guid id = Guid.NewGuid();
            var item = new AnalyticsEvent(id, this.ApplicationName);

            return this.Context.AnalyticsEvents.Add(item);
        }

        public override void UpdateAnalyticsEvent(AnalyticsEvent entity)
        {
            var context = this.Context;

            if (context.Entry(entity).State == EntityState.Detached)
                context.AnalyticsEvents.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;
        }

        public override void DeleteAnalyticsEvent(AnalyticsEvent entity)
        {
            var context = this.Context;

            if (context.Entry(entity).State == EntityState.Detached)
                context.AnalyticsEvents.Attach(entity);

            context.AnalyticsEvents.Remove(entity);
        }
        #endregion

        #region IFormAnalyticsEFDataProvider
        public FormAnalyticsEFDataProviderContext ProviderContext { get; set; }

        public FormAnalyticsEFDbContext Context
        {
            get
            {
                return (FormAnalyticsEFDbContext)this.GetTransaction();
            }
        }
        #endregion
    }
}