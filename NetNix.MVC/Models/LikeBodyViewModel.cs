using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNix.MVC.Models
{
    public class LikeBodyViewModel
    {
        public string UserName { get; set; }
        public Guid MovieId { get; set; }
    }
}
