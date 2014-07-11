$(document).ready(function () {
    var webServiceUrl = $('#analyticsEventsServiceUrlHidden').val();
    
    var itemsCountPerPage = 50;
    var sortExpression = "DateCreated DESC";
    var itemsTotalCount;
    var isLastPageDeleted;

    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: webServiceUrl + "?sortExpression=" + sortExpression + "&take=" + itemsCountPerPage,
                dataType: "json",
				cache: false,
            }
        },
        schema: {
            model: {
                id: "Id"
            },
            data: function (result) {
                itemsTotalCount = result.TotalCount;
                var items = result.Items;

                /* all items from the last page were deleted so the data source must be refreshed */
                isLastPageDeleted = (items.length == 0 && itemsTotalCount != 0);

                return items;
            }
        },
        change: function (e) {
            if (isLastPageDeleted) {
                /* refresh the data source */
                analyticsEventsMasterView.set_skip((analyticsEventsMasterView.get_currentPage() - 2) * analyticsEventsMasterView.get_itemsCountPerPage());
                analyticsEventsMasterView.get_dataSource().read();
                return;
            }
            analyticsEventsMasterView.refreshPager(itemsTotalCount);
        }
    });

    var analyticsEventsDetailView = new AnalyticsEventsDetail($("#analyticsEventsDetailWindow"), dataSource, webServiceUrl);
    var analyticsEventsMasterView = new AnalyticsEventsMaster(analyticsEventsDetailView, dataSource, itemsCountPerPage, webServiceUrl);
    analyticsEventsMasterView.set_sortExpression(sortExpression);

    jQuery("body").addClass("sfNoSidebar");

    $("#createUserAnalyticsEvent").click(function () {
        analyticsEventsDetailView.show();
    });

    $("#createAnalyticsEventDecisionScreen").click(function () {
        analyticsEventsDetailView.show();
    });

    $(".sfCancelAnalyticsEventButton").click(function () {
        analyticsEventsDetailView.close();
    });

    $("#saveAnalyticsEventButton").click(function () {
        analyticsEventsDetailView.save();
    });
});