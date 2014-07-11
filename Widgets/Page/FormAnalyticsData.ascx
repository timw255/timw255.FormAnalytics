<%@ Control Language="C#" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<sf:ResourceLinks ID="resourcesLinks" runat="server">
    <sf:ResourceFile JavaScriptLibrary="JQuery" />
    <sf:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="True" />
     <sf:ResourceFile JavaScriptLibrary="KendoAll" />
</sf:ResourceLinks>

<div class="sfDashboardWidgetWrp">
    <asp:Label ID="MessageLabel" runat="server"/>

    <div id="chart"></div>

    <script>

        function createChart() {
            $("#chart").kendoChart({
                dataSource: {
                    transport: {
                        read: {
                            contentType: "application/json; charset=utf-8",
                            url: "/Sitefinity/Services/FormAnalytics/AnalyticsData.svc/fieldData",
                            dataType: "json"
                        }
                    },
                    sort: {
                        field: "count",
                        dir: "desc"
                    }
                },
                legend: {
                    visible: true
                },
                title: {
                    text: "Completion Statistics (By Form Field)"
                },
                series: [{
                    type: "funnel",
                    dynamicSlope: true,
                    field: "count",
                    categoryField: "field_name",
                    dynamicHeight: false,
                    labels: {
                        visible: true,
                        background: "transparent",
                        template: "#= category #"
                    },
                    tooltip: {
                        visible: true,
                        template: "#= category # - #= value # events"
                    }
                }],
            });
        }

        $(document).ready(createChart);
    </script>
</div>