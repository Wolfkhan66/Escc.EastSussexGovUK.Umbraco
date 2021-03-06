﻿using System;
using Escc.Umbraco.PropertyEditors;
using Escc.Umbraco.PropertyEditors.RichTextPropertyEditor;
using Umbraco.Inception.Attributes;
using Umbraco.Inception.BL;

namespace Escc.EastSussexGovUK.Umbraco.CampaignTemplates
{
    [UmbracoContentType("Campaign landing page", "CampaignLanding", new Type[]
    {
        typeof(CampaignLandingDocumentType),
        typeof(CampaignContentDocumentType),
        typeof(CampaignTilesDocumentType)
    }, true, BuiltInUmbracoContentTypeIcons.IconRocket, 
    Description="A landing page for a marketing campaign")]
    public class CampaignLandingDocumentType : UmbracoGeneratedBase
    {
        [UmbracoTemplate(DisplayName="Campaign landing page CSS", Alias="CampaignLandingCss")]
        public string CampaignLandingCss { get; set; }

        [UmbracoTab("Content", 0)]
        public CampaignLandingContentTab ContentTab { get; set; }

        [UmbracoTab("Design", 1)]
        public CampaignLandingDesignTab DesignTab { get; set; }

        [UmbracoProperty("Page URL", "umbracoUrlName", BuiltInUmbracoDataTypes.Textbox, sortOrder: 0)]
        public Uri UmbracoUrlName { get; set; }

        [UmbracoProperty("Description", "pageDescription", BuiltInUmbracoDataTypes.TextboxMultiple, sortOrder: 1, mandatory: true)]
        public string Description { get; set; }

        [UmbracoProperty("Google AdWords tag", "GoogleAdWordsTag", BuiltInUmbracoDataTypes.TextboxMultiple, sortOrder: 2,
            Description="When tracking conversions from a Google AdWords campaign, paste the tag code here")]
        public string GoogleAdWordsTag { get; set; }

        [UmbracoProperty("Author notes", "authorNotes", PropertyEditorAliases.RichTextPropertyEditor, RichTextAuthorNotesDataType.DataTypeName, sortOrder: 3)]
        public string AuthorNotes { get; set; }

        [UmbracoProperty("Cache", "cache", BuiltInUmbracoDataTypes.DropDown, "Cache", sortOrder: 101, description: "Pages are cached for 24 hours by default.  If this page is particularly time-sensitive, pick shorter time.")]
        public string Cache { get; set; }

        [UmbracoProperty("Copy of unpublished date (do not edit)", "unpublishAt", BuiltInUmbracoDataTypes.DateTime, sortOrder: 103)]
        public string UnpublishAt { get; set; }
    }
}

