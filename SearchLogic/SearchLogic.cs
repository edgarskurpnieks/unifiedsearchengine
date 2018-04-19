using Elasticsearch.Net;
using Nest;
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
            //var result = _client.Search<Document>(s => s
            //    .Query(y => y
            //        .MultiMatch(x => x
            //            .Fields(p => p.Fields(l => l.Data, ls => ls.Test))
            //            .Query(query)
            //            )
            //         )
            //    .From(1)			
            //    .Size(15));

            var result = _client.Search<Document>(s => s
               .Query(y => y
                   .MatchAll(x => x
                       .Name(query)
                       )
                    )
               .From(1)
               .Size(15));

            return result.Documents.Select(x => new Document() { Data = x.Data, Test = x.Test }).ToList();
        }
    }
}