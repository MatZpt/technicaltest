using StorageService.Application.Dtos;
using StorageService.Domain.Entities;
using StorageService.Domain.Interfaces;


namespace StorageService.Application
{
    public class StorageServiceApplication : IStorageServiceApplication
    {
        private readonly IFileEventRepository _eventRepository;

        public StorageServiceApplication(IFileEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task StoreEvent(UserInformationDto userInfoDto)
        {
            var userInfo = new UserInformation(DateTime.UtcNow, userInfoDto.Referrer, userInfoDto.UserAgent, userInfoDto.IPAddress);
            await _eventRepository.AppendEvent(userInfo);
        }
    }
}
