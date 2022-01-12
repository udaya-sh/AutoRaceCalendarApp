using FluentValidation;


namespace AutoRaceCalendarApp.UI.Models.Validators
{
    public class SeasonViewModelValidator : AbstractValidator<SeasonViewModel>
    {
        public SeasonViewModelValidator()
        {
            RuleFor(x => x.Name).Matches("[a-zA-Z][a-zA-Z ]+").WithMessage("Please input alphabet characters only and the length of the field name should be between 2 and 25 characters long");
            RuleFor(x => x.Name).Length(2, 50).WithMessage("The length of the field name should be between 2 and 25 characters long");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start date is required");
            RuleFor(x => x.SerieId).GreaterThan(0).WithMessage("Serie Id can't be 0");
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("End date is required").GreaterThan(x => x.StartDate).WithMessage("End date must be after the start date");


        }
    }
}
