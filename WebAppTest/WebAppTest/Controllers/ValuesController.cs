using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTest.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return $"Hello from : {System.Environment.MachineName}.";
        }
    }
}
