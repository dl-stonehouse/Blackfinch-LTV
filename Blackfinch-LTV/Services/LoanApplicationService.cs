using Blackfinch_LTV.Models;
using Blackfinch_LTV.Repositories;

namespace Blackfinch_LTV.Services
{
    public class LoanApplicationService : ILoanApplicationService
    {
        private readonly ILoanApplicationRepository _repository;
        private readonly ILogger<LoanApplicationService> _logger;

        public LoanApplicationService(ILoanApplicationRepository repository,
            ILogger<LoanApplicationService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public SystemStatus GetSystemStatus()
        {
            return _repository.GetCurrentSystemStatus();
        }

        public LoanApplicationResult SubmitLoanApplication(LoanApplication loanApplication)
        {
            if (loanApplication == null) { throw new ArgumentNullException(nameof(loanApplication)); }

            _repository.AddLoanApplication(loanApplication);

            if (!ValueOfLoanIsInBounds(loanApplication))
            {
                return LoanApplicationResult.CreateFail();
            }

            switch(loanApplication.LoanAmountRequested)
            {
                case int loanAmount when loanAmount >= 1000000:
                    if(loanApplication.LoanToValue > 60 || loanApplication.CreditScore < 950)
                        return LoanApplicationResult.CreateFail();
                    break;
                case int loanAmount when loanAmount < 1000000:
                    switch (loanApplication.LoanToValue)
                    {
                        case decimal ltv when ltv < 60m:
                            if(loanApplication.CreditScore < 750)
                                return LoanApplicationResult.CreateFail();
                            break;
                        case decimal ltv when ltv < 80m:
                            if (loanApplication.CreditScore < 800)
                                return LoanApplicationResult.CreateFail();
                            break;
                        case decimal ltv when ltv < 90m:
                            if (loanApplication.CreditScore < 900)
                                return LoanApplicationResult.CreateFail();
                            break;
                        case decimal ltv when ltv >= 90m:
                            return LoanApplicationResult.CreateFail();
                    }
                    break;
            }

            _repository.UpdateLoanApplicationStatus(loanApplication, true);

            return LoanApplicationResult.CreateSuccess();
        }

        private static bool ValueOfLoanIsInBounds(LoanApplication loanApplication)
        {
            return loanApplication.LoanAmountRequested >= 100000 && loanApplication.LoanAmountRequested <= 1500000;
        }
    }
}
