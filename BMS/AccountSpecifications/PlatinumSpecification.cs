namespace BMS.AccountSpecifications {
    public class PlatinumSpecification : Base {
        public void Initialize()
        {
            MinimumPay = 50000;
            MaximumWithdrawalLimit = 3000;
            WithdrawalChargePercentage = 6;
            OverdraftPercentageLimit = 25;
            BookBalance = 0;
        }
    }
}