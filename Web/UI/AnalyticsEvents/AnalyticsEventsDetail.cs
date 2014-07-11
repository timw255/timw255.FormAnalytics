using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;

namespace timw255.FormAnalytics.Web.UI.AnalyticsEvents
{
    /// <summary>
    /// This control provides user interface for creating and editing analyticsEvent definitions.
    /// </summary>
    public class AnalyticsEventsDetail : SimpleView
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
                    base.LayoutTemplatePath = AnalyticsEventsDetail.layoutTemplatePath;
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
        #endregion

        #region Private fields and constants
        private static readonly string layoutTemplatePath = string.Concat(FormAnalyticsModule.ModuleVirtualPath, "timw255.FormAnalytics.Web.UI.AnalyticsEvents.AnalyticsEventsDetail.ascx");
        #endregion
    }
}
