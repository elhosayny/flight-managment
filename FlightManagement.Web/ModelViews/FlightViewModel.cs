using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Web.ModelViews
{
    public class FlightViewModel
    {
        public int FromAirportId { get; set; }
        public int ToAirportId { get; set; }
        public int AirplaneId { get; set; }
    }
}
