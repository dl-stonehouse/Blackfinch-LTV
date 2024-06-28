namespace Blackfinch_LTV.Models
{
    public class LoanApplicationResult
    {
        public bool Success { get; internal set; }

        public static LoanApplicationResult CreateFail()
        {
            return new LoanApplicationResult { Success = false };
        }

        public static LoanApplicationResult CreateSuccess()
        {
            return new LoanApplicationResult { Success = true };
        }
    }
}
