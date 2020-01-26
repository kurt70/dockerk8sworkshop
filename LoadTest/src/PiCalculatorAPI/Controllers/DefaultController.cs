using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PiCalculatorAPI.Services;

namespace PiCalculatorAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> log;
        private readonly IMetricsService service;

        public DefaultController(ILogger<DefaultController> log, IMetricsService svc)
        {
            this.log = log;
            this.service = svc;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> GetCalculatePi([FromQuery] int digits = 5)
        {
            try
            {
                log.LogInformation($"Starting GetCalculatePi with {digits} digits.");
                var pi = string.Empty;

                var sw = Stopwatch.StartNew();
                pi = CalculatePi(digits);
                sw.Stop();


                await service.LogMetrics("PiCalculatorAPI", "ResponseTimes", Convert.ToInt32(sw.ElapsedMilliseconds));
                log.LogInformation($"Finished GetCalculatePi in {sw.ElapsedMilliseconds} ms.");

                return pi;
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"GetCalculatePi failed beacuse of: {ex.Message}");
                throw;
            }
        }

        static string CalculatePi(int digits)
        {
            digits++;

            uint[] x = new uint[digits * 10 / 3 + 2];
            uint[] r = new uint[digits * 10 / 3 + 2];

            uint[] pi = new uint[digits];

            for (int j = 0; j < x.Length; j++)
                x[j] = 20;

            for (int i = 0; i < digits; i++)
            {
                uint carry = 0;
                for (int j = 0; j < x.Length; j++)
                {
                    uint num = (uint)(x.Length - j - 1);
                    uint dem = num * 2 + 1;

                    x[j] += carry;

                    uint q = x[j] / dem;
                    r[j] = x[j] % dem;

                    carry = q * num;
                }


                pi[i] = (x[x.Length - 1] / 10);


                r[x.Length - 1] = x[x.Length - 1] % 10; ;

                for (int j = 0; j < x.Length; j++)
                    x[j] = r[j] * 10;
            }

            var result = "";

            uint c = 0;

            for (int i = pi.Length - 1; i >= 0; i--)
            {
                pi[i] += c;
                c = pi[i] / 10;

                result = (pi[i] % 10).ToString() + result;
            }

            result = $"{result.Substring(0, 1)}.{result.Substring(1)}";

            return result;
        }
    }
}
