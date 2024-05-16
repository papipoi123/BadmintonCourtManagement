using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.ViewModels.FurloughViewModels
{
    public class FurloughViewModel
    {
        public int totalFurloughDay { get; set; }
        public int remainFurlough { get; set; }
        public int usedFurlough { get; set; }
        public int userId { get; set; }
    }
}
