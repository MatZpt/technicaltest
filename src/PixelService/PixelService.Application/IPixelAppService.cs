using Microsoft.AspNetCore.Http;

namespace PixelService.Application
{
    public interface IPixelAppService
    {
        Task<byte[]> GetPixelAsync(HttpContext context);
    }
}