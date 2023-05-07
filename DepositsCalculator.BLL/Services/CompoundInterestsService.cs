using DepositsCalculator.BLL.Services.Interfaces;
using DepositsCalculator.ViewModels;
using System;
using System.Collections.Generic;

namespace DepositsCalculator.BLL.Services
{
    public class CompoundInterestsService : IInterestsService
    {
        public InterestsType InterestType => InterestsType.Compound;

        public CalculatedInterestsViewModel Calculate(DepositViewModel deposit)
        {
            var result = new List<MonthlyDepositPaymentViewModel>();

            for (var i = 1; i <= deposit.Term; i++)
            {
                var percents = CalculatePercents((decimal)deposit.Balance, (decimal)deposit.Percents, i, out decimal monthlyPercents);

                result.Add(new MonthlyDepositPaymentViewModel()
                {
                    MonthNumber = i,
                    Percents = monthlyPercents,
                    TotalBalance = (decimal)deposit.Balance + percents,
                });

                if (i % 12 == 0)
                {
                    deposit.Balance += percents;
                }
            }

            return new CalculatedInterestsViewModel { Data = result };
        }

        private static decimal CalculatePercents(decimal initialAmount, decimal percents, int period, out decimal monthlyPercents)
        {
            var percent = initialAmount * (percents / 100) / 12;

            monthlyPercents = Math.Round(percent, 2);

            return Math.Round(percent * period, 2);
        }
    }
}
