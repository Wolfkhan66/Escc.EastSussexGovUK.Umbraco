using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Examine;
using Examine.SearchCriteria;

namespace Escc.EastSussexGovUK.Umbraco.Jobs.Examine
{
    public class JobsDataFromExamine : IJobsDataProvider
    {
        private readonly ISearcher _searcher;
        private readonly Uri _jobAdvertUrl;

        public JobsDataFromExamine(ISearcher searcher, Uri jobAdvertUrl)
        {
            if (searcher == null) throw new ArgumentNullException(nameof(searcher));
            _searcher = searcher;
            _jobAdvertUrl = jobAdvertUrl;
        }

        public Task<Job> ReadJob(string jobId)
        {
            return Task.FromResult(new Job());
        }

        public Task<List<Job>> ReadJobs(JobSearchQuery query)
        {
            var examineQuery = _searcher.CreateSearchCriteria(BooleanOperation.And);

            // Add a wildcard after each keyword so that, for example, "teacher" also matches "teachers"
            var keywords = query.Keywords ?? String.Empty;
            keywords = Regex.Replace(keywords, @"([^\s])\b", "$1*");

            examineQuery.GroupedOr(new[] { "reference", "title", "organisation", "location", "salary", "jobType", "contractType", "department", "fullText" }, keywords)
                        .And().GroupedOr(new[] { "location" }, query.Locations.ToArray())
                        .And().GroupedOr(new[] { "jobType" }, query.JobTypes.ToArray())
                        .And().GroupedOr(new[] { "organisation" }, query.Organisations.ToArray());

            // If any of the GroupedOr values are empty, Examine generates a Lucene query that requires no field set to no value: +()
            // so we need to remove that and use the rest of the generated Lucene query
            var generatedQuery = examineQuery.ToString();
            generatedQuery = generatedQuery.Substring(34, generatedQuery.Length - 36);
            var modifiedQuery = generatedQuery.Replace("+()", String.Empty);

            // For the salary ranges we need a structure that Examine's fluent API can't build, so build the raw Lucene query instead
            modifiedQuery += BuildSalaryRangeLuceneQuery(query.SalaryRanges);

            // For the working patterns we also need to build the raw Lucene query
            modifiedQuery += BuildWorkPatternLuceneQuery(query.WorkPatterns);

            var luceneQuery = _searcher.CreateSearchCriteria(BooleanOperation.And);

            // If no search criteria, use a query that returns everything
            const string everything = "__NodeId:[0 TO 999999]";

            var sortField = String.Empty;
            switch (query.SortBy)
            {
                case JobSearchQuery.JobsSortOrder.JobTitleAscending:
                case JobSearchQuery.JobsSortOrder.JobTitleDescending:
                    sortField = "title";
                    break;
                case JobSearchQuery.JobsSortOrder.OrganisationAscending:
                case JobSearchQuery.JobsSortOrder.OrganisationDescending:
                    sortField = "organisation";
                    break;
                case JobSearchQuery.JobsSortOrder.LocationAscending:
                case JobSearchQuery.JobsSortOrder.LocationDescending:
                    sortField = "locationDisplay";
                    break;
                case JobSearchQuery.JobsSortOrder.SalaryRangeAscending:
                case JobSearchQuery.JobsSortOrder.SalaryRangeDescending:
                    sortField = "salarySort";
                    break;
                case JobSearchQuery.JobsSortOrder.WorkPatternAscending:
                case JobSearchQuery.JobsSortOrder.WorkPatternDescending:
                    sortField = "workPattern";
                    break;
                case JobSearchQuery.JobsSortOrder.ClosingDateAscending:
                case JobSearchQuery.JobsSortOrder.ClosingDateDescending:
                    sortField = "closingDate";
                    break;
            }


            switch (query.SortBy)
            {
                case JobSearchQuery.JobsSortOrder.JobTitleAscending:
                case JobSearchQuery.JobsSortOrder.OrganisationAscending:
                case JobSearchQuery.JobsSortOrder.LocationAscending:
                case JobSearchQuery.JobsSortOrder.SalaryRangeAscending:
                case JobSearchQuery.JobsSortOrder.WorkPatternAscending:
                case JobSearchQuery.JobsSortOrder.ClosingDateAscending:
                    if (String.IsNullOrWhiteSpace(modifiedQuery))
                    {
                        luceneQuery.RawQuery(everything).OrderBy(sortField);
                    }
                    else
                    {
                        luceneQuery.RawQuery(modifiedQuery).OrderBy(sortField);
                    }
                    break;
                case JobSearchQuery.JobsSortOrder.JobTitleDescending:
                case JobSearchQuery.JobsSortOrder.OrganisationDescending:
                case JobSearchQuery.JobsSortOrder.LocationDescending:
                case JobSearchQuery.JobsSortOrder.SalaryRangeDescending:
                case JobSearchQuery.JobsSortOrder.WorkPatternDescending:
                case JobSearchQuery.JobsSortOrder.ClosingDateDescending:
                    if (String.IsNullOrWhiteSpace(modifiedQuery))
                    {
                        luceneQuery.RawQuery(everything).OrderByDescending(sortField);
                    }
                    else
                    {
                        luceneQuery.RawQuery(modifiedQuery).OrderByDescending(sortField);
                    }
                    break;
                default:
                    if (String.IsNullOrWhiteSpace(modifiedQuery))
                    {
                        luceneQuery.RawQuery(everything);
                    }
                    else
                    {
                        luceneQuery.RawQuery(modifiedQuery);
                    }
                    break;
            }

            var results = _searcher.Search(luceneQuery);

            var jobs = new List<Job>();
            foreach (var result in results)
            {
                var job = new Job()
                {
                    Id = result.Fields.ContainsKey("id") ? result["id"] : String.Empty,
                    Reference = result.Fields.ContainsKey("reference") ? result["reference"] : String.Empty,
                    JobTitle = result.Fields.ContainsKey("title") ? result["title"] : String.Empty,
                    Organisation = result.Fields.ContainsKey("organisation") ? result["organisation"] : String.Empty,
                    Location = result.Fields.ContainsKey("locationDisplay") ? result["locationDisplay"] : String.Empty,
                    JobType = result.Fields.ContainsKey("jobType") ? result["jobType"] : String.Empty,
                    ContractType = result.Fields.ContainsKey("contractType") ? result["contractType"] : String.Empty,
                    Department = result.Fields.ContainsKey("department") ? result["department"] : String.Empty,
                    WorkPattern = new WorkPattern()
                    {
                        IsFullTime = result.Fields.ContainsKey("fullTime") && result["fullTime"].ToUpperInvariant() == "TRUE",
                        IsPartTime = result.Fields.ContainsKey("partTime") && result["partTime"].ToUpperInvariant() == "TRUE"
                    } 
                };

                job.Salary.SalaryRange = result.Fields.ContainsKey("salary") ? result["salary"] : String.Empty;
                job.Salary.SearchRange = result.Fields.ContainsKey("salaryRange") ? result["salaryRange"] : String.Empty;
                if (_jobAdvertUrl != null)
                {
                    job.Url = new Uri(_jobAdvertUrl.ToString().TrimEnd(new[] {'/'}) + "/" + job.Id + "/" + Regex.Replace(job.JobTitle.ToLower(CultureInfo.CurrentCulture).Replace(" - ", "-").Replace(" ", "-"), "[^a-z0-9-]", String.Empty));
                }
                if (result.Fields.ContainsKey("closingDate")) job.ClosingDate = DateTime.Parse(result["closingDate"]);

                jobs.Add(job);
            }

            return Task.FromResult(jobs);
        }

        private string BuildWorkPatternLuceneQuery(IList<string> workPatterns)
        {
            var fullTime = workPatterns.Contains("Full time");
            var partTime = workPatterns.Contains("Part time");

            var workPatternQueries = new List<string>();
            if (fullTime)
            {
                workPatternQueries.Add("fullTime:True");
            }
            if (partTime)
            {
                workPatternQueries.Add("partTime:True");
            }

            var query = String.Empty;
            if (workPatternQueries.Count > 0)
            {
                query = " +(" + String.Join(" ", workPatternQueries.ToArray()) + ")";
            }
            return query;
        }

        private static string BuildSalaryRangeLuceneQuery(IList<string> salaryRanges)
        {
            var rangeQueries = new List<string>();
            foreach (var salaryRange in salaryRanges)
            {
                var numericRange = Regex.Match(salaryRange, "^�([0-9]+)-�?([0-9]*)$");
                if (numericRange.Success)
                {
                    try
                    {
                        var from = Int32.Parse(numericRange.Groups[1].Value, CultureInfo.InvariantCulture);
                        var to = String.IsNullOrEmpty(numericRange.Groups[2].Value) ? 9999999 : Int32.Parse(numericRange.Groups[2].Value, CultureInfo.InvariantCulture);
                        rangeQueries.Add($"(+salaryMin:[{@from.ToString("D7")} TO 9999999] +salaryMax:[0000000 TO {to.ToString("D7")}])");
                    }
                    catch (FormatException)
                    {
                        // just ignore bad input
                        continue;
                    }
                    catch (OverflowException)
                    {
                        // just ignore bad input
                        continue;
                    }
                }
                else
                {
                    var sanitisedRange = Regex.Replace(salaryRange, "[^A-Za-z0-9' -]", String.Empty); // sanitise input
                    rangeQueries.Add($"(+salaryRange:\"{sanitisedRange}\")");
                }
            }

            var query = String.Empty;
            if (rangeQueries.Count > 0)
            {
                query = " +(" + String.Join(" ", rangeQueries.ToArray()) + ")";
            }
            return query;
        }
    }
}