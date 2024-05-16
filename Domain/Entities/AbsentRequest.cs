using Domain.Base;
using Domain.Enums.Status;

namespace Domain.Entities
{
    public class AbsentRequest : BaseEntity
    {
        public string? absentReason { get; set; }
        public ReportStatus reportStatus { get; set; }
        public RequestType requestType { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
        public User Users { get; set; }
    }
}
