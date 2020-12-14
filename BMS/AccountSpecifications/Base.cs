namespace BMS.AccountSpecifications {
    public class Base {
        public int MinimumPay { get; set; }
        public int MaximumWithdrawalLimit { get; set; }
        public double WithdrawalChargePercentage { get; set; }
        public int OverdraftPercentageLimit { get; set; }
        public int BookBalance { get; set; }
        public double MandatoryCharges = 2;
    }
}