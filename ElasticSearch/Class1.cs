using System;
using Elasticsearch.Net;

namespace Search
{
    public class Class1
    {
        public void temp()
        {
            var client = new ElasticLowLevelClient();

            //index a document under /myindex/mytype/1
            var indexResponse = client.Search<ESData>("google", "text", "1");
        }
    }
}
