using DepositsCalculator.ViewModels;
using System.Threading.Tasks;

namespace DepositsCalculator.UI.Services.Interfaces
{
    public interface IDepositsApiRequestService
    {
        public Task<CalculatedInterestsViewModel> GetInterestCalculation(DepositViewModel deposit);
    }
}
