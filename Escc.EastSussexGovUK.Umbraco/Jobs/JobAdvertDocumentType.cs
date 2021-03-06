﻿using System;
using Escc.EastSussexGovUK.Umbraco.CampaignTemplates;
using Escc.EastSussexGovUK.Umbraco.DocumentTypes.CustomerFocusBase;
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
using Umbraco.Inception.Attributes;
using Umbraco.Inception.BL;

namespace Escc.EastSussexGovUK.Umbraco.Jobs
{
    /// <summary>
    /// Definition for the Umbraco 'Jobs component' document type
    /// </summary>
    /// <seealso cref="UmbracoGeneratedBase" />
    [UmbracoContentType("Job advert", "JobAdvert", new Type[] {
        typeof(LandingDocumentType),
        typeof(LocationDocumentType),
        typeof(TaskDocumentType),
        typeof(LandingPageWithPicturesDocumentType),
        typeof(GuideDocumentType),
        typeof(StandardLandingPageDocumentType),
        typeof(StandardTopicPageDocumentType),
        typeof(StandardDownloadPageDocumentType),
        typeof(MapDocumentType),
        typeof(FormDownloadDocumentType),
        typeof(CouncilOfficeDocumentType),
        typeof(CampaignLandingDocumentType),
        typeof(PersonDocumentType),
        typeof(JobsComponentDocumentType)}, true, allowAtRoot: false, icon: BuiltInUmbracoContentTypeIcons.IconLocationNearMe, 
    Description = "A standard page hosting a component of the TalentLink application.")]
    public class JobAdvertDocumentType : CustomerFocusBaseDocumentType
    {
        [UmbracoTemplate(DisplayName = "Jobs CSS", Alias = "JobsCss")]
        public string JobsCss { get; set; }

        [UmbracoTab("Content")]
        public JobAdvertContentTab Content { get; set; }
    }
}