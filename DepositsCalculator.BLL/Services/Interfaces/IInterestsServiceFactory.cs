using DepositsCalculator.ViewModels;

namespace DepositsCalculator.BLL.Services.Interfaces
{
    public interface IInterestsServiceFactory
    {
        IInterestsService GetInterestsService(InterestsType depositType);
    }
}
