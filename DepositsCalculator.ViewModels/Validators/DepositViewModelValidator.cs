using FluentValidation;

namespace DepositsCalculator.ViewModels.Validators
{
    public class DepositViewModelValidator : AbstractValidator<DepositViewModel>
    {
        public DepositViewModelValidator()
        {
            RuleFor(x => x.Balance)
                .NotEmpty()
                .InclusiveBetween(1000, 1000000000);

            RuleFor(x => x.Term)
                .NotEmpty()
                .InclusiveBetween(1, 100);

            RuleFor(x => x.Percents)
                .NotEmpty()
                .InclusiveBetween(1, 200);

            RuleFor(x => x.InterestType)
                .NotEmpty()
                .IsInEnum();
        }
    }
}
