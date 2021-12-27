using FastReport.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastReport.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        [HttpGet(Name = "GetReport")]
        public MemoryStream Get()
        {
            var report = new ReportService();
            return report.Generate();
        }
    }
}
