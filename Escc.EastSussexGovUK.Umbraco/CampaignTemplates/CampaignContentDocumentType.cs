﻿using System;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.FormDownload;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.Guide;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.Landing;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.LandingPageWithPictures;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.Location;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.Map;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.Person;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.StandardDownloadPage;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.StandardLandingPage;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.StandardTopicPage;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.Task;
using Escc.Umbraco.PropertyEditors;
using Escc.Umbraco.PropertyEditors.RichTextPropertyEditor;
using Umbraco.Inception.Attributes;
using Umbraco.Inception.BL;

namespace Escc.EastSussexGovUK.Umbraco.CampaignTemplates
{
    [UmbracoContentType("Campaign content page", "CampaignContent", new Type[]
    {
        typeof(LandingDocumentType), 
        typeof(LocationDocumentType),
        typeof(TaskDocumentType), 
        typeof(PersonDocumentType),
        typeof(LandingPageWithPicturesDocumentType),
        typeof(GuideDocumentType),
        typeof(StandardLandingPageDocumentType),
        typeof(StandardTopicPageDocumentType),
        typeof(StandardDownloadPageDocumentType),
        typeof(MapDocumentType),
        typeof(FormDownloadDocumentType),
        typeof(RecyclingSiteDocumentType),
        typeof(LibraryDocumentType),
        typeof(MobileLibraryStopDocumentType),
        typeof(ChildcareDocumentType),
        typeof(CouncilOfficeDocumentType),
        typeof(SportLocationDocumentType),
        typeof(ParkDocumentType),
        typeof(RegistrationOfficeDocumentType),
        typeof(DayCentreDocumentType),
        typeof(CampaignLandingDocumentType),
        typeof(CampaignContentDocumentType)
    }, true, BuiltInUmbracoContentTypeIcons.IconParachuteDrop, 
    Description="A content page for a marketing campaign")]
    public class CampaignContentDocumentType : UmbracoGeneratedBase
    {
        [UmbracoTemplate(DisplayName = "Campaign content page CSS", Alias = "CampaignContentCss")]
        public string CampaignContentCss { get; set; }

        [UmbracoTab("Content", 0)]
        public CampaignContentContentTab ContentTab { get; set; }

        [UmbracoTab("Design", 1)]
        public CampaignContentDesignTab DesignTab { get; set; }

        [UmbracoProperty("Page URL", "umbracoUrlName", BuiltInUmbracoDataTypes.Textbox, sortOrder: 0)]
        public Uri UmbracoUrlName { get; set; }

        [UmbracoProperty("Description", "pageDescription", BuiltInUmbracoDataTypes.TextboxMultiple, sortOrder: 1, mandatory: true)]
        public string Description { get; set; }

        [UmbracoProperty("Author notes", "authorNotes", PropertyEditorAliases.RichTextPropertyEditor, RichTextAuthorNotesDataType.DataTypeName, sortOrder: 2)]
        public string AuthorNotes { get; set; }

        [UmbracoProperty("Cache", "cache", BuiltInUmbracoDataTypes.DropDown, "Cache", sortOrder: 101, description: "Pages are cached for 24 hours by default.  If this page is particularly time-sensitive, pick shorter time.")]
        public string Cache { get; set; }

        [UmbracoProperty("Copy of unpublished date (do not edit)", "unpublishAt", BuiltInUmbracoDataTypes.DateTime, sortOrder: 103)]
        public string UnpublishAt { get; set; }
    }
}

