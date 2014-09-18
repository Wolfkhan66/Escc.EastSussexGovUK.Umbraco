﻿using System;
using System.Web;

namespace Escc.EastSussexGovUK.Umbraco.Models
{
    /// <summary>
    /// An alert about disrupted council services
    /// </summary>
    public class AlertViewModel
    {
        /// <summary>
        /// Gets or sets the text of the alert.
        /// </summary>
        public IHtmlString Alert { get; set; }

        /// <summary>
        /// Gets or sets the page URL to display the alert on.
        /// </summary>
        public Uri TargetUrl { get; set; }

        /// <summary>
        /// Gets or sets whether this alert to those from parent pages, or replace them.
        /// </summary>
        public bool Append { get; set; }

        /// <summary>
        /// Gets or sets whether to cascade this alert to child pages.
        /// </summary>
        public bool Cascade { get; set; }
    }
}