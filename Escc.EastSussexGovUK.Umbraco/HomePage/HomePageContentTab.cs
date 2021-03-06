﻿using Umbraco.Inception.Attributes;
using Umbraco.Inception.BL;

namespace Escc.EastSussexGovUK.Umbraco.HomePage
{
    public class HomePageContentTab: TabBase
    {
 
        /* Top tasks */
        [UmbracoProperty("Top tasks: Title", "TopTasksTitle", BuiltInUmbracoDataTypes.Textbox, SortOrder = 1)]
        public string TopTasksTitle { get; set; }

        [UmbracoProperty("Top tasks: Content", "TopTasksContent", BuiltInUmbracoDataTypes.RelatedLinks, SortOrder = 2)]
        public string TopTasksContent { get; set; }  

        /* News */
        [UmbracoProperty("News: Title", "NewsTitle", BuiltInUmbracoDataTypes.Textbox, SortOrder = 3)]
        public string NewsTitle { get; set; }

        /* Report, apply, pay section */
        [UmbracoProperty("Report tab", "ReportTab", BuiltInUmbracoDataTypes.RelatedLinks, SortOrder = 5)]
        public string ReportTab { get; set; }

        [UmbracoProperty("Apply tab", "ApplyTab", BuiltInUmbracoDataTypes.RelatedLinks, SortOrder = 6)]
        public string ApplyTab { get; set; }

        [UmbracoProperty("Pay tab", "PayTab", BuiltInUmbracoDataTypes.RelatedLinks, SortOrder = 7)]
        public string PayTab { get; set; }

        /* School term dates */
        [UmbracoProperty("School term dates: Data", "TermDatesData", BuiltInUmbracoDataTypes.MediaPicker, SortOrder = 8, Description="Upload an XML file of school term dates data, and select it here")]
        public string TermDatesData { get; set; }


        [UmbracoProperty("School term dates: Footer links", "SchoolLinks", BuiltInUmbracoDataTypes.RelatedLinks, SortOrder = 9)]
        public string SchoolLinks { get; set; }

        /* Libraries */
        [UmbracoProperty("Libraries: Title", "LibrariesTitle", BuiltInUmbracoDataTypes.Textbox, SortOrder = 10)]
        public string LibrariesTitle { get; set; }

        [UmbracoProperty("Libraries: Content", "LibrariesContent", BuiltInUmbracoDataTypes.RelatedLinks, SortOrder = 11)]
        public string LibrariesContent { get; set; }

        /* Jobs */
        [UmbracoProperty("Jobs logo", "JobsLogo", BuiltInUmbracoDataTypes.MediaPicker, sortOrder: 12, Description = "Select the logo for the jobs service")]
        public string JobsLogo { get; set; }

        /// <summary>
        /// Gets or sets the jobs start page
        /// </summary>
        /// <value>
        /// A reference to the Umbraco node for the home page
        /// </value>
        [UmbracoProperty("Jobs home page", "JobsHomePage", BuiltInUmbracoDataTypes.ContentPickerAlias, sortOrder: 13, Description = "Select the jobs home page, to be linked from the logo")]
        public string JobsHomePage { get; set; }

        [UmbracoProperty("Job search results page", "JobSearchResultsPage", BuiltInUmbracoDataTypes.ContentPickerAlias, sortOrder: 14, Description = "Select the job search results page, based on the 'Job search results' document type")]
        public string JobSearchResultsPage { get; set; }

        /* Recycling */
        [UmbracoProperty("Recycling sites: Title", "RecyclingTitle", BuiltInUmbracoDataTypes.Textbox, SortOrder = 15)]
        public string RecyclingTitle { get; set; }

        /* Involved 
                   Note: Make sure the related links field is not last, as a bug in Umbraco 7.2.1 means it cannot be edited in that position
                 */
        [UmbracoProperty("Get involved: Footer links", "InvolvedLinks", BuiltInUmbracoDataTypes.RelatedLinks, SortOrder = 16)]
        public string InvolvedLinks { get; set; } 
        
        [UmbracoProperty("Get involved: Title", "InvolvedTitle", BuiltInUmbracoDataTypes.Textbox, SortOrder = 17)]
        public string InvolvedTitle { get; set; }

    }
}