using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ultimate.Search.Processors.Interfaces;

namespace Launcher.Controllers
{
    public class Search : Controller
    {
        private readonly ISearchLogic _searchLogic;

        public Search(ISearchLogic searchLogic)
        {
            _searchLogic = searchLogic;
        }

        public IActionResult DoSearch(string searchQuery)
        {
            var result = _searchLogic.DoSearch(searchQuery);
            return new JsonResult(result);
        }
    }
}
