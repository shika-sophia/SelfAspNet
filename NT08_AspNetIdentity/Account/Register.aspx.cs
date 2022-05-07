using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using NT08_AspNetIdentity.Models;

namespace NT08_AspNetIdentity.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser()
                { UserName = Email.Text,
                  Email = Email.Text,
                  Url = Url.Text };

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // アカウント確認とパスワード リセットを有効にする方法の詳細については、https://go.microsoft.com/fwlink/?LinkID=320771 を参照してください
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "アカウントの確認", "このリンクをクリックすることによってアカウントを確認してください <a href=\"" + callbackUrl + "\">こちら</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

    }//class
}