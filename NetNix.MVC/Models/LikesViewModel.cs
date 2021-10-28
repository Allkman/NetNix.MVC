using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNix.MVC.Models
{
    public class LikesViewModel
    {
        public Guid MovieId { get; set; }
        public int Like { get; set; }
    }
}
