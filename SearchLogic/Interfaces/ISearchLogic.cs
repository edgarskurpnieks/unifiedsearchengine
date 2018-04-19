using System.Collections.Generic;

namespace Ultimate.Search.Processors.Interfaces
{
    public interface ISearchLogic
    {
        List<Document> DoSearch(string query);
    }
}