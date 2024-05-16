using Domain.Base;

namespace Domain.Entities
{
    public class Furlough : BaseEntity
    {
        public int totalFurloughDay { get; set; }
        public int remainFurlough { get; set; }
        public int usedFurlough { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}
