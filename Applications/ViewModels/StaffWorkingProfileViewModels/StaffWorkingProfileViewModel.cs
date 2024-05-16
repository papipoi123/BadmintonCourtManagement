using Domain.Entities;
using Domain.Enums.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.ViewModels.StaffWorkingProfileViewModels
{
	public class StaffWorkingProfileViewModel
	{
		public int totalPresent { get; set; }
		public int totalAbsent { get; set; }
		public double totalSalary { get; set; }
		public RetireStatus retireStatus { get; set; }
		public int userId { get; set; }
	}
}
