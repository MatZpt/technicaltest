using PixelService.Domain.Entities;

namespace PixelService.Domain.Interfaces
{
    public interface IStorageService
    {
        Task StoreUserInformationAsync(UserInformation userInformation);
    }
}
