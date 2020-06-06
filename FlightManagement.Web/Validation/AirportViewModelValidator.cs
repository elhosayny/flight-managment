using FlightManagement.Web.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Web.Validation
{
    public class AirportViewModelValidator : AbstractValidator<AirportViewModel>
    {
        public AirportViewModelValidator()
        {
            RuleFor(airport => airport.Name).NotEmpty().MinimumLength(3).MaximumLength(30);
        }
    }
}
