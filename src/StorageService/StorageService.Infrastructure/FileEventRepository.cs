using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StorageService.Domain.Entities;
using StorageService.Domain.Interfaces;

namespace StorageService.Infrastructure
{
    public class FileEventRepository : IFileEventRepository
    {
        private readonly string _filePath;
        private readonly ILogger<FileEventRepository> _logger;

        public FileEventRepository(IOptions<FileEventOptions> options, ILogger<FileEventRepository> logger)
        {
            _filePath = options.Value.Path;
            _logger = logger;
        }

        public async Task AppendEvent(UserInformation visitEvent)
        {
            string logEntry = $"{visitEvent.VisitDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ")} | {visitEvent.Referrer ?? "null"} | {visitEvent.UserAgent ?? "null"} | {visitEvent.IPAddress}";

            try
            {
                using (StreamWriter writer = File.AppendText(_filePath))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while storing event");
                throw; // Rethrow exception to indicate failure
            }
        }
    }
}
