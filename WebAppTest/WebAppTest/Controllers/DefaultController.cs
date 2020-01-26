using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAppTest.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IConfiguration config;

        public DefaultController(IConfiguration config)
        {
            this.config = config;

        }
        
        [HttpGet]
        public ActionResult<string> DefaultGet()
        {
            var result = $"Hello from : {System.Environment.MachineName}.";
            return result;
        }

        [HttpGet]
        [Route("config")]
        public ActionResult<string> GetConfiguration()
        {
            var result = "Configuration" + System.Environment.NewLine;
            result += EnumerateConfig(config);
            return result;
        }

        private string EnumerateConfig(IConfiguration config)
        {
            var result = string.Empty;

            var list = config.AsEnumerable().ToList().OrderBy(x => x.Key).ToList();
            list.ForEach(x => result += $"{x.Key}={x.Value}");

            return result;            
        }
    }
}
