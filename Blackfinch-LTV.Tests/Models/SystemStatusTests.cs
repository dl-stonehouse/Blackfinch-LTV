using Blackfinch_LTV.Models;

namespace Blackfinch_LTV.Tests.Models
{
    public class SystemStatusTests
    {
        [Test]
        public void SuccessfulAndFailedApplicationsAreCorrectlyReported()
        {
            var totalApplications = Enumerable.Repeat(LoanApplication.CreateApplication(100000, 500000, 500), 10).ToList();
            var successfulApplications = Enumerable.Repeat(LoanApplication.CreateApplication(100000, 500000, 500), 7).ToList();

            var systemStatus = SystemStatus.Create(totalApplications, successfulApplications);

            Assert.That(systemStatus.TotalNumberOfSuccessfulApplications, Is.EqualTo(7));
            Assert.That(systemStatus.TotalNumberOfFailedApplications, Is.EqualTo(3));
        }

        [Test]
        public void AverageLTVIsCorrectlyCalculated()
        {
            var totalApplications = Enumerable.Repeat(LoanApplication.CreateApplication(100000, 500000, 500), 9)
                .Concat(Enumerable.Repeat(LoanApplication.CreateApplication(100000, 200000, 500), 1)).ToList();

            var successfulApplications = Enumerable.Repeat(LoanApplication.CreateApplication(100000, 500000, 500), 0).ToList();

            var systemStatus = SystemStatus.Create(totalApplications, successfulApplications);

            Assert.That(systemStatus.AverageLTV, Is.EqualTo(23m));
        }

        [Test]
        public void TotalNumberOfWrittenLoansCorrectlyCalculated()
        {
            var totalApplications = Enumerable.Repeat(LoanApplication.CreateApplication(100000, 500000, 500), 9)
                .Concat(Enumerable.Repeat(LoanApplication.CreateApplication(100000, 200000, 500), 1)).ToList();

            var successfulApplications = Enumerable.Repeat(LoanApplication.CreateApplication(100000, 500000, 500), 1).ToList();

            var systemStatus = SystemStatus.Create(totalApplications, successfulApplications);

            Assert.That(systemStatus.TotalValueOfWrittenLoans, Is.EqualTo(100000));
        }
    }
}
