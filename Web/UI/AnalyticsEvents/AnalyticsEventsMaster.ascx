<%@ Control Language="C#" %>

<style type="text/css">
.k-loading-mask { visibility: hidden; }
</style>
<!-- no analyticsEvents created screen -->
<div id="analyticsEventsDecisionScreen" style="display:none;" class="sfEmptyList">
    <p class="sfMessage sfMsgNeutral sfMsgVisible"><asp:Literal ID="noAnalyticsEventsCreatedLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, NoAnalyticsEventsCreatedMessage %>'></asp:Literal></p>
    <ol class="sfWhatsNext">
        <li class="sfCreateItem">
            <a id="createAnalyticsEventDecisionScreen">
                <asp:Literal ID="createAAnalyticsEventLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, CreateAAnalyticsEvent %>'></asp:Literal>
                <span class="sfDecisionIcon"></span>
            </a>
        </li>
    </ol>
</div>

<!-- analyticsEvents grid -->
<table id="analyticsEventsGrid" class="rgTopOffset rgMasterTable" style="display: none;">
    <thead>
        <tr>
            <th class="sfCheckBoxCol">
                <input type="checkbox" id="checkAllCheckbox" name="checkAllCheckbox" value="" />
            </th>
            <th class="sfTitleCol">
                <asp:Literal ID="analyticsEventHeader" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTitleLabel %>'></asp:Literal>
            </th>
            <th class="sfLarge">
                <asp:Literal ID="siteIDHeader" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventSiteIDLabel %>'></asp:Literal>
            </th>
            <th class="sfLarge">
                <asp:Literal ID="typeHeader" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTypeLabel %>'></asp:Literal>
            </th>
            <th class="sfLarge">
                <asp:Literal ID="timestampHeader" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTimestampLabel %>'></asp:Literal>
            </th>
            <th class="sfLarge">
                <asp:Literal ID="trackingIDHeader" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTrackingIDLabel %>'></asp:Literal>
            </th>
            <th class="sfMoreActions sfLast">
                <asp:Literal ID="actionsHeader" runat="server" Text='<%$Resources:FormAnalyticsResources, ActionsLabel %>'></asp:Literal>
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td colspan="7">
            </td>
        </tr>
    </tbody>
    <tfoot>
        <tr class="rgPager">
            <td class="rgPagerCell NumericPages" colspan="7">
                <div class="rgWrap rgNumPart">
                    <div id="pagesWrapper">
                    </div>
                </div>
            </td>
        </tr>
    </tfoot>
</table>
<!-- analyticsEvents grid row template -->
<script id="analyticsEventsRowTemplate" type="text/x-kendo-template" style="display: none;">
    <tr>
        <td class="sfCheckBoxCol">
            <input type="checkbox" data-command="check" data-id="#= Id #" value=""/>
        </td>
        <td class="sfTitleCol">
            <a class="sfEditButton sfItemTitle sfactive" data-command="edit" data-id="#= Id #">
                <strong>#= Title #</strong>                
            </a>
        </td>
        <td class="sfLarge">
            <div class="dmDescription">#= SiteID #</div>
        </td>
        <td class="sfLarge">
            <div class="dmDescription">#= Type #</div>
        </td>
            <td class="sfLarge">
                <div class="dmDescription">
                    #if(Timestamp != null){#
						#= kendo.toString(new Date(parseInt(Timestamp.substr(6))), "dd MMM, yyyy HH:mm") #
                    #}#
                </div>
            </td>
            
        <td class="sfLarge">
            <div class="dmDescription">#= TrackingID #</div>
        </td>
        <td class="sfMoreActions sfLast">
            <ul class="sfActionsMenu">
                <li class="sfFirst sfLast">
                    #= ActionsLabel #
                    <ul>
                        <li>
                            <a class="sfDeleteItm" data-command="delete" data-id="#= Id #">
                                #= DeleteLabel #
                            </a>
                        </li>   
                    </ul>
                <li>
            </ul>
        </td>
    </tr>
</script>
<!-- END analyticsEvents grid row template -->

<div id="deleteAnalyticsEventConfirmationDialog" class="sfSelectorDialog">
    <p>
        <asp:Literal ID="deleteAnalyticsEventConfirmationLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, DeleteAnalyticsEventConfirmationMessage %>'/>
    </p>
    <div class="sfButtonArea">
        <a id="confirmAnalyticsEventDeleteButton" class="sfLinkBtn sfDelete">
            <span class="sfLinkBtnIn">
                <asp:Literal ID="deleteAnalyticsEventButtonLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, YesDeleteThisItemButton %>'/>
            </span>
        </a>
        <a id="cancelDeleteAnalyticsEventButton" class="sfCancel">
            <asp:Literal ID="cancelDeleteLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, CancelLabel %>'/>
        </a>
    </div>
</div>

<div id="batchDeleteAnalyticsEventConfirmationDialog" class="sfSelectorDialog">
    <p>
        <span id="batchDeleteAnalyticsEventCountLabel"></span>
        <span id="batchDeleteAnalyticsEventConfirmationSpan">
            <asp:Literal ID="batchDeleteAnalyticsEventConfirmationLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, BatchDeleteConfirmationMessage %>'/>
        </span>
    </p>
    <div class="sfButtonArea">
        <a id="confirmAnalyticsEventBatchDeleteButton" class="sfLinkBtn sfDelete">
            <span class="sfLinkBtnIn">
                <asp:Literal ID="batchDeleteAnalyticsEventButtonLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, YesDeleteTheseItemsButton %>'/>
            </span>
        </a>
        <a id="cancelBatchDeleteAnalyticsEventButton" class="sfCancel">
            <asp:Literal ID="cancelBatchDeleteLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, CancelLabel %>'/>
        </a>
    </div>
</div>

<div id="analyticsEventCustomSortingDialog" class="sfSelectorDialog">
    <h1><asp:literal ID="customSortingDialogHeader" runat="server" Text="<%$Resources:FormAnalyticsResources, CustomSortingDialogHeader%>" /></h1>
    <div class="sfSortingCondition">
        <div class="sfSortRules">
            <label class="sfTxtLbl" for="customSortingAnalyticsEventPropertiesDropDownList">
                <asp:Literal ID="sortByLiteral" runat="server" Text="<%$Resources:FormAnalyticsResources, SortByLabel%>" />
            </label>
			<div class="sfDropdownList sfInlineBlock sfAlignTop">
				<input id="customSortingAnalyticsEventPropertiesDropDownList" class="valid" />
			</div>
            <div class="sfInlineBlock">
                <ol class="sfRadioList">
                    <li>
                        <input id="ascendingRadioButton" type="radio" value="ASC" name="customSortingOrder" checked="checked">
                        <label for="ascendingRadioButton">Ascending</label>
                    </li>
                    <li>
                        <input id="descendingRadioButton" type="radio" value="DESC" name="customSortingOrder">
                        <label for="descendingRadioButton">Descending</label>
                    </li>
                </ol>
            </div>
        </div>
    </div>

    <div class="sfButtonArea sfSelectorBtns">
        <a ID="saveCustomSortingButton" Class="sfLinkBtn sfSave">
            <span class="sfLinkBtnIn">
                <asp:Literal ID="saveCustomSortingLiteral" runat="server" Text="<%$Resources:FormAnalyticsResources, SaveLabel %>" />
            </span>
        </a>
        <asp:Literal ID="orLiteral" runat="server" Text="<%$Resources:FormAnalyticsResources, OrLabel%>" />
        <a ID="cancelCustomSortingButton" Class="sfCancel">
            <asp:Literal ID="cancelCustomSortingLiteral" runat="server" Text="<%$Resources:FormAnalyticsResources, CancelLabel %>" />
        </a>
    </div>
</div>