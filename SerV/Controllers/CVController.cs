using Microsoft.AspNetCore.Mvc;
using SerV.Services.Interfaces;

namespace SerV.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CVController : Controller
    {
        private readonly IAccessCodeService _accessCodeService;
        private readonly ICVService _cvService;

        public CVController(
            IAccessCodeService accessCodeService,
            ICVService cvService)
        {
            _accessCodeService = accessCodeService;
            _cvService = cvService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCV(string code)
        {
            var accessCode = await _accessCodeService.GetAccessCodeByCode(code);

            if (accessCode is null || accessCode.IsExpired)
            {
                return Unauthorized();
            }

            var cv = await _cvService.GetCVByAccessCode(accessCode);

            return Json(cv);
        }
    }
}
