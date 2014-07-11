$(document).ready(function () {
    function getCookie(name) {
        var re = new RegExp(name + "=([^;]+)");
        var value = re.exec(document.cookie);
        return (value != null) ? unescape(value[1]) : null;
    }

    function pushSignal(sender, signal, name) {
        var a = { "data": {} };

        a.data.signal = signal;
        a.data.site_id = $(sender).closest('.analyticForm').data('siteid');
        a.data.form_id = $(sender).closest('.analyticForm').data('formid');
        a.data.field_name = name || $(sender).closest('.faContainer').data('fieldname');
        a.data.tracking_id = getCookie('sf-trckngckie');

        $.ajax({
            url: 'Sitefinity/Services/FormAnalytics/AnalyticsSignal.svc/addObject',
            data: JSON.stringify(a),
            dataType: "json",
            contentType: "application/json",
            type: "POST"
        });
    }

    $('.analyticForm').bind('inview', function (event, isInView, visiblePartX, visiblePartY) {
        if (isInView) {
            pushSignal(this, 'FormView', $(this).data('fieldname'));
        }
    });

    $('input:not(type[submit]), textarea, select').focus(function () {
        pushSignal(this, 'FieldFocus');
    });

    $('input:not(type[submit]), textarea, select').blur(function () {

        if ($(this).val().length > 0 && !$(this).hasClass('faCompleted')) {
            pushSignal(this, 'FieldCompleted');
            $(this).addClass("faCompleted");
        }
        else if ($(this).hasClass('faCompleted')) {
            pushSignal(this, 'FieldCorrected');
        }
        else {
            pushSignal(this, 'FieldSkipped');
        }
    });
});