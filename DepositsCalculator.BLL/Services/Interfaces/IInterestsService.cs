using DepositsCalculator.ViewModels;

namespace DepositsCalculator.BLL.Services.Interfaces
{
    public interface IInterestsService
    {
        InterestsType InterestType { get; }

        CalculatedInterestsViewModel Calculate(DepositViewModel deposit);
    }
}
