<%@ Control Language="C#" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="FormAnalytics" Assembly="FormAnalytics" Namespace="timw255.FormAnalytics.Web.UI.AnalyticsEvents" %>
<%@ Import Namespace="timw255.FormAnalytics" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
    <sitefinity:ResourceFile Name="Styles/DatePicker.css" />
    <sitefinity:ResourceFile Name="Styles/Grid.css" />
    <sitefinity:ResourceFile Name="Styles/ListView.css" />
    <sitefinity:ResourceFile Name="Styles/MaxWindow.css" />
    <sitefinity:ResourceFile Name="Styles/MenuMoreActions.css" />
    <sitefinity:ResourceFile Name="Styles/Tabstrip.css" />
    <sitefinity:ResourceFile Name="Styles/Window.css" />
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.JSON2.js" />
</sitefinity:ResourceLinks>
<sitefinity:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="Telerik.Sitefinity.Resources.Scripts.Kendo.styles.kendo_common_min.css" Static="True" />
    <sitefinity:ResourceFile Name="timw255.FormAnalytics.Web.Resources.CustomStylesKendoUIView.css" AssemblyInfo="timw255.FormAnalytics.FormAnalyticsModule, FormAnalytics" Static="True" />
</sitefinity:ResourceLinks>
<h1 class="sfBreadCrumb">
    <asp:Literal runat="server" Text='FormAnalytics'/>
</h1>
<div class="sfMain sfClearfix">
    <div class="sfContent">
        <!-- toolbar -->
        <div id="toolbar" class="sfAllToolsWrapper">
            <div class="sfAllTools">
                <ul class="sfActions">
                    <li class="sfMainAction">
                        <a id="createUserAnalyticsEvent" class="sfLinkBtn sfSave">
                            <span class="sfLinkBtnIn">
                                <asp:Literal ID="createAAnalyticsEvent" runat="server" Text='<%$Resources:FormAnalyticsResources, CreateAAnalyticsEvent %>'/>
                            </span>
                        </a>
                    </li>
                    <li class="sfGroupBtn">
                        <a id="deleteUserAnalyticsEvents" class="sfLinkBtn sfDisabledLinkBtn">
                            <span class="sfLinkBtnIn">
                                <asp:Literal ID="deleteUserAnalyticsEventsLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, DeleteLabel %>'/>
                            </span>
                        </a>
                    </li>
                    <li class="sfQuickSort sfNoMasterViews sfDropdownList">
                        <asp:Literal ID="SortLiteral" runat="server" Text='<%$Resources:FormAnalyticsResources, SortLabel %>'/>
                        <input id="sortingDropDownList" />
                    </li>
                </ul>
            </div>
        </div>

        <!-- main area -->
        <div class="sfWorkArea" id="workArea">
            <div id="analyticsEventsMasterView">
                <FormAnalytics:AnalyticsEventsMaster id="AnalyticsEventsMaster" runat="server" />
            </div>
            <div id="analyticsEventsDetailWindow" class="sfDialog sfFormDialog k-sitefinity">
                <FormAnalytics:AnalyticsEventsDetail id="AnalyticsEventsDetail" runat="server" />
            </div>
        </div>
    </div>
</div>

<input id="analyticsEventsServiceUrlHidden" type="hidden" value="<%= VirtualPathUtility.ToAbsolute("~/" + FormAnalyticsModule.AnalyticsEventsWebServiceUrl)  %>" />
