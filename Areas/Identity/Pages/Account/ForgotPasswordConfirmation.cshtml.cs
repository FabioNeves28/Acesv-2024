#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acesvv.Areas.Identity.Pages.Account
{
   
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        public string Email { get; set; }

        public void OnGet(string email)
        {
            Email = email;
        }
    }

}
