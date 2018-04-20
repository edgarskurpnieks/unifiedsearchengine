using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Ultimate.Search.Processors;

namespace Processors
{
    class ResultSetFilter
    {
        /// <summary>
        /// Matches documents against query
        /// </summary>
        /// <param name="allDocs">Documents</param>
        /// <param name="query">Query</param>
        /// <returns></returns>
        public static List<Document> FilterDocuments(List<Document> allDocs, string query)
        {
            var result = new List<Document>();
            foreach (var doc in allDocs)
            {
                if (MatchDocumentData(doc, query))
                {
                    result.Add(doc);
                }
            }
            return result;
        }

        private static bool MatchDocumentData(Document doc, string query)
        {
            return MatchQuery(doc.Data, query);
        }

        private static bool MatchQuery(string data, string query)
        {
            var terms = Regex.Split(query, "[^a-zA-Z0-9-! ]").Where(s => s != String.Empty);
            
            foreach(var term in terms)
            {
                if (!MatchTerm(data, term))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool MatchTerm(string data, string term)
        {
            // if preceeded by ! then must not contain
            if(term[0] == '!')
            {
                return !MatchTerm(data, term.Substring(1));
            }

            if (data.IndexOf(term, StringComparison.OrdinalIgnoreCase) < 0)
            {
                return false;
            }

            return true;
        }
    }
}
