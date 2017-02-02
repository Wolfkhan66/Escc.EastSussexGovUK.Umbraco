using System.Collections.Generic;

namespace Escc.EastSussexGovUK.Umbraco.Examine
{
    /// <summary>
    /// Helper to build up a query from search terms that have already been tokenised
    /// </summary>
    public interface ITokenisedQueryBuilder
    {
        /// <summary>
        /// Any of the search terms in the query must match the given field
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="isRequired">if set to <c>true</c> at least one search term was matched.</param>
        /// <returns></returns>
        string AnyOfTheseTermsInThisField(IList<string> searchTerms, string fieldName, bool isRequired);
        
        /// <summary>
        /// All of the search terms must match in the given field.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="isRequired">if set to <c>true</c> all search terms were matched.</param>
        /// <returns></returns>
        string AllOfTheseTermsInThisField(IList<string> searchTerms, string fieldName, bool isRequired);
        
        /// <summary>
        /// Any of the search terms in the query must match in at least one of the given fields
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="fieldNames">The field names.</param>
        /// <param name="isRequired">if set to <c>true</c> at least one search term was matched.</param>
        /// <returns></returns>
        string AnyOfTheseTermsInAnyOfTheseFields(IList<string> searchTerms, IList<string> fieldNames, bool isRequired);

        /// <summary>
        /// All of the search terms must match in any one of the given fields. Matching one term in one field and another in a second field will not be counted.
        /// </summary>
        /// <param name="searchTerms">The search terms.</param>
        /// <param name="fieldNames">The field names.</param>
        /// <param name="isRequired">if set to <c>true</c> all search terms were matched.</param>
        /// <returns></returns>
        string AllOfTheseTermsInAnyOfTheseFields(IList<string> searchTerms, IList<string> fieldNames, bool isRequired);
    }
}