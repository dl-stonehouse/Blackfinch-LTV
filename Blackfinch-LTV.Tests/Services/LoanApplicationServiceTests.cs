using Blackfinch_LTV.Repositories;
using Blackfinch_LTV.Services;
using Blackfinch_LTV.Models;
using Moq;
using Microsoft.Extensions.Logging;

namespace Blackfinch_LTV.Tests.Services
{
    public class LoanApplicationServiceTests
    {
        [TestCase(99999, 1000000, 999)]
        public void LoanIsDeclined(int requestedLoanAmount, int assetValueToSecurityLoanAgainst, int creditScore)
        {
            var mockLogger = new Mock<ILogger<LoanApplicationService>>();
            var mockRepository = new Mock<ILoanApplicationRepository>();

            var loanApplication = LoanApplication.CreateApplication(requestedLoanAmount, assetValueToSecurityLoanAgainst, creditScore);

            var service = new LoanApplicationService(mockRepository.Object, mockLogger.Object);

            var request = service.SubmitLoanApplication(loanApplication);

            Assert.False(request.Success);
        }

        [TestCase(100000, 1000000, 999)]
        public void LoanIsAccepted(int requestedLoanAmount, int assetValueToSecurityLoanAgainst, int creditScore)
        {
            var mockLogger = new Mock<ILogger<LoanApplicationService>>();
            var mockRepository = new Mock<ILoanApplicationRepository>();

            var loanApplication = LoanApplication.CreateApplication(requestedLoanAmount, assetValueToSecurityLoanAgainst, creditScore);

            var service = new LoanApplicationService(mockRepository.Object, mockLogger.Object);

            var request = service.SubmitLoanApplication(loanApplication);

            Assert.True(request.Success);
        }
    }
}
