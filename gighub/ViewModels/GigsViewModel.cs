using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gighub.Models;

namespace gighub.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> upcomingGigs { get; set; }
        public bool showActions { get; set; }
        public string Heading { get; set; }
    }
}