using StorageService.Application.Dtos;

namespace StorageService.Application
{
    public interface IStorageServiceApplication
    {
        Task StoreEvent(UserInformationDto userInfoDto);
    }
}
