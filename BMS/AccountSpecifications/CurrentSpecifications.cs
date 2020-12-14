namespace BMS.AccountSpecifications {
    public class CurrentSpecification:Base {
        public void Initialize()
        {
            MinimumPay = 10000;
            MaximumWithdrawalLimit = 1500;
            WithdrawalChargePercentage = 4.23;
            OverdraftPercentageLimit = 10;
            BookBalance = 0;
        }
    }
}