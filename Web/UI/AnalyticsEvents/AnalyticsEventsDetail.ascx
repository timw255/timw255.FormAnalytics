<%@ Control Language="C#" %>

<fieldset class="sfNewItemForm">
    <a id="backToAnalyticsEvents" href="javascript:void(0);" class="sfBack sfCancelAnalyticsEventButton">
        <asp:Literal ID="backToMasterLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, BackToLabel %>'></asp:Literal>
    </a>
    <h1>
        <asp:Literal ID="createAAnalyticsEventLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, CreateAAnalyticsEvent %>'></asp:Literal>
    </h1>
    <div class="sfForm sfFirstForm">
        <ul class="sfFormIn">
            <li class="sfTitleField">
                <label for="analyticsEventTitle" class="sfTxtLbl">
                    <asp:Literal ID="analyticsEventTitleTitle" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTitleLabel %>'></asp:Literal>
                </label>
                <input id="analyticsEventTitle" type="text" class="sfTxt" />
                <div class="sfExample">
                    <asp:Literal ID="analyticsEventTitleDescription" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTitleDescription %>'></asp:Literal>
                </div>
                <div id="analyticsEventTitleValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventTitleEmptyErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTitleCannotBeEmpty %>'></asp:Literal>
                </div>
                <div id="analyticsEventTitleLengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventTitleLengthErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTitleInvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="analyticsEventSiteID" class="sfTxtLbl">
                    <asp:Literal ID="analyticsEventSiteIDTitle" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventSiteIDLabel %>'></asp:Literal>
                </label>
                <input id="analyticsEventSiteID" type="text" class="sfTxt" />
                <div id="analyticsEventSiteIDValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventSiteIDEmptyErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventSiteIDCannotBeEmpty %>'></asp:Literal>
                </div>
                <div id="analyticsEventSiteIDLengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventSiteIDLengthErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventSiteIDInvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="analyticsEventType" class="sfTxtLbl">
                    <asp:Literal ID="analyticsEventTypeTitle" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTypeLabel %>'></asp:Literal>
                </label>
                <input id="analyticsEventType" type="text" class="sfTxt" />
                <div id="analyticsEventTypeValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventTypeEmptyErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTypeCannotBeEmpty %>'></asp:Literal>
                </div>
                <div id="analyticsEventTypeLengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventTypeLengthErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTypeInvalidLength %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator sfDropdownList">
                <label for="analyticsEventTimestamp" class="sfTxtLbl">
                    <asp:Literal ID="analyticsEventTimestampTitle" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTimestampLabel %>'></asp:Literal>
                </label>
                <input id="analyticsEventTimestamp" class="sfTxt k-datepicker" />
                <div id="analyticsEventTimestampValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventTimestampEmptyErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTimestampCannotBeEmpty %>'></asp:Literal>
                </div>
            </li>
            <li class="sfFormSeparator">
                <label for="analyticsEventTrackingID" class="sfTxtLbl">
                    <asp:Literal ID="analyticsEventTrackingIDTitle" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTrackingIDLabel %>'></asp:Literal>
                </label>
                <input id="analyticsEventTrackingID" type="text" class="sfTxt" />
                <div id="analyticsEventTrackingIDValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventTrackingIDEmptyErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTrackingIDCannotBeEmpty %>'></asp:Literal>
                </div>
                <div id="analyticsEventTrackingIDLengthValidator" class="sfError" style="display:none;">
                    <asp:Literal ID="analyticsEventTrackingIDLengthErrorLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, AnalyticsEventTrackingIDInvalidLength %>'></asp:Literal>
                </div>
            </li>

        </ul>
    </div>
        
    <div class="sfButtonArea sfMainFormBtns">
        <a id="saveAnalyticsEventButton" class="sfLinkBtn sfSave">
            <span id="createAnalyticsEventButtonText" class="sfLinkBtnIn">
                <asp:Literal ID="createAnalyticsEventButtonLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, CreateThisAnalyticsEventButton %>' />
            </span>
            <span id="saveChangesAnalyticsEventButtonText" class="sfLinkBtnIn" style="display:none;">
                <asp:Literal ID="saveChangesAnalyticsEventButtonLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, SaveChangesLabel %>' />
            </span>
        </a>
        <a id="cancel" class="sfCancel sfCancelAnalyticsEventButton">
            <asp:Literal ID="cancelLiteral1" runat="server" Text='<%$Resources:FormAnalyticsResources, CancelLabel %>' />
        </a>
    </div>
</fieldset>