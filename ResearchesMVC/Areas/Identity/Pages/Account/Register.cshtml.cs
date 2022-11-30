// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using ResearchesMVC.Areas.Identity.Data;
using ResearchesMVC.Models;


namespace ResearchesMVC.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplictionDbContext _context;

        //#1
        private readonly RoleManager<IdentityRole> _roleManager;

      

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,          
             ApplictionDbContext context,
             RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _roleManager = roleManager;


        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            
            [Required(ErrorMessage = "أدخل اسم الباحث")]
            [StringLength(500, ErrorMessage ="يجب أن لا يتجاوز الاسم 500 حرف")]
            [Display(Name="اسم الباحث")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "أدخل السجل المدني/ الإقامة")]
            [Display(Name = "رقم السجل المدني/الإقامة")]
            public int CardId { get; set; }

            [Required(ErrorMessage = "اختر الجنس ")]
            [Display(Name = "الجنس")]
            public Gender Gender { get; set; }

            [Required(ErrorMessage = "اختر المنطقة")]
            [Display(Name = "المنطقة")]
            public int StateId { get; set; }
            [ForeignKey("StateId")]
            public State State { get; set; }

            [Required(ErrorMessage = "اختر المحافظة")]
            [Display(Name = "المحافظة")]
            public int CityId { get; set; }
            [ForeignKey("CityId")]
            public City City { get; set; }

            //[Required(ErrorMessage = "أدخل رقم الجوال")]
            //[Display(Name = "رقم الجوال")]
            //public string Mobile { get; set; }

            [Required(ErrorMessage = "أدخل رقم الجوال")]
            [Display(Name = " رقم الجوال")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "أدخل العنوان")]
            [Display(Name = "العنوان")]
            public string Address { get; set; }

            [Required(ErrorMessage = "أدخل جهة العمل")]
            [Display(Name = "جهة العمل")]
            public string Jop { get; set; }

            [Required(ErrorMessage = "أدخل مقر العمل")]
            [Display(Name = "مقر العمل")]
            public string JopTitle { get; set; }

           
            [Required(ErrorMessage = "أدخل البريد الالكتروني")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "أدخل كلمة المرور")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "كلمة المرور غير متطابقة")]
            public string ConfirmPassword { get; set; }

            //#2 Role Name
            public string Name { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            //#3
            ViewData["roles"] = _roleManager.Roles.ToList();

            ViewData["StatesList"] = _context.States.ToList();
           // ViewData["CitiesList"] = _context.Cities.ToList();
        
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
        
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            //#4
            //var role = _roleManager.FindByIdAsync(Input.Name).Result;
            var role = "User";

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.FullName = Input.FullName;
                user.CardId = Input.CardId;
                user.Gender = Input.Gender;
                user.StateId= Input.StateId;
                user.CityId= Input.CityId;
               // user.Mobile=Input.Mobile;
                user.Address=Input.Address;
                user.Jop=Input.Jop;
                user.JopTitle=Input.JopTitle;
              
                user.PhoneNumber = Input.PhoneNumber;

                var cardid = _context.Users.Any(x => x.CardId == user.CardId);
                if (cardid)
                {
                    ModelState.AddModelError("", "رقم السجل مسجل مسبقا");
                    ViewData["StatesList"] = _context.States.ToList();
                    return Page();
                }

                //_userManager بدل _context
                var mobile = _context.Users.Any(x => x.PhoneNumber == user.PhoneNumber);
                if (mobile)
                {
                    ModelState.AddModelError("", "رقم الجوال مسجل مسبقا");
                    ViewData["StatesList"] = _context.States.ToList();
                    return Page();
                }

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    

                    //#5
                    //  await _userManager.AddToRoleAsync(user, role.Name);
                    await _userManager.AddToRoleAsync(user, role);

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                ViewData["StatesList"] = _context.States.ToList();
              
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form

            //#6
            ViewData["roles"] = _roleManager.Roles.ToList();

            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

       
    }
}
