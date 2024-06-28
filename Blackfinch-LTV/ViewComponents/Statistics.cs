using Blackfinch_LTV.Models;
using Blackfinch_LTV.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blackfinch_LTV.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly ILogger<StatisticsViewComponent> _logger;
        private readonly ILoanApplicationService _loanApplicationService;
        public StatisticsViewComponent(ILoanApplicationService loanApplicationService,
            ILogger<StatisticsViewComponent> logger)
        {
            _logger = logger;
            _loanApplicationService = loanApplicationService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var systemStatus = _loanApplicationService.GetSystemStatus();

            return View(systemStatus);
        }
    }
}