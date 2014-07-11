Type.registerNamespace("timw255.FormAnalytics.Widgets.Page.Designer");

timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner = function (element) {
    /* Initialize Message fields */
    this._message = null;
    
    /* Calls the base constructor */
    timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.initializeBase(this, [element]);
}

timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.prototype = {
    /* --------------------------------- set up and tear down --------------------------------- */
    initialize: function () {
        /* Here you can attach to events or do other initialization */
        timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        /* this is the place to unbind/dispose the event handlers created in the initialize method */
        timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.callBaseMethod(this, 'dispose');
    },

    /* --------------------------------- public methods ---------------------------------- */

    findElement: function (id) {
        var result = jQuery(this.get_element()).find("#" + id).get(0);
        return result;
    },

    /* Called when the designer window gets opened and here is place to "bind" your designer to the control properties */
    refreshUI: function () {
        var controlData = this._propertyEditor.get_control(); /* JavaScript clone of your control - all the control properties will be properties of the controlData too */

        /* RefreshUI Message */
        jQuery(this.get_message()).val(controlData.Message);
    },

    /* Called when the "Save" button is clicked. Here you can transfer the settings from the designer to the control */
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        /* ApplyChanges Message */
        controlData.Message = jQuery(this.get_message()).val();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    /* --------------------------------- properties -------------------------------------- */

    /* Message properties */
    get_message: function () { return this._message; }, 
    set_message: function (value) { this._message = value; }
}

timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner.registerClass('timw255.FormAnalytics.Widgets.Page.Designer.FormAnalyticsDataDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
