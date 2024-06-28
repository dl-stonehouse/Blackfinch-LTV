using Blackfinch_LTV.Models;
using System.Collections.Concurrent;

namespace Blackfinch_LTV.Repositories
{
    public class LoanApplicationRepository : ILoanApplicationRepository
    {
        /// <summary>
        /// This will run for the lifetime of the application, however this would be a database
        /// Bool represents the loan application success
        /// </summary>
        private static readonly ConcurrentDictionary<LoanApplication, bool> _loanApplications = new();

        public void AddLoanApplication(LoanApplication application)
        {
            _loanApplications[application] = false;
        }

        public void UpdateLoanApplicationStatus(LoanApplication application, bool status)
        {
            _loanApplications[application] = status;
        }

        public SystemStatus GetCurrentSystemStatus()
        {
            //Takes a snapshot at this point
            var loanApplications = _loanApplications.AsReadOnly();

            //OK clunky but this is not real code
            var totalApplications = loanApplications.Keys.ToList();
            var successfulApplications = loanApplications.Where(v => v.Value).Select(k => k.Key).ToList();

            return SystemStatus.Create(totalApplications, successfulApplications);
        }
    }
}
