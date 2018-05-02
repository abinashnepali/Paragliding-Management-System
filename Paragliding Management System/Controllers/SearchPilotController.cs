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
        public IEnumerable<Staff> Index(int? offSet, DateTime date)
        {
            offSet = offSet == null ? 0 : offSet;
            return dbObj.Index(offSet, date);
        }

        [HttpPost]
        [Route("api/pilot/chkbookingstat")]
        public int ChkBookingStat([FromBody]Book book)
        {            
            return dbObj.ChkBookingStat(book);
        }
    }
}