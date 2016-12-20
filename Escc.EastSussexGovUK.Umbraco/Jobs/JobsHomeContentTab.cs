﻿using Umbraco.Inception.Attributes;
using Umbraco.Inception.BL;

namespace Escc.EastSussexGovUK.Umbraco.Jobs
{
    /// <summary>
    /// Content fields for <see cref="JobsHomeDocumentType"/>
    /// </summary>
    /// <seealso cref="Umbraco.Inception.BL.TabBase" />
    public class JobsHomeContentTab : TabBase
    {
        /// <summary>
        /// Gets or sets the jobs service logo
        /// </summary>
        /// <value>
        /// The jobs logo.
        /// </value>
        [UmbracoProperty("Logo", "JobsLogo", BuiltInUmbracoDataTypes.MediaPicker, sortOrder: 1, Description="Select the logo for the jobs service")]
        public string JobsLogo { get; set; }

        /// <summary>
        /// Gets or sets the background image for the header
        /// </summary>
        /// <value>
        /// The background image
        /// </value>
        [UmbracoProperty("Header background image", "HeaderBackgroundImage", BuiltInUmbracoDataTypes.MediaPicker, sortOrder: 2, Description = "Select the background image for the page header")]
        public string HeaderBackgroundImage { get; set; }

        /// <summary>
        /// Gets or sets the login page
        /// </summary>
        /// <value>
        /// A reference to the Umbraco node for the login page
        /// </value>
        [UmbracoProperty("Login page", "LoginPage", BuiltInUmbracoDataTypes.ContentPickerAlias, sortOrder: 3, Description = "Select the jobs login page, based on the 'Jobs component' document type")]
        public string LoginPage { get; set; }

        /// <summary>
        /// Gets or sets the search results page
        /// </summary>
        /// <value>
        /// A reference to the Umbraco node for the results page
        /// </value>
        [UmbracoProperty("Search results page", "SearchResultsPage", BuiltInUmbracoDataTypes.ContentPickerAlias, sortOrder: 4, Description = "Select the search results page, based on the 'Job search results' document type")]
        public string SearchResultsPage { get; set; }

        /// <summary>
        /// Gets or sets the button navigation.
        /// </summary>
        /// <value>
        /// The button navigation.
        /// </value>
        [UmbracoProperty("Button navigation", "ButtonNavigation", BuiltInUmbracoDataTypes.RelatedLinks, sortOrder: 5,
            Description = "Buttons and adverts, which can be customised using the images below. Set the caption to a space or hyphen to link the image without text.")]
        public string ButtonNavigation { get; set; }

        /// <summary>
        /// Gets or sets the images to be linked using <see cref="ButtonNavigation"/>
        /// </summary>
        [UmbracoProperty("Button images", "ButtonImages", BuiltInUmbracoDataTypes.MultipleMediaPicker, sortOrder: 6,
            Description = "Select the images to link to pages selected for button navigation, above.")]
        public string ButtonImages { get; set; }
    }
}