namespace DepositsCalculator.ViewModels
{
    public class DepositViewModel
    {
        public decimal? Balance { get; set; }

        public int? Term { get; set; }

        public decimal? Percents { get; set; }

        public InterestsType? InterestType { get; set; }
    }
}