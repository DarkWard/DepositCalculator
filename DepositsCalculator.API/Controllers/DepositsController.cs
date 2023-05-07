using DepositsCalculator.API.Validations;
using DepositsCalculator.BLL.Services.Interfaces;
using DepositsCalculator.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DepositsCalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepositsController : Controller
    {
        private readonly IInterestsServiceFactory _interestsServiceFactory;
        private readonly IValidator<DepositViewModel> _validator;

        public DepositsController(IInterestsServiceFactory interestsServiceFactory, IValidator<DepositViewModel> validator)
        {
            _interestsServiceFactory = interestsServiceFactory;
            _validator = validator;
        }

        [HttpPost("calculate-percents")]
        [ProducesResponseType(typeof(CalculatedInterestsViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateInterestAsync(DepositViewModel deposit)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(deposit);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);

                return BadRequest(validationResult.ToString());
            }

            var interestService = _interestsServiceFactory.GetInterestsService((InterestsType)deposit.InterestType);

            var result = interestService.Calculate(deposit);

            return Ok(result);
        }
    }
}