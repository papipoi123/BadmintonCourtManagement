using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string paymentType { get; set; }
        public ICollection<Reservation?> Reservations { get; set; }
    }
}
