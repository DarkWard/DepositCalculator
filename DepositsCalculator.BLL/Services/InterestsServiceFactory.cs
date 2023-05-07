using DepositsCalculator.BLL.Services.Interfaces;
using DepositsCalculator.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DepositsCalculator.BLL.Services
{
    public class InterestsServiceFactory : IInterestsServiceFactory
    {
        private readonly IEnumerable<IInterestsService> _interestsServices;

        public InterestsServiceFactory(IEnumerable<IInterestsService> interestsServices)
        {
            _interestsServices = interestsServices;
        }

        public IInterestsService GetInterestsService(InterestsType depositType)
        {
            return _interestsServices.First(x => x.InterestType == depositType);
        }
    }
}
