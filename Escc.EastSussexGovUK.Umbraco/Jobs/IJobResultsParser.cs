using System.IO;

namespace Escc.EastSussexGovUK.Umbraco.Jobs
{
    public interface IJobResultsParser
    {
        /// <summary>
        /// Parses jobs from the HTML stream.
        /// </summary>
        /// <param name="htmlStream">The HTML stream.</param>
        /// <returns></returns>
        JobsParseResult Parse(Stream htmlStream);
    }
}