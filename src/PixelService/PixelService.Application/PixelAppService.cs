using Microsoft.AspNetCore.Http;
using PixelService.Domain.Entities;
using PixelService.Domain.Interfaces;


namespace PixelService.Application
{
    public class PixelAppService : IPixelAppService
    {
        private readonly IStorageService _storageService;

        public PixelAppService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<byte[]> GetPixelAsync(HttpContext context)
        {
            // Capture request information
            var referrer = context.Request.Headers["Referrer"];
            var userAgent = context.Request.Headers["User-Agent"];
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();

            var userInformation = new UserInformation
            {
                Referrer = referrer,
                UserAgent = userAgent,
                IPAddress = ipAddress
            };
            var transparentPixel = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAAALAAAAAABAAEAAAIBRAA7");

            await _storageService.StoreUserInformationAsync(userInformation);

            return transparentPixel;
        }
    }

}