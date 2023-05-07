using DepositsCalculator.ViewModels;

namespace DepositsCalculator.UI.Pages
{
    public partial class Interest
    {
        public CalculatedInterestsViewModel CalculatedInterests { get; set; } = new();

        public bool IsSpinnerEnabled { get; set; } = false;
    }
}
