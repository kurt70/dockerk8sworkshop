using System.Threading.Tasks;

namespace PiCalculatorAPI.Services
{
    public interface IMetricsService
    {
        Task LogMetrics(string seriesName, string meassurementName, int value);
    }
}