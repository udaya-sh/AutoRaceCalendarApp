using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoRaceCalendarApp.UI.Models.Validators
{
    public class SerieViewModelValidator : AbstractValidator<SerieViewModel>
    {

        public SerieViewModelValidator()
        {
            RuleFor(x => x.Name).Matches("[a-zA-Z][a-zA-Z ]+").WithMessage("Please input alphabet characters only and the length of the field name should be between 2 and 25 characters long");
            RuleFor(x => x.Name).Length(2, 50).WithMessage("The length of the field name should be between 2 and 25 characters long");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start date is required");
            //RuleFor(x => x.EndDate).Empty().GreaterThan(x => x.StartDate).WithMessage("End date must be after the start date");
            RuleFor(x => x.SortOrder).GreaterThan(0).WithMessage("Sort order can't be 0");

        }
    }
}
