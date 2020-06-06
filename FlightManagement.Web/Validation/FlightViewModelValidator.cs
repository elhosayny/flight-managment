using FlightManagement.Web.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Web.Validation
{
    public class FlightViewModelValidator : AbstractValidator<FlightViewModel>
    {
        public FlightViewModelValidator()
        {
            RuleFor(flight => flight.AirplaneId).NotNull();
            RuleFor(flight => flight.FromAirportId).NotEmpty();
            RuleFor(flight => flight.ToAirportId).NotNull().Equal(500);
        }     
    }
}
