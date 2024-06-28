namespace Blackfinch_LTV.Models
{
    public class LoanApplication
    {
        private LoanApplication(int loanAmountRequested, int assetValueToSecurityLoanAgainst, int creditScore, decimal loanToValue)
        {
            LoanAmountRequested = loanAmountRequested;
            AssetValueToSecurityLoanAgainst = assetValueToSecurityLoanAgainst;
            CreditScore = creditScore;
            LoanToValue = loanToValue;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public int LoanAmountRequested { get; }

        public int AssetValueToSecurityLoanAgainst { get; }

        public int CreditScore { get; }

        public decimal LoanToValue { get; }

        public static LoanApplication CreateApplication(int loanAmountRequested, int assetValueToSecurityLoanAgainst, int creditScore)
        {
            if (assetValueToSecurityLoanAgainst == 0)
                throw new InvalidOperationException("Asset Value cannot be zero");

            var loanToValue = ((decimal)loanAmountRequested / assetValueToSecurityLoanAgainst) * 100m;
            return new LoanApplication(loanAmountRequested, assetValueToSecurityLoanAgainst, creditScore, loanToValue);
        }
    }
}
