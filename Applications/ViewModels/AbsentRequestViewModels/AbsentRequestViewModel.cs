using Domain.Enums.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.ViewModels.AbsentRequestViewModels
{
    public class AbsentRequestViewModel
    {
        public string? absentReason { get; set; }
        public ReportStatus reportStatus { get; set; }
        public RequestType requestType { get; set; }
        public DateTime date { get; set; }
        public int userId { get; set; }
    }
}
