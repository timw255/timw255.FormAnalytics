using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Fluent.Modules;
using Telerik.Sitefinity.Fluent.Modules.Toolboxes;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;
using timw255.FormAnalytics.Configuration;
using timw255.FormAnalytics.Models;
using timw255.FormAnalytics.Web.Services;
using timw255.FormAnalytics.Web.Services.AnalyticsEvents;
using timw255.FormAnalytics.Web.UI.AnalyticsEvents;
using timw255.FormAnalytics.Widgets.Page;

namespace timw255.FormAnalytics
{
    /// <summary>
    /// Custom Sitefinity content module 
    /// </summary>
    public class FormAnalyticsModule : ModuleBase
    {
        #region Properties
        /// <summary>
        /// Gets the landing page id for the module.
        /// </summary>
        /// <value>The landing page id.</value>
        public override Guid LandingPageId
        {
            get
            {
                return FormAnalyticsModule.AnalyticsEventHomePageId;
            }
        }

        /// <summary>
        /// Gets the CLR types of all data managers provided by this module.
        /// </summary>
        /// <value>An array of <see cref="T:System.Type" /> objects.</value>
        public override Type[] Managers
        {
            get
            {
                return FormAnalyticsModule.managerTypes;
            }
        }
        #endregion

        #region Module Initialization
        /// <summary>
        /// Initializes the service with specified settings.
        /// This method is called every time the module is initializing (on application startup by default)
        /// </summary>
        /// <param name="settings">The settings.</param>
        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);

            // Add your initialization logic here

            App.WorkWith()
                .Module(settings.Name)
                    .Initialize()
                    .Localization<FormAnalyticsResources>()
                    .Configuration<FormAnalyticsConfig>()
                    .WebService<AnalyticsEventsService>(FormAnalyticsModule.AnalyticsEventsWebServiceUrl)
                    .WebService<FormAnalyticsSignalService>(FormAnalyticsModule.AnalyticsSignalWebServiceUrl)
                    .WebService<FormAnalyticsDataService>(FormAnalyticsModule.AnalyticsDataWebServiceUrl);

            // Here is also the place to register to some Sitefinity specific events like Bootstrapper.Initialized or subscribe for an event in with the EventHub class            
            // Please refer to the documentation for additional information http://www.sitefinity.com/documentation/documentationarticles/developers-guide/deep-dive/sitefinity-event-system/ieventservice-and-eventhub
        }

        /// <summary>
        /// Installs this module in Sitefinity system for the first time.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        public override void Install(SiteInitializer initializer)
        {
            this.InstallVirtualPaths(initializer);
            //this.InstallBackendPages(initializer);
            InstallPageWidgets(initializer);
        }

        /// <summary>
        /// Upgrades this module from the specified version.
        /// This method is called instead of the Install method when the module is already installed with a previous version.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        /// <param name="upgradeFrom">The version this module us upgrading from.</param>
        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        {
            // Here you can check which one is your prevous module version and execute some code if you need to
            // See the example bolow
            //
            //if (upgradeFrom < new Version("1.0.1.0"))
            //{
            //    some upgrade code that your new version requires
            //}
        }

        /// <summary>
        /// Uninstalls the specified initializer.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        public override void Uninstall(SiteInitializer initializer)
        {
            base.Uninstall(initializer);
            // Add your uninstall logic here
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the module configuration.
        /// </summary>
        protected override ConfigSection GetModuleConfig()
        {
            return Config.Get<FormAnalyticsConfig>();
        }
        #endregion

        #region Virtual paths
        /// <summary>
        /// Installs module virtual paths.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallVirtualPaths(SiteInitializer initializer)
        {
            // Here you can register your module virtual paths

            var virtualPaths = initializer.Context.GetConfig<VirtualPathSettingsConfig>().VirtualPaths;
            var moduleVirtualPath = FormAnalyticsModule.ModuleVirtualPath + "*";
            if (!virtualPaths.ContainsKey(moduleVirtualPath))
            {
                virtualPaths.Add(new VirtualPathElement(virtualPaths)
                {
                    VirtualPath = moduleVirtualPath,
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = typeof(FormAnalyticsModule).Assembly.GetName().Name
                });
            }
        }
        #endregion

        #region Install backend pages
        /// <summary>
        /// Installs the backend pages.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallBackendPages(SiteInitializer initializer)
        {
            // Using our Fluent Api you can add your module backend pages hierarchy in no time
            // Here is an example using resources to localize the title of the page and adding a dummy control
            // to the module page.

            //initializer.Installer
            //    .CreateModuleGroupPage(FormAnalyticsModule.AnalyticsEventGroupPageId, "AnalyticsEvent")
            //        .PlaceUnder(CommonNode.TypesOfContent)
            //        .LocalizeUsing<FormAnalyticsResources>()
            //        .SetTitleLocalized("AnalyticsEventGroupPageTitle")
            //        .SetUrlNameLocalized("AnalyticsEventGroupPageUrlName")
            //        .SetDescriptionLocalized("AnalyticsEventGroupPageDescription")
            //        .ShowInNavigation()
            //        .AddChildPage(FormAnalyticsModule.AnalyticsEventHomePageId, "AnalyticsEvent")
            //            .LocalizeUsing<FormAnalyticsResources>()
            //            .SetTitleLocalized("AnalyticsEventGroupPageTitle")
            //            .SetHtmlTitleLocalized("AnalyticsEventGroupPageTitle")
            //            .SetUrlNameLocalized("AnalyticsEventMasterPageUrl")
            //            .SetDescriptionLocalized("AnalyticsEventGroupPageDescription")
            //            .AddControl(new AnalyticsEventsPage())
            //            .HideFromNavigation()
            //        .Done()
            //    .Done();
        }
        #endregion

        #region Widgets
        /// <summary>
        /// Installs the form widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallFormWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom form widgets in the toolbox.
            // See the example below.

            //string moduleFormWidgetSectionName = "FormAnalytics";
            //string moduleFormWidgetSectionTitle = "FormAnalytics";
            //string moduleFormWidgetSectionDescription = "FormAnalytics";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.FormWidgets)
            //        .LoadOrAddSection(moduleFormWidgetSectionName)
            //            .SetTitle(moduleFormWidgetSectionTitle)
            //            .SetDescription(moduleFormWidgetSectionDescription)
            //            .LoadOrAddWidget<WidgetType>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<FormAnalyticsResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (this is optional)
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the layout widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallLayoutWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom layout widgets in the toolbox.
            // See the example below.

            //string moduleLayoutWidgetSectionName = "FormAnalytics";
            //string moduleLayoutWidgetSectionTitle = "FormAnalytics";
            //string moduleLayoutWidgetSectionDescription = "FormAnalytics";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.Layouts)
            //        .LoadOrAddSection(moduleLayoutWidgetSectionName)
            //            .SetTitle(moduleLayoutWidgetSectionTitle)
            //            .SetDescription(moduleLayoutWidgetSectionDescription)
            //            .LoadOrAddWidget<LayoutControl>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<FormAnalyticsResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
            //                .SetParameters(new NameValueCollection() 
            //                { 
            //                    { "layoutTemplate", FullPathToTheLayoutWidget },
            //                })
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the page widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallPageWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom page widgets in the toolbox.
            // See the example below.

            string modulePageWidgetSectionName = "FormAnalytics";
            string modulePageWidgetSectionTitle = "Form Analytics";
            string modulePageWidgetSectionDescription = "Form Analytics";

            initializer.Installer
                .Toolbox(CommonToolbox.PageWidgets)
                    .LoadOrAddSection(modulePageWidgetSectionName)
                        .SetTitle(modulePageWidgetSectionTitle)
                        .SetDescription(modulePageWidgetSectionDescription)
                        .LoadOrAddWidget<FormAnalyticsData>("FormAnalyticsData")
                            .SetTitle("Form Analytics Data")
                            .SetDescription("Form Analytics Data")
                            .LocalizeUsing<FormAnalyticsResources>()
                            .SetCssClass("sfStatisticsIcn")
                        .Done()
                    .Done()
                .Done();
        }
        #endregion

        #region Upgrade methods
        #endregion

        #region Private members & constants
        public const string ModuleName = "FormAnalytics";
        internal const string ModuleTitle = "Form Analytics";
        internal const string ModuleDescription = "Provides form analytics and reporting tools";
        internal const string ModuleVirtualPath = "~/FormAnalytics/";

        private static readonly Type[] managerTypes = new Type[] { typeof(FormAnalyticsManager) };

        // Services
        public const string AnalyticsEventsWebServiceUrl = "Sitefinity/Services/FormAnalytics/AnalyticsEvents.svc/";
        public const string AnalyticsSignalWebServiceUrl = "Sitefinity/Services/FormAnalytics/AnalyticsSignal.svc/";
        public const string AnalyticsDataWebServiceUrl = "Sitefinity/Services/FormAnalytics/AnalyticsData.svc/";

        // Pages
        internal static readonly Guid AnalyticsEventGroupPageId = new Guid("a7fb8ef7-68b8-4366-8c83-e7f5ae511183");
        internal static readonly Guid AnalyticsEventHomePageId = new Guid("15b16d24-93f8-4ff7-ae72-c3014453543f");
        #endregion
    }
}