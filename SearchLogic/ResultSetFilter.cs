using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Ultimate.Search.Processors;

namespace Processors
{
    class ResultSetFilter
    {
        public static List<Document> FilterDocuments(List<Document> allDocs, string query)
        {
            var result = new List<Document>();
            foreach (var doc in allDocs)
            {
                if (MatchDocument(doc, query))
                {
                    result.Add(doc);
                }
            }
            return result;
        }

        public static bool MatchDocument(Document doc, string query)
        {
            return MatchAll(doc.Data, query);
        }

        public static bool MatchAll(string data, string query)
        {
            var terms = Regex.Split(query, "[^a-zA-Z0-9-]");
            //var terms = query.Split(new[] { " ", ",", "" }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var term in terms)
            {
                if (data.IndexOf(term, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
