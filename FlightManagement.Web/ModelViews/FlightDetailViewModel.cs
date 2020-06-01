using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Web.ModelViews
{
    public class FlightDetailViewModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Distance { get; set; }
        public double KeroseneQuantity { get; set; }
    }
}
