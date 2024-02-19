

using StorageService.Domain.Entities;

namespace StorageService.Domain.Interfaces
{
    public interface IFileEventRepository
    {
        Task AppendEvent(UserInformation visitEvent);
    }
}
