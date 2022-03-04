using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCPMWEBAPI.Controllers
{
    [RoutePrefix("values")]
    public class ValuesController : ApiController
    {


        //public IEnumerable<string> Allvalues ()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpGet]
        [Route("showvalues")]
        public HttpResponseMessage Allvalues()
        {
            ArrayList al = new ArrayList();
            al.Add("Values 1");
            al.Add("Values 2");
            return Request.CreateResponse(HttpStatusCode.OK, al);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
