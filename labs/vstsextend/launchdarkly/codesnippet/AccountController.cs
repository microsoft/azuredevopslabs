// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using LaunchDarkly.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PartsUnlimited.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//test
namespace PartsUnlimited.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        static LdClient client = new LdClient("__YourLaunchDarklySDKKey__"); //LaunchDarkly API key

        //
        // GET: /Account/Login
        [AllowAnonymous]
        //public IActionResult Login(string returnUrl = null)
        //{
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(new LoginViewModel());
        //}
        public IActionResult Login(string returnUrl = null)
        {
            //LaunchDarkly start
            User user = LaunchDarkly.Client.User.WithKey("administrator@test.com");

            bool value = client.BoolVariation("member-portal", user, false);
            if (value)
            {
                ViewBag.Message = "Your application description page.";
                ViewData["togglevalue"] = value;
                ViewBag.ReturnUrl = returnUrl;
                return View(new LoginViewModel());
            }
            else
            {
                return NotFound();
            }

        }
        //LaunchDarkly end
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return View("Lockout");
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        //
        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyCode(string provider, bool rememberMe, string returnUrl = null)
        {
            var user = await SignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            // Remove before production
            ViewBag.Status = "For DEMO purposes the current " + provider + " code is: " + await UserManager.GenerateTwoFactorTokenAsync(user, provider);
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, model.RememberMe, model.RememberBrowser);

            if (result.Succeeded)
            {
                return RedirectToLocal(model.ReturnUrl);
            }

            if (result.IsLockedOut)
            {
                return View("Lockout");
            }

            ModelState.AddModelError("", "Invalid code.");
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    await MessageServices.SendEmailAsync(model.Email, "Confirm your account",
                        "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                    ViewBag.Link = callbackUrl;
                    ViewBag.Code = code;
                    ViewBag.UserId = user.Id;
                    return View("RegisterConfirmation");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { code = code }, protocol: HttpContext.Request.Scheme);

                await MessageServices.SendEmailAsync(model.Email, "Reset Password",
                                    "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                ViewBag.Link = callbackUrl;
                return View("ForgotPasswordConfirmation");
            }

            ModelState.AddModelError("", string.Format("We could not locate an account with email : {0}", model.Email));

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            //TODO: Fix this?
            var resetPasswordViewModel = new ResetPasswordViewModel() { Code = code };
            return code == null ? View("Error") : View(resetPasswordViewModel);
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(bool rememberMe, string returnUrl = null)
        {
            //TODO : Default rememberMe as well?
            var user = await SignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(user);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await SignInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                return View("Error");
            }

            // Generate the token and send it
            var code = await UserManager.GenerateTwoFactorTokenAsync(user, model.SelectedProvider);
            if (string.IsNullOrWhiteSpace(code))
            {
                return View("Error");
            }

            var message = "Your security code is: " + code;
            if (model.SelectedProvider == "Email")
            {
                await MessageServices.SendEmailAsync(await UserManager.GetEmailAsync(user), "Security Code", message);
            }
            else if (model.SelectedProvider == "Phone")
            {
                await MessageServices.SendSmsAsync(await UserManager.GetPhoneNumberAsync(user), message);
            }

            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            var info = await SignInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,
                isPersistent: false);
            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                // If the user does not have an account, then prompt the user to create an account
                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = info.LoginProvider;
                // REVIEW: handle case where email not in claims?
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl = null)
        {
            if (SignInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await SignInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user, info);

                    // If signed in with OpenIdConnect, make the user an Admin
                    if (string.Equals(info.LoginProvider, "OpenIdConnect", StringComparison.Ordinal))
                    {
                        await UserManager.AddClaimAsync(user, new Claim(Areas.Admin.AdminConstants.ManageStore.Name, Areas.Admin.AdminConstants.ManageStore.Allowed));
                    }

                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOff()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await UserManager.GetUserAsync(HttpContext.User);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}
