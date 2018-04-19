using Elasticsearch.Net;

namespace Search
{
    public class ESData : IElasticsearchResponse
    {
        public ESData()
        {
        }

        public ESData(IApiCallDetails apiCall)
        {
            ApiCall = apiCall;
        }

        public IApiCallDetails ApiCall { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public bool TryGetServerErrorReason(out string reason)
        {
            throw new System.NotImplementedException();
        }
    }
}