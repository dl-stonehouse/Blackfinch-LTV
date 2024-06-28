using Blackfinch_LTV.Models;
using Blackfinch_LTV.Repositories;
using Blackfinch_LTV.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Blackfinch_LTV.Tests.Models
{
    public class LoanApplicationTests
    {
        [TestCase(5, 10, 50.0)]
        [TestCase(10, 10, 100.0)]
        [TestCase(3, 10000, 0.03)]
        public void LTVRatioIsCalculatedCorrectly(int requestedLoanAmount, int assetValueToSecurityLoanAgainst, decimal expectedValue)
        {
            var mockLogger = new Mock<ILogger<LoanApplicationService>>();
            var mockRepository = new Mock<ILoanApplicationRepository>();

            var loanApplication = LoanApplication.CreateApplication(requestedLoanAmount, assetValueToSecurityLoanAgainst, 0);

            Assert.That(loanApplication.LoanToValue, Is.EqualTo(expectedValue));
        }
    }
}
