using Blackfinch_LTV.Models;
using Blackfinch_LTV.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blackfinch_LTV.Pages
{
    public class ApplicationModel : PageModel
    {
        [BindProperty]
        [Required]
        [Range(1, int.MaxValue)]
        public int LoanAmountRequested { get; set; }

        [BindProperty]
        [Required]
        [Range(1, int.MaxValue)]
        public int AssetValueToSecurityLoanAgainst { get; set; }

        [BindProperty]
        [Required]
        [Range(1, 999)]
        public int CreditScore { get; set; }

        private readonly ILogger<ApplicationModel> _logger;

        private ILoanApplicationService _applicationService;

        public ApplicationModel(ILoanApplicationService applicationService, ILogger<ApplicationModel> logger)
        {
            if (applicationService == null) { throw new ArgumentNullException(nameof(applicationService)); }

            _applicationService = applicationService;
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var loanApplication = LoanApplication.CreateApplication(LoanAmountRequested, AssetValueToSecurityLoanAgainst, CreditScore);
            var applicationResult = _applicationService.SubmitLoanApplication(loanApplication);

            if (applicationResult.Success)
                return RedirectToPage("./SuccessfulApplication");
            else 
            {
                return RedirectToPage("./FailedApplication");
            }
        }
    }
}
