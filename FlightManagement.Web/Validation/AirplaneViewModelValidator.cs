using FlightManagement.Domain.Entities;
using FlightManagement.Web.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagement.Web.Validation
{
    public class AirplaneViewModelValidator : AbstractValidator<AirplaneViewModel>
    {
        public AirplaneViewModelValidator()
        {
            RuleFor(airplane => airplane.Name).NotEmpty().MinimumLength(3).MaximumLength(30);
        }
    }
}
