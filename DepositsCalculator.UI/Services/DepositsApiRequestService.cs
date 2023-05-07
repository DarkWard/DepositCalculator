using DepositsCalculator.UI.Services.Interfaces;
using DepositsCalculator.ViewModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DepositsCalculator.UI.Services
{
    public class DepositsApiRequestService : IDepositsApiRequestService
    {
        private readonly HttpClient _client;

        private const string CalculatePercentsUrl = "deposits/calculate-percents";

        public DepositsApiRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CalculatedInterestsViewModel> GetInterestCalculation(DepositViewModel deposit)
        {
            CalculatedInterestsViewModel result = new();

            var json = JsonSerializer.Serialize(deposit);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PostAsync(
                $"{_client.BaseAddress}/{CalculatePercentsUrl}",
                content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<CalculatedInterestsViewModel>(apiResponse);
                }
                catch (JsonSerializationException)
                {
                }
            }

            return result;
        }
    }
}