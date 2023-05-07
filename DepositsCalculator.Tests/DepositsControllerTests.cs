using DepositsCalculator.ViewModels;
using System.Threading;
using DepositsCalculator.API.Controllers;
using DepositsCalculator.BLL.Services;
using DepositsCalculator.BLL.Services.Interfaces;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace DepositsCalculator.Tests
{
    [TestFixture]
    public class DepositsControllerTests
    {
        [Test]
        public void CalculateInterestAsync_FilledModel_ReturnsCalculatedData()
        {
            // Arrange
            var deposit = CreateFilledDepositModel();

            var interestsServiceFactoryMock = new Mock<IInterestsServiceFactory>();
            interestsServiceFactoryMock
                .Setup(f =>f.GetInterestsService((InterestsType)deposit.InterestType))
                .Returns(CreateSimpleInterestsService());

            var validatorMock = new Mock<IValidator<DepositViewModel>>();
            validatorMock
                .Setup(validator => validator.ValidateAsync(deposit, It.IsAny<CancellationToken>()))
                .ReturnsAsync(ReturnTrueValidationResult());

            var controller = new DepositsController(interestsServiceFactoryMock.Object, validatorMock.Object);

            // Act
            var controllerResponse = controller.CalculateInterestAsync(deposit).Result.As<OkObjectResult>();

            // Assert
            controllerResponse.StatusCode.Should().Be(200);
            controllerResponse.Value.Should().BeAssignableTo<CalculatedInterestsViewModel>();
        }

        [Test]
        public void CalculateInterestAsync_EmptyModel_ReturnsBadRequest()
        {
            // Arrange
            var deposit = CreateEmptyDepositModel();

            var interestsServiceFactoryMock = new Mock<IInterestsServiceFactory>();
            interestsServiceFactoryMock
                .Setup(f => f.GetInterestsService(InterestsType.Simple))
                .Returns(CreateSimpleInterestsService());

            var validatorMock = new Mock<IValidator<DepositViewModel>>();
            validatorMock
                .Setup(validator => validator.ValidateAsync(deposit, It.IsAny<CancellationToken>()))
                .ReturnsAsync(ReturnFalseValidationResult());

            var controller = new DepositsController(interestsServiceFactoryMock.Object, validatorMock.Object);

            // Act
            var controllerResponse = controller.CalculateInterestAsync(deposit).Result;

            // Assert
            controllerResponse.Should().BeAssignableTo<BadRequestObjectResult>();
        }

        private ValidationResult ReturnTrueValidationResult()
        {
            return new ValidationResult();
        }

        private IInterestsService CreateSimpleInterestsService()
        {
            return new SimpleInterestsService();
        }

        private DepositViewModel CreateFilledDepositModel()
        {
            return new DepositViewModel()
            {
                InterestType = InterestsType.Compound,
                Balance = 9999,
                Term = 99,
                Percents = 9
            };
        }

        private DepositViewModel CreateEmptyDepositModel()
        {
            return new DepositViewModel();
        }

        private ValidationResult ReturnFalseValidationResult()
        {
            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure("SomeProperty", "SomeError"));

            return result;
        }
    }
}
