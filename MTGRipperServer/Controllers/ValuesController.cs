using MTGRipperServer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MTGRipperServer.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get(string q)
        {
            HttpContext.Current.Response.ContentType = "application/json";
            return RemoteAPIHelper.GetCardsInfo(q);            
        }

        // GET api/values/5
        public string Get(int id)
        {
            throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
        }
    }
}