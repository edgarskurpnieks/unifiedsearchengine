using Elasticsearch.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Nest;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using Ultimate.Search.Processors;
using Ultimate.Search.Processors.Interfaces;

namespace Ultimate.Search
{
    public class Program
    {
        static readonly Container container;
        public static ElasticClient _client;
        private static string indexName = $"google";
        private static Random random = new Random();

        static Program()
        {
            // 1. Create a new Simple Injector container
            container = new Container();

            // 2. Configure the container (register)
            container.Register<ISearchLogic, SearchLogic>();

            // 3. Verify your configuration
            container.Verify();


            //var indexSettings = new IndexSettings();
            //indexSettings.NumberOfReplicas = 1;
            //indexSettings.NumberOfShards = 1;

            //var indexstate = new IndexState();
            //indexstate.Settings = indexSettings;

            //var connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost.fiddler:9200"));
            //var settings = new ConnectionSettings(connectionPool);
            ////settings.DisableAutomaticProxyDetection(false).Proxy(new Uri("http://localhost:8888"), "", "");
            //settings.DefaultIndex(indexName);
            //_client = new ElasticClient(settings);

            //if (!_client.IndexExists(indexName).Exists)
            //{
            //    var createIndexResponse = _client.CreateIndex(indexName, c => c
            //    .InitializeUsing(indexstate)
            //    .Mappings(ms => ms.Map<Document>(sm => sm
            //        .AllField(s => s
            //            .Enabled()
            //            .Analyzer("nGram_analyzer")
            //            .SearchAnalyzer("whitespace_analyzer")))));

            //    InsertDocument();
            //}
        }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


        public static void InsertDocument()
        {
            var lst = Populate();

            foreach (var obj in lst.Select((value, counter) => new { counter, value }))
            {
                _client.Index(obj.value, i => i
                    .Index(indexName)
                    .Type("document")
                    .Id(obj.counter));
            }

        }

        public static List<Document> Populate()
        {
            Random rnd = new Random();
            List<Document> result = new List<Document>();
            for (int i = 0; i < 200; i++)
            {
                result.Add(new Document { Data = RandomString(rnd.Next(1,200)), Test = RandomString(rnd.Next(1, 200)) });
            };
            return result;
        }

        private static string RandomString(int length)
        {
            const string chars = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
