using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.InfluxDb.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PiCalculatorAPI.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiCalculatorAPI.Services
{
    public class MetricsService : IMetricsService
    {
        private InfluxDbConfig config;
        private ILogger<MetricsService> log;
        private InfluxDbClient influxDbClient;

        public MetricsService(IOptions<InfluxDbConfig> config, ILogger<MetricsService> log)
        {
            this.config = config.Value;
            this.log = log;
        }

        public async Task LogMetrics(string seriesName, string meassurementName, int value)
        {
            try
            {
                if (influxDbClient == null)
                {
                    influxDbClient = await CreateClient();
                }

                var pointToWrite = new Point()
                {
                    Name = seriesName,
                    Tags = new Dictionary<string, object>()
                    {
                        { "host", System.Environment.MachineName }
                    },
                    Fields = new Dictionary<string, object>()
                    {
                        { "execution_time", value }
                    },
                    Timestamp = DateTime.UtcNow
                };

                await influxDbClient.Client.WriteAsync(pointToWrite, config.DatabaseInfo.DatabaseName, config.DatabaseInfo.RetentionPolicyName);

            }
            catch (Exception ex)
            {
                influxDbClient = null;
                log.LogError(ex, $"Connecting to {config.Url} failed.");
                throw;
            }

        }

        private async Task<InfluxDbClient> CreateClient()
        {
            influxDbClient = new InfluxDbClient(config.Url, config.UserName, config.Password, InfluxDbVersion.Latest);

            await CreateDb(config.DatabaseInfo);

            return influxDbClient;
        }

        private async Task CreateDb(DatabaseConfig databaseInfo)
        {
            var db = await influxDbClient.Database.GetDatabasesAsync();
            if (!db.Any(x => x.Name == databaseInfo.DatabaseName))
            {
                var result = await influxDbClient.Database.CreateDatabaseAsync(databaseInfo.DatabaseName);
                if (!result.Success)
                {
                    influxDbClient = null;
                    log.LogError($"{result.StatusCode} - {result.Body}");
                    throw new Exception($"CreateDb failed :{result.StatusCode} - {result.Body}");
                }                
            }
            await CreateRetention(databaseInfo);
        }

        private async Task CreateRetention(DatabaseConfig databaseInfo)
        {
            var rp = await influxDbClient.Retention.GetRetentionPoliciesAsync(databaseInfo.DatabaseName);
            if (!rp.Any(x => x.Name == databaseInfo.RetentionPolicyName))
            {
                var result = await influxDbClient.Retention.CreateRetentionPolicyAsync(databaseInfo.DatabaseName, databaseInfo.RetentionPolicyName, databaseInfo.RetentionString, 1);
                if (!result.Success)
                {
                    influxDbClient = null;
                    log.LogError($"{result.StatusCode} - {result.Body}");
                    throw new Exception($"Create retention policy failed :{result.StatusCode} - {result.Body}");
                }
            }
        }
    }
}
