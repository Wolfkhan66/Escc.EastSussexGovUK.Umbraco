﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Caching;
using Escc.Dates;
using Escc.EastSussexGovUK.Umbraco.Models;
using Escc.Net;
using Escc.Umbraco.Caching;
using Escc.Umbraco.PropertyTypes;
using Exceptionless.Extensions;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Escc.EastSussexGovUK.Umbraco.Jobs
{
    /// <summary>
    /// Controller for pages based on the 'Jobs RSS feed' Umbraco document type
    /// </summary>
    /// <seealso cref="RenderMvcController"/>
    public class JobsRssController : RenderMvcController
    {
        /// <summary>
        /// The default action to render the front-end view
        /// </summary>
        /// <param name="model"/>
        /// <returns/>
        public async new Task<ActionResult> Index(RenderModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var viewModel = new RssViewModel<Job>();
            viewModel.Metadata.Title = model.Content.Name;
            viewModel.Metadata.Description = model.Content.GetPropertyValue<string>("pageDescription_Content");

            var jobs = await ReadJobs(model);

            foreach (var job in jobs)
            {
                viewModel.Items.Add(job);
            }

            new HttpCachingService().SetHttpCacheHeadersFromUmbracoContent(model.Content, UmbracoContext.Current.InPreviewMode, Response.Cache);

            return CurrentTemplate(viewModel);
        }

        private async Task<List<Job>> ReadJobs(RenderModel model)
        {
            List<Job> jobs = null;

            var query = new JobSearchQueryFactory().CreateFromQueryString(Request.QueryString);

            var jobTypes = model.Content.GetPropertyValue<string>("JobTypes_Content");
            var jobTypesToFilter = Regex.Replace(Regex.Replace(jobTypes, "\r", String.Empty), "\n", Environment.NewLine).SplitAndTrim(Environment.NewLine);
            foreach (var jobType in jobTypesToFilter)
            {
                query.JobTypes.Add(jobType);
            }

            var cacheKey = "Jobs" + query.ToHash();

            if (HttpContext.Cache[cacheKey] == null || Request.QueryString["ForceCacheRefresh"] == "1")
            {
                var searchUrl = new TalentLinkUrl(model.Content.GetPropertyValue<string>("SearchScriptUrl_Content")).LinkUrl;
                var resultsUrl = new TalentLinkUrl(model.Content.GetPropertyValue<string>("ResultsScriptUrl_Content")).LinkUrl;
                var detailPage = model.Content.GetPropertyValue<IPublishedContent>("JobDetailPage_Content");

                var lookupValuesParser = new JobLookupValuesHtmlParser();
                var jobResultsParser = new JobResultsHtmlParser(detailPage != null ? new Uri(detailPage.UrlWithDomain()) : Request.Url);
                var jobsProvider = new JobsDataFromTalentLink(searchUrl, resultsUrl, new ConfigurationProxyProvider(), lookupValuesParser, jobResultsParser);

                jobs = await jobsProvider.ReadJobs(query);

                HttpContext.Cache.Insert(cacheKey, jobs, null, DateTime.Now.AddHours(1), Cache.NoSlidingExpiration);
            }
            else
            {
                jobs = (List<Job>) HttpContext.Cache[cacheKey];
            }
            return jobs;
        }
    }
}