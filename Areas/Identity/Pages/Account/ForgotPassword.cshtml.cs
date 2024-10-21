#nullable disable

using Acesvv.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Mvc_ConfRec.Servicos;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;

namespace Acesvv.Areas.Identity.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<UsuarioModel> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public ForgotPasswordModel(UserManager<UsuarioModel> userManager, IEmailSender emailSender, IConfiguration configuration)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);

                if (user != null)
                {
                    ServicoEmail servicoEmail = new ServicoEmail(_configuration);
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ResetPassword",
                        pageHandler: null,
                        values: new { area = "Identity", code },
                        protocol: Request.Scheme);

                    var assunto = "Redefinir senha";
                    var msgCorpo = $"Por favor, redefina sua senha <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicando aqui</a>.";

                    servicoEmail.enviaEmail(user.Email, assunto, msgCorpo, null, null, null, "");
                }

                
                return RedirectToPage("./ForgotPasswordConfirmation", new { area = "Identity", email = Input.Email });
            }

            return Page();
        }
    }
}
