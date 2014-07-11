using System;
using System.Linq;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace timw255.FormAnalytics
{
    /// <summary>
    /// Localizable strings for the FormAnalytics module
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<FormAnalyticsResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("FormAnalyticsResources", ResourceClassId = "FormAnalyticsResources", Title = "FormAnalyticsResourcesTitle", TitlePlural = "FormAnalyticsResourcesTitlePlural", Description = "FormAnalyticsResourcesDescription")]
    public class FormAnalyticsResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="FormAnalyticsResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public FormAnalyticsResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="FormAnalyticsResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public FormAnalyticsResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// FormAnalytics Resources
        /// </summary>
        [ResourceEntry("FormAnalyticsResourcesTitle",
            Value = "FormAnalytics module labels",
            Description = "The title of this class.",
            LastModified = "2014/07/09")]
        public string FormAnalyticsResourcesTitle
        {
            get
            {
                return this["FormAnalyticsResourcesTitle"];
            }
        }

        /// <summary>
        /// FormAnalytics Resources Title plural
        /// </summary>
        [ResourceEntry("FormAnalyticsResourcesTitlePlural",
            Value = "FormAnalytics module labels",
            Description = "The title plural of this class.",
            LastModified = "2014/07/09")]
        public string FormAnalyticsResourcesTitlePlural
        {
            get
            {
                return this["FormAnalyticsResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for FormAnalytics module.
        /// </summary>
        [ResourceEntry("FormAnalyticsResourcesDescription",
            Value = "Contains localizable resources for FormAnalytics module.",
            Description = "The description of this class.",
            LastModified = "2014/07/09")]
        public string FormAnalyticsResourcesDescription
        {
            get
            {
                return this["FormAnalyticsResourcesDescription"];
            }
        }
        #endregion

        #region Labels
        /// <summary>
        /// word: Actions
        /// </summary>
        [ResourceEntry("ActionsLabel",
            Value = "Actions",
            Description = "word: Actions",
            LastModified = "2014/07/09")]
        public string ActionsLabel
        {
            get
            {
                return this["ActionsLabel"];
            }
        }

        /// <summary>
        /// Title of the link for closing the dialog and going back to the FormAnalytics module
        /// </summary>
        [ResourceEntry("BackToLabel",
            Value = "Go Back",
            Description = "Title of the link for closing the dialog and going back",
            LastModified = "2014/07/09")]
        public string BackToLabel
        {
            get
            {
                return this["BackToLabel"];
            }
        }

        /// <summary>
        /// word: Cancel
        /// </summary>
        [ResourceEntry("CancelLabel",
            Value = "Cancel",
            Description = "word: Cancel",
            LastModified = "2014/07/09")]
        public string CancelLabel
        {
            get
            {
                return this["CancelLabel"];
            }
        }

        /// <summary>
        /// word: Save
        /// </summary>
        /// <value>Save</value>
        [ResourceEntry("SaveLabel",
            Value = "Save",
            Description = "word: Save",
            LastModified = "2014/07/09")]
        public string SaveLabel
        {
            get
            {
                return this["SaveLabel"];
            }
        }

        /// <summary>
        /// phrase: Save changes
        /// </summary>
        [ResourceEntry("SaveChangesLabel",
            Value = "Save changes",
            Description = "phrase: Save changes",
            LastModified = "2014/07/09")]
        public string SaveChangesLabel
        {
            get
            {
                return this["SaveChangesLabel"];
            }
        }

        /// <summary>
        /// word: Delete
        /// </summary>
        [ResourceEntry("DeleteLabel",
            Value = "Delete",
            Description = "word: Delete",
            LastModified = "2014/07/09")]
        public string DeleteLabel
        {
            get
            {
                return this["DeleteLabel"];
            }
        }

        /// <summary>
        /// Phrase: Yes, delete these items
        /// </summary>
        /// <value>Yes, delete these items</value>
        [ResourceEntry("YesDeleteTheseItemsButton",
            Value = "Yes, delete these items",
            Description = "Phrase: Yes, delete these items",
            LastModified = "2014/07/09")]
        public string YesDeleteTheseItemsButton
        {
            get
            {
                return this["YesDeleteTheseItemsButton"];
            }
        }

        /// <summary>
        /// Text of the button that confirms deletion of an item.
        /// </summary>
        /// <value>Yes, delete this item</value>
        [ResourceEntry("YesDeleteThisItemButton",
            Value = "Yes, delete this item",
            Description = "Text of the button that confirms deletion of an item.",
            LastModified = "2014/07/09")]
        public string YesDeleteThisItemButton
        {
            get
            {
                return this["YesDeleteThisItemButton"];
            }
        }

        /// <summary>
        /// Phrase: items are about to be deleted. Continue?
        /// </summary>
        /// <value>items are about to be deleted. Continue?</value>
        [ResourceEntry("BatchDeleteConfirmationMessage",
            Value = "items are about to be deleted. Continue?",
            Description = "Phrase: items are about to be deleted. Continue?",
            LastModified = "2014/07/09")]
        public string BatchDeleteConfirmationMessage
        {
            get
            {
                return this["BatchDeleteConfirmationMessage"];
            }
        }

        /// <summary>
        /// word: Sort
        /// </summary>
        /// <value>Sort</value>
        [ResourceEntry("SortLabel",
            Value = "Sort",
            Description = "word: Sort",
            LastModified = "2014/07/09")]
        public string SortLabel
        {
            get
            {
                return this["SortLabel"];
            }
        }

        /// <summary>
        /// Phrase: Custom sorting
        /// </summary>
        /// <value>Custom sorting</value>
        [ResourceEntry("CustomSortingDialogHeader",
            Value = "Custom sorting",
            Description = "Phrase: Custom sorting",
            LastModified = "2014/07/09")]
        public string CustomSortingDialogHeader
        {
            get
            {
                return this["CustomSortingDialogHeader"];
            }
        }

        /// <summary>
        /// word: or
        /// </summary>
        /// <value>or</value>
        [ResourceEntry("OrLabel",
            Value = "or",
            Description = "word: or",
            LastModified = "2014/07/09")]
        public string OrLabel
        {
            get
            {
                return this["OrLabel"];
            }
        }

        /// <summary>
        /// Phrase: Sort by
        /// </summary>
        /// <value>Sort by</value>
        [ResourceEntry("SortByLabel",
            Value = "Sort by",
            Description = "Phrase: Sort by",
            LastModified = "2014/07/09")]
        public string SortByLabel
        {
            get
            {
                return this["SortByLabel"];
            }
        }

        /// <summary>
        /// word: Yes
        /// </summary>
        /// <value>Yes</value>
        [ResourceEntry("YesLabel",
            Value = "Yes",
            Description = "word: Yes",
            LastModified = "2013/06/26")]
        public string YesLabel
        {
            get
            {
                return this["YesLabel"];
            }
        }

        /// <summary>
        /// word: No
        /// </summary>
        /// <value>No</value>
        [ResourceEntry("NoLabel",
            Value = "No",
            Description = "word: No",
            LastModified = "2013/06/26")]
        public string NoLabel
        {
            get
            {
                return this["NoLabel"];
            }
        }
        #endregion

        #region AnalyticsEvents
        /// <summary>
        /// Messsage: PageTitle
        /// </summary>
        /// <value>Title for the AnalyticsEvent's page.</value>
        [ResourceEntry("AnalyticsEventGroupPageTitle",
            Value = "AnalyticsEvent",
            Description = "The title of AnalyticsEvent's page.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventGroupPageTitle
        {
            get
            {
                return this["AnalyticsEventGroupPageTitle"];
            }
        }

        /// <summary>
        /// Messsage: PageDescription
        /// </summary>
        /// <value>Description for the AnalyticsEvent's page.</value>
        [ResourceEntry("AnalyticsEventGroupPageDescription",
            Value = "AnalyticsEvent",
            Description = "The description of AnalyticsEvent's page.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventGroupPageDescription
        {
            get
            {
                return this["AnalyticsEventGroupPageDescription"];
            }
        }

        /// <summary>
        /// The URL name of AnalyticsEvent's page.
        /// </summary>
        [ResourceEntry("AnalyticsEventGroupPageUrlName",
            Value = "FormAnalytics-AnalyticsEvent",
            Description = "The URL name of AnalyticsEvent's page.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventGroupPageUrlName
        {
            get
            {
                return this["AnalyticsEventGroupPageUrlName"];
            }
        }

        /// <summary>
        /// Message displayed to user when no analyticsEvents exist in the system
        /// </summary>
        /// <value>No analyticsEvents have been created yet</value>
        [ResourceEntry("NoAnalyticsEventsCreatedMessage",
            Value = "No analyticsEvents have been created yet",
            Description = "Message displayed to user when no analyticsEvents exist in the system",
            LastModified = "2014/07/09")]
        public string NoAnalyticsEventsCreatedMessage
        {
            get
            {
                return this["NoAnalyticsEventsCreatedMessage"];
            }
        }

        /// <summary>
        /// Title of the button for creating a new analyticsEvent
        /// </summary>
        /// <value>Create a analyticsEvent</value>
        [ResourceEntry("CreateAAnalyticsEvent",
            Value = "Create a analyticsEvent",
            Description = "Title of the button for creating a new analyticsEvent",
            LastModified = "2014/07/09")]
        public string CreateAAnalyticsEvent
        {
            get
            {
                return this["CreateAAnalyticsEvent"];
            }
        }

        /// <summary>
        /// Label for editing a new analyticsEvent
        /// </summary>
        /// <value>Create a analyticsEvent</value>
        [ResourceEntry("EditAAnalyticsEvent",
            Value = "Edit a analyticsEvent",
            Description = "Label for editing a new analyticsEvent",
            LastModified = "2014/07/09")]
        public string EditAAnalyticsEvent
        {
            get
            {
                return this["EditAAnalyticsEvent"];
            }
        }

        /// <summary>
        /// AnalyticsEvent Title.
        /// </summary>
        /// <value>Title</value>
        [ResourceEntry("AnalyticsEventTitleLabel",
            Value = "Title",
            Description = "AnalyticsEvent Title.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTitleLabel
        {
            get
            {
                return this["AnalyticsEventTitleLabel"];
            }
        }

        /// <summary>
        /// AnalyticsEvent Title description.
        /// </summary>
        /// <value>Enter the item's title (required)</value>
        [ResourceEntry("AnalyticsEventTitleDescription",
            Value = "Enter the item's title (required)",
            Description = "AnalyticsEvent Title description.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTitleDescription
        {
            get
            {
                return this["AnalyticsEventTitleDescription"];
            }
        }

        /// <summary>
        /// Error message displayed if the user does not enter analyticsEvent Title.
        /// </summary>
        [ResourceEntry("AnalyticsEventTitleCannotBeEmpty",
            Value = "The Title of the analyticsEvent cannot be empty.",
            Description = "Error message displayed if the user does not enter analyticsEvent Title.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTitleCannotBeEmpty
        {
            get
            {
                return this["AnalyticsEventTitleCannotBeEmpty"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Title.
        /// </summary>
        /// <value>Title value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("AnalyticsEventTitleInvalidLength",
            Value = "Title value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Title.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTitleInvalidLength
        {
            get
            {
                return this["AnalyticsEventTitleInvalidLength"];
            }
        }

        /// <summary>
        /// AnalyticsEvent SiteID.
        /// </summary>
        /// <value>Site ID</value>
        [ResourceEntry("AnalyticsEventSiteIDLabel",
            Value = "Site ID",
            Description = "AnalyticsEvent SiteID.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventSiteIDLabel
        {
            get
            {
                return this["AnalyticsEventSiteIDLabel"];
            }
        }

        /// <summary>
        /// Error message displayed if the user does not enter analyticsEvent SiteID.
        /// </summary>
        [ResourceEntry("AnalyticsEventSiteIDCannotBeEmpty",
            Value = "The SiteID of the analyticsEvent cannot be empty.",
            Description = "Error message displayed if the user does not enter analyticsEvent SiteID.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventSiteIDCannotBeEmpty
        {
            get
            {
                return this["AnalyticsEventSiteIDCannotBeEmpty"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long SiteID.
        /// </summary>
        /// <value>SiteID value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("AnalyticsEventSiteIDInvalidLength",
            Value = "SiteID value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long SiteID.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventSiteIDInvalidLength
        {
            get
            {
                return this["AnalyticsEventSiteIDInvalidLength"];
            }
        }

        /// <summary>
        /// AnalyticsEvent Type.
        /// </summary>
        /// <value>Type</value>
        [ResourceEntry("AnalyticsEventTypeLabel",
            Value = "Type",
            Description = "AnalyticsEvent Type.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTypeLabel
        {
            get
            {
                return this["AnalyticsEventTypeLabel"];
            }
        }

        /// <summary>
        /// Error message displayed if the user does not enter analyticsEvent Type.
        /// </summary>
        [ResourceEntry("AnalyticsEventTypeCannotBeEmpty",
            Value = "The Type of the analyticsEvent cannot be empty.",
            Description = "Error message displayed if the user does not enter analyticsEvent Type.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTypeCannotBeEmpty
        {
            get
            {
                return this["AnalyticsEventTypeCannotBeEmpty"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Type.
        /// </summary>
        /// <value>Type value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("AnalyticsEventTypeInvalidLength",
            Value = "Type value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Type.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTypeInvalidLength
        {
            get
            {
                return this["AnalyticsEventTypeInvalidLength"];
            }
        }

        /// <summary>
        /// AnalyticsEvent Timestamp.
        /// </summary>
        /// <value>Timestamp</value>
        [ResourceEntry("AnalyticsEventTimestampLabel",
            Value = "Timestamp",
            Description = "AnalyticsEvent Timestamp.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTimestampLabel
        {
            get
            {
                return this["AnalyticsEventTimestampLabel"];
            }
        }

        /// <summary>
        /// Error message displayed if the user does not enter analyticsEvent Timestamp.
        /// </summary>
        [ResourceEntry("AnalyticsEventTimestampCannotBeEmpty",
            Value = "The Timestamp of the analyticsEvent cannot be empty.",
            Description = "Error message displayed if the user does not enter analyticsEvent Timestamp.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTimestampCannotBeEmpty
        {
            get
            {
                return this["AnalyticsEventTimestampCannotBeEmpty"];
            }
        }

        /// <summary>
        /// AnalyticsEvent TrackingID.
        /// </summary>
        /// <value>Tracking ID</value>
        [ResourceEntry("AnalyticsEventTrackingIDLabel",
            Value = "Tracking ID",
            Description = "AnalyticsEvent TrackingID.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTrackingIDLabel
        {
            get
            {
                return this["AnalyticsEventTrackingIDLabel"];
            }
        }

        /// <summary>
        /// Error message displayed if the user does not enter analyticsEvent TrackingID.
        /// </summary>
        [ResourceEntry("AnalyticsEventTrackingIDCannotBeEmpty",
            Value = "The TrackingID of the analyticsEvent cannot be empty.",
            Description = "Error message displayed if the user does not enter analyticsEvent TrackingID.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTrackingIDCannotBeEmpty
        {
            get
            {
                return this["AnalyticsEventTrackingIDCannotBeEmpty"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long TrackingID.
        /// </summary>
        /// <value>TrackingID value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("AnalyticsEventTrackingIDInvalidLength",
            Value = "TrackingID value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long TrackingID.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventTrackingIDInvalidLength
        {
            get
            {
                return this["AnalyticsEventTrackingIDInvalidLength"];
            }
        }

        /// <summary>
        /// Message displayed to user when deleting a user analyticsEvent.
        /// </summary>
        [ResourceEntry("DeleteAnalyticsEventConfirmationMessage",
            Value = "Are you sure you want to delete this analyticsEvent?",
            Description = "Message displayed to user when deleting a user analyticsEvent.",
            LastModified = "2014/07/09")]
        public string DeleteAnalyticsEventConfirmationMessage
        {
            get
            {
                return this["DeleteAnalyticsEventConfirmationMessage"];
            }
        }

        /// <summary>
        /// phrase: Create this analyticsEvent
        /// </summary>
        [ResourceEntry("CreateThisAnalyticsEventButton",
            Value = "Create this analyticsEvent",
            Description = "phrase: Create this analyticsEvent",
            LastModified = "2014/07/09")]
        public string CreateThisAnalyticsEventButton
        {
            get
            {
                return this["CreateThisAnalyticsEventButton"];
            }
        }

        /// <summary>
        /// The URL name of AnalyticsEvent's page.
        /// </summary>
        /// <value>AnalyticsEventMasterPageUrl</value>
        [ResourceEntry("AnalyticsEventMasterPageUrl",
            Value = "AnalyticsEventMasterPageUrl",
            Description = "The URL name of AnalyticsEvent's page.",
            LastModified = "2014/07/09")]
        public string AnalyticsEventMasterPageUrl
        {
            get
            {
                return this["AnalyticsEventMasterPageUrl"];
            }
        }
        #endregion
    }
}