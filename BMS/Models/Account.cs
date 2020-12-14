namespace BMS.Models {
    public interface Account {
        /// <summary>
        /// Account creation
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="idNumber"></param>
        /// <param name="payAmount"></param>
        public void Create(string firstName, string lastName, string idNumber, double payAmount);
        
        /// <summary>
        /// Deposit
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="Exception"></exception>
        public void Deposit(double amount);
        
        /// <summary>
        /// Withdrawal
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Withdraw(double amount);
        
        /// <summary>
        /// Check if a week has passed since last withdrawal
        /// </summary>
        /// <returns></returns>
        public bool AWeekHasPassed();
        
        /// <summary>
        /// Check if withdrawal wont over exhaust overdraft
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool WontExhaustOverdraft(double amount);
    }
}