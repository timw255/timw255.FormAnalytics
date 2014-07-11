var AnalyticsEventsDetail = kendo.Class.extend({

    /* --------------------------------- Construction ------------------------------------ */

    init: function (form, dataSource, webServiceUrl) {
        form.kendoWindow({
            animation: false,
            modal: true,
            visible: false
        });
        form.parent().addClass("sfMaximizedWindow")
        this._formWindow = form.data("kendoWindow");
        this._dataSource = dataSource;
        this._webServiceUrl = webServiceUrl;
        $(this._formElements.timestamp).kendoDateTimePicker({ 
			animation: false,
			format: "MM/dd/yyyy HH:mm",
            timeFormat: "HH:mm"
		});
    },

    /* --------------------------------- public methods ---------------------------------- */

    show: function (id) {
        var that = this;
        this.reset();
        this.get_window().open();
        this.get_window().maximize();
        if (id) {
			$.ajax({
                type: 'GET',
                url: this.get_webServiceUrl() + id + "/",
                cache: false,
            }).done(function (data) {
                that.load(data.Item);
            });
            $("#createAnalyticsEventButtonText").hide();
            $("#saveChangesAnalyticsEventButtonText").show();
        }
        else {
            $("#createAnalyticsEventButtonText").show();
            $("#saveChangesAnalyticsEventButtonText").hide();
        }
    },

    close: function () {
        this.get_window().close();
    },

    load: function (data) {
        $(this._formElements.title).val(data.Title);
        $(this._formElements.siteID).val(data.SiteID);
        $(this._formElements.type).val(data.Type);
        $(this._formElements.timestamp).getKendoDateTimePicker().value(new Date(parseInt(data.Timestamp.substr(6))));
        $(this._formElements.trackingID).val(data.TrackingID);
        this.set_id(data.Id);
    },

    save: function () {
        if (this.isValid()) {
            var data = this._getFormData();
            var that = this;
            $.ajax({
                type: 'PUT',
                url: that.get_webServiceUrl() + that.get_id() + "/",
                contentType: "application/json",
                processData: false,
                data: JSON.stringify(data),
                success: function (result, args) {
                    that.close();
                    that.get_dataSource().read();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(Telerik.Sitefinity.JSON.parse(jqXHR.responseText).Detail);
                }
            });
        }
    },

    isValid: function () {
        var isValid = true;

        if ($(this._formElements.title).val().length == 0) {
            $(this._formElements.titleValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.titleValidator).hide();
        }
        if ($(this._formElements.title).val().length != 0 && $(this._formElements.title).val().length > 255) {
            $(this._formElements.titleLengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.titleLengthValidator).hide();
        }

        if ($(this._formElements.siteID).val().length == 0) {
            $(this._formElements.siteIDValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.siteIDValidator).hide();
        }
        if ($(this._formElements.siteID).val().length != 0 && $(this._formElements.siteID).val().length > 255) {
            $(this._formElements.siteIDLengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.siteIDLengthValidator).hide();
        }

        if ($(this._formElements.type).val().length == 0) {
            $(this._formElements.typeValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.typeValidator).hide();
        }
        if ($(this._formElements.type).val().length != 0 && $(this._formElements.type).val().length > 255) {
            $(this._formElements.typeLengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.typeLengthValidator).hide();
        }

        if (!$(this._formElements.timestamp).getKendoDateTimePicker().value()) {
            $(this._formElements.timestampValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.timestampValidator).hide();
        }

        if ($(this._formElements.trackingID).val().length == 0) {
            $(this._formElements.trackingIDValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.trackingIDValidator).hide();
        }
        if ($(this._formElements.trackingID).val().length != 0 && $(this._formElements.trackingID).val().length > 255) {
            $(this._formElements.trackingIDLengthValidator).show();
            isValid = false;
        }
        else {
            $(this._formElements.trackingIDLengthValidator).hide();
        }

        return isValid;
    },

    reset: function () {
        this.set_id("00000000-0000-0000-0000-000000000000");

        $(this._formElements.title).val("");
        $(this._formElements.titleValidator).hide();
        $(this._formElements.titleLengthValidator).hide();

        $(this._formElements.siteID).val("");
        $(this._formElements.siteIDValidator).hide();
        $(this._formElements.siteIDLengthValidator).hide();

        $(this._formElements.type).val("");
        $(this._formElements.typeValidator).hide();
        $(this._formElements.typeLengthValidator).hide();

        $(this._formElements.timestamp).getKendoDateTimePicker().value(null);
        $(this._formElements.timestampValidator).hide();

        $(this._formElements.trackingID).val("");
        $(this._formElements.trackingIDValidator).hide();
        $(this._formElements.trackingIDLengthValidator).hide();
    },

    /* --------------------------------- event handlers ---------------------------------- */

    /* --------------------------------- private methods --------------------------------- */

    _getFormData: function () {
        var data = {
            "Item": {
                "Title": $(this._formElements.title).val(),
                "SiteID": $(this._formElements.siteID).val(),
                "Type": $(this._formElements.type).val(),
                "Timestamp": "\/Date(" + ($(this._formElements.timestamp).getKendoDateTimePicker().value().getTime()) + ")\/",
                "TrackingID": $(this._formElements.trackingID).val()
            }
        };
        return data;
    },

    /* --------------------------------- properties -------------------------------------- */

    get_window: function () {
        return this._formWindow;
    },

    get_dataSource: function () {
        return this._dataSource;
    },

    get_webServiceUrl: function () {
        return this._webServiceUrl;
    },

    get_id: function () {
        return this._id;
    },
    set_id: function (id) {
        this._id = id;
    },

    /* --------------------------------- private fields ---------------------------------- */

    _formElements: {
        title: "#analyticsEventTitle",
        titleValidator: "#analyticsEventTitleValidator",
        titleLengthValidator: "#analyticsEventTitleLengthValidator",
        siteID: "#analyticsEventSiteID",
        siteIDValidator: "#analyticsEventSiteIDValidator",
        siteIDLengthValidator: "#analyticsEventSiteIDLengthValidator",
        type: "#analyticsEventType",
        typeValidator: "#analyticsEventTypeValidator",
        typeLengthValidator: "#analyticsEventTypeLengthValidator",
        timestamp: "#analyticsEventTimestamp",
        timestampValidator: "#analyticsEventTimestampValidator",
        trackingID: "#analyticsEventTrackingID",
        trackingIDValidator: "#analyticsEventTrackingIDValidator",
        trackingIDLengthValidator: "#analyticsEventTrackingIDLengthValidator"
    },
    _formWindow: null,
    _dataSource: null,
    _webServiceUrl: null,
    _id: "00000000-0000-0000-0000-000000000000"
});