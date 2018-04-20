using Elasticsearch.Net;
using Nest;
using Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using Ultimate.Search.Processors.Interfaces;

namespace Ultimate.Search.Processors
{
    public class SearchLogic : ISearchLogic
    {
        private readonly ElasticClient _client;
        private static Random random = new Random();

        public SearchLogic()
        {
            string indexName = $"google";
            var connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost.fiddler:9200"));
            var settings = new ConnectionSettings(connectionPool);
            // settings.DisableAutomaticProxyDetection(false).Proxy(new Uri("http://localhost:8888"), "", "");
            settings.DefaultIndex(indexName);
            _client = new ElasticClient(settings);
        }

        public List<Document> DoSearch(string query)
        {
            var allDocs = new List<Document>();
            ResultSets.caseDocuments.ForEach(x => x.DisplayType = "Case");
            ResultSets.pdfDocuments.ForEach(x => x.DisplayType = "Document");
            allDocs.AddRange(ResultSets.pdfDocuments);
            allDocs.AddRange(ResultSets.caseDocuments);
            allDocs.ForEach(x => x.Data += " " + x.Name + " " + x.Title + " " + x.objectType);
            return ResultSetFilter.FilterDocuments(allDocs, query);
        }
    }
}