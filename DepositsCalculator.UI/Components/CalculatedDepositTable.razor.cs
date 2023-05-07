using DepositsCalculator.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DepositsCalculator.UI.Components
{
    public partial class CalculatedDepositTable
    {
        [Parameter]
        public CalculatedInterestsViewModel CalculatedInterestsList { get; set; } = new();
    }
}
