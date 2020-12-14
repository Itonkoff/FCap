namespace BMS.AccountSpecifications {
    public class SavingsSpecification:Base {
        public void Initialize()
        {
            MinimumPay = 1000;
            MaximumWithdrawalLimit = 1000;
            WithdrawalChargePercentage = 3.05;
            OverdraftPercentageLimit = 0;
            BookBalance = 50;
        }
    }
}