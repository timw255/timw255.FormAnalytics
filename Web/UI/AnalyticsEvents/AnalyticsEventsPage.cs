using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.Kendo;

namespace timw255.FormAnalytics.Web.UI.AnalyticsEvents
{
    /// <summary>
    /// Container for all the user interface of the FormAnalytics module.
    /// </summary>
    public class AnalyticsEventsPage : KendoView
    {
        #region Properties
        /// <summary>
        /// Obsolete. Use LayoutTemplatePath instead.
        /// </summary>
        protected override string LayoutTemplateName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the layout template's relative or virtual path.
        /// </summary>
        public override string LayoutTemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(base.LayoutTemplatePath))
                    base.LayoutTemplatePath = AnalyticsEventsPage.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.HtmlTextWriterTag" /> value that
        /// corresponds to this Web server control. This property is used primarily by control
        /// developers.
        /// </summary>
        /// <returns>One of the <see cref="T:System.Web.UI.HtmlTextWriterTag" /> enumeration values.</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                //we use div wrapper tag to make easier common styling
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Control references
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Initializes the controls.
        /// </summary>
        /// <param name="container"></param>
        /// <remarks>
        /// Initialize your controls in this method. Do not override CreateChildControls method.
        /// </remarks>
        protected override void InitializeControls(GenericContainer container)
        {
        }

        /// <summary>
        /// Gets a collection of <see cref="T:System.Web.UI.ScriptReference" /> objects
        /// that define script resources that the control requires.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerable" /> collection of <see cref="T:System.Web.UI.ScriptReference" />
        /// objects.
        /// </returns>
        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            var assemblyName = typeof(AnalyticsEventsPage).Assembly.FullName;

            scripts.Add(new ScriptReference(AnalyticsEventsPage.AnalyticsEventsDetailScript, assemblyName));
            scripts.Add(new ScriptReference(AnalyticsEventsPage.AnalyticsEventsMasterScript, assemblyName));
            scripts.Add(new ScriptReference(AnalyticsEventsPage.AnalyticsEventsPageScript, assemblyName));

            return scripts;
        }
        #endregion

        #region Private fields and constants
        private static readonly string layoutTemplatePath = string.Concat(FormAnalyticsModule.ModuleVirtualPath, "timw255.FormAnalytics.Web.UI.AnalyticsEvents.AnalyticsEventsPage.ascx");

        internal const string AnalyticsEventsPageScript = "timw255.FormAnalytics.Web.Scripts.AnalyticsEvents.AnalyticsEventsPage.js";
        internal const string AnalyticsEventsMasterScript = "timw255.FormAnalytics.Web.Scripts.AnalyticsEvents.AnalyticsEventsMaster.js";
        internal const string AnalyticsEventsDetailScript = "timw255.FormAnalytics.Web.Scripts.AnalyticsEvents.AnalyticsEventsDetail.js";
        #endregion
    }
}
