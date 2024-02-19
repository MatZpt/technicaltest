using Microsoft.AspNetCore.Mvc;
using PixelService.Application;

namespace PixelService.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class PixelController : ControllerBase
    {
        private readonly IPixelAppService _pixelAppService;

        public PixelController(IPixelAppService pixelAppService)
        {
            _pixelAppService = pixelAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Track()
        {
            try
            {

                var transparentPixel = await _pixelAppService.GetPixelAsync(HttpContext);
                return File(transparentPixel, "image/gif");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
