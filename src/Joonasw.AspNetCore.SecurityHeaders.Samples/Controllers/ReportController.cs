using Joonasw.AspNetCore.SecurityHeaders.Samples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Joonasw.AspNetCore.SecurityHeaders.Samples.Controllers
{
    public class ReportController : ControllerBase
    {
        public IActionResult Csp(CspViolationReport report)
        {
            return Ok();
        }

        public IActionResult Hpkp(HpkpViolationReport report)
        {
            return Ok();
        }
    }
}
