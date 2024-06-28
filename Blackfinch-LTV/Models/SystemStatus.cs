namespace Blackfinch_LTV.Models
{
    public class SystemStatus
    {
        private SystemStatus(List<LoanApplication> totalApplications, List<LoanApplication> successfulApplications)
        {
            TotalNumberOfSuccessfulApplications = successfulApplications.Count;
            TotalNumberOfFailedApplications = totalApplications.Count - TotalNumberOfSuccessfulApplications;
            TotalValueOfWrittenLoans = successfulApplications.Sum(a => a.LoanAmountRequested);
            AverageLTV = totalApplications.Any() ? totalApplications.Average(a => a.LoanToValue) : 0;
        }

        public int TotalNumberOfSuccessfulApplications { get; }

        public int TotalNumberOfFailedApplications { get; }

        public int TotalValueOfWrittenLoans { get; }

        public decimal AverageLTV { get; }

        public static SystemStatus Create(List<LoanApplication> totalApplications, List<LoanApplication> successfulApplications)
        {
            return new SystemStatus(totalApplications, successfulApplications);
        }
    }
}
