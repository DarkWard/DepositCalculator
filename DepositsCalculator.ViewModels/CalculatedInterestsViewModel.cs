using System.Collections.Generic;

namespace DepositsCalculator.ViewModels
{
    public class CalculatedInterestsViewModel
    {
        public IEnumerable<MonthlyDepositPaymentViewModel> Data { get; set; }
    }
}
