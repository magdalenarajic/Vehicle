using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        

        // POST api/values
        

        // PUT api/values/5
       

        // DELETE api/values/5
        
    }
}