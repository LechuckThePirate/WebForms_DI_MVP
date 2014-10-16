using System.Web.Http;
using System.Web.Mvc;
using ITCR.Domain.Entities;

namespace DeathStarRESTService.Controllers
{
    public class SkywalkerAlertController : ApiController
    {
        // POST api/skywalkeralert
        /// <summary>
        /// WebMethod that registers any attempt to register a citizen with Skywalker string on it...
        /// </summary>
        /// <param name="entity">Information entered by the user, ip, browser, etc..</param>
        /// <returns></returns>
        public JsonResult Post([FromBody]SkywalkerAlert entity)
        {
            Writer.Current.Write(entity);
            return new JsonResult() { Data = new {ok = true}, JsonRequestBehavior = JsonRequestBehavior.DenyGet};
        }
    }
}
