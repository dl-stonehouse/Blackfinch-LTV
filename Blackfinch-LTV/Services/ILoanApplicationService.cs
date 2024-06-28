using Blackfinch_LTV.Models;

namespace Blackfinch_LTV.Services
{
    public interface ILoanApplicationService
    {
        LoanApplicationResult SubmitLoanApplication(LoanApplication loanApplication);

        SystemStatus GetSystemStatus();
    }
}
