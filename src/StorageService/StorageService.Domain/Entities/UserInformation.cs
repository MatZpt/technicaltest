
namespace StorageService.Domain.Entities
{
    public class UserInformation
    {
        public DateTime VisitDateTime { get; }
        public string Referrer { get; }
        public string UserAgent { get; }
        public string IPAddress { get; }

        public UserInformation(DateTime visitDateTime, string referrer, string userAgent, string ip)
        {
            VisitDateTime = visitDateTime;
            Referrer = referrer;
            UserAgent = userAgent;
            IPAddress = ip;
        }
    }

}
