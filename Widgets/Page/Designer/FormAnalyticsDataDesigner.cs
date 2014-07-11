using System;
using System.Linq;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Collections.Generic;

[assembly: WebResource(timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.scriptReference, "application/x-javascript")]
namespace timw255.FormAnalytics.Widgets.Page.Designer
{
    /// <summary>
    /// Represents a designer for the <typeparamref name="timw255.FormAnalytics.Widgets.Page.FormAnalyticsData"/> widget
    /// </summary>
    public class FormAnalyticsDataDesigner : ControlDesignerBase
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
                    return FormAnalyticsDataDesigner.layoutTemplatePath;
                return base.LayoutTemplatePath;
            }
            set
            {
                base.LayoutTemplatePath = value;
            }
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Control references
        /// <summary>
        /// Gets the control that is bound to the Message property
        /// </summary>
        protected virtual Control Message
        {
            get
            {
                return this.Container.GetControl<Control>("Message", true);
            }
        }

        #endregion

        #region Methods
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            // Place your initialization logic here
        }
        #endregion

        #region IScriptControl implementation
        /// <summary>
        /// Gets a collection of script descriptors that represent ECMAScript (JavaScript) client components.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptDescriptor> GetScriptDescriptors()
        {
            var scriptDescriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)scriptDescriptors.Last();

            descriptor.AddElementProperty("message", this.Message.ClientID);

            return scriptDescriptors;
        }

        /// <summary>
        /// Gets a collection of ScriptReference objects that define script resources that the control requires.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<System.Web.UI.ScriptReference> GetScriptReferences()
        {
            var scripts = new List<ScriptReference>(base.GetScriptReferences());
            scripts.Add(new ScriptReference(FormAnalyticsDataDesigner.scriptReference, typeof(FormAnalyticsDataDesigner).Assembly.FullName));
            return scripts;
        }
        #endregion

        #region Private members & constants
        public static readonly string layoutTemplatePath = FormAnalyticsModule.ModuleVirtualPath + "timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.ascx";
        public const string scriptReference = "timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.js";
        #endregion
    }
}
 
