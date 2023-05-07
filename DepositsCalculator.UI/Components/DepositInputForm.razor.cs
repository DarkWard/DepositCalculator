using DepositsCalculator.UI.Services.Interfaces;
using DepositsCalculator.ViewModels;
using Microsoft.AspNetCore.Components;

namespace DepositsCalculator.UI.Components
{
    public partial class DepositInputForm
    {
        private DepositViewModel _deposit = new();

        [Inject]
        private IDepositsApiRequestService DepositsApiRequestService { get; set; }

        public CalculatedInterestsViewModel CalculatedInterests { get; set; } = new();

        [Parameter]
        public EventCallback<CalculatedInterestsViewModel> OnSendCalculatedInterests { get; set; }

        [Parameter]
        public EventCallback<bool> OnSendIfDataRequested { get; set; }

        public async void SubmitValidForm()
        {
            OnSendIfDataRequested.InvokeAsync(true);
            CalculatedInterests = new();
            OnSendCalculatedInterests.InvokeAsync(CalculatedInterests);

            var response = await DepositsApiRequestService.GetInterestCalculation(_deposit);

            if (response.Data != null)
            {
                CalculatedInterests = response;
                await OnSendCalculatedInterests.InvokeAsync(CalculatedInterests);
                OnSendIfDataRequested.InvokeAsync(false);
            }
        }
    }
}