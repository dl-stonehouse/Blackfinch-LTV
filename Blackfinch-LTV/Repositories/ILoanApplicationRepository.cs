using Blackfinch_LTV.Models;

namespace Blackfinch_LTV.Repositories
{
    public interface ILoanApplicationRepository
    {
        public void AddLoanApplication(LoanApplication application);

        public void UpdateLoanApplicationStatus(LoanApplication application, bool status);

        public SystemStatus GetCurrentSystemStatus();
    }
}
