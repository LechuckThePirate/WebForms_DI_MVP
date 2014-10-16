using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeathStarService.Models;

namespace DeathStarService.Controllers
{
    public class SkywalkerAlertController : ApiController
    {
        // POST api/skywalkeralert
        public void Post([FromBody]SkywalkerAlert entity)
        {
        }
    }
}
