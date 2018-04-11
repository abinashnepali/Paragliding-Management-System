using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Paragliding_Management_System.Controllers
{
    public class SearchPilotController : Controller
    {
        SearchPilot dbObj = new SearchPilot();

        [HttpGet]
        [Route("api/pilot/search")]
        public IEnumerable<Staff> Index(int? offSet)
        {
            offSet = offSet == null ? 0 : offSet;
            return dbObj.Index(offSet);
        }
    }
}