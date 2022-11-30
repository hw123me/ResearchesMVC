// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResearchesMVC.Areas.Identity.Data;
using ResearchesMVC.Models;

namespace ResearchesMVC.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplictionDbContext _context;
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
             ApplictionDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Display(Name = "اسم المستخدم ")]
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }
   

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
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "رقم الجوال")]
            public string PhoneNumber { get; set; }

            //[Required(ErrorMessage = "اختر الجنس ")]
            [Display(Name = "الجنس")]
            public Gender? Gender { get; set; }

            [Display(Name = "اسم الباحث")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "اختر المنطقة")]
            [Display(Name = "المنطقة")]
            public int? StateId { get; set; }
            [ForeignKey("StateId")]
            public State State { get; set; }

            [Required(ErrorMessage = "اختر المحافظة")]
            [Display(Name = "المحافظة")]
            public int? CityId { get; set; }
            [ForeignKey("CityId")]
            public City City { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            Username = userName;
            // var fullname = user.FullName;

            //var gender = user.Gender;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FullName = user.FullName,
                Gender = user.Gender,
                StateId = user.StateId,
                CityId = user.CityId,
              
            };
            ViewData["StatesList"] = _context.States.ToList();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
         
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var mobile = _context.Users.Any(x => x.PhoneNumber == Input.PhoneNumber);
                if (mobile)
                {
                    StatusMessage = "خطأ " + "رقم الجوال مسجل لمستخدم آخر";
                    ViewData["StatesList"] = _context.States.ToList();
                    return RedirectToPage();
                }

                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var fullname = user.FullName;

            if (Input.FullName != fullname)
            {
                user.FullName = Input.FullName;
                await _userManager.UpdateAsync(user);
            }

            var gender = user.Gender;

            if (Input.Gender != gender)
            {
                user.Gender = Input.Gender;
                await _userManager.UpdateAsync(user);
            }

            if (Input.StateId != user.StateId)
            {
                user.StateId = Input.StateId;
                await _userManager.UpdateAsync(user);
            }
            
           if (Input.CityId != user.CityId)
           {
                user.CityId = Input.CityId;
                await _userManager.UpdateAsync(user);
           }
            ViewData["StatesList"] = _context.States.ToList();
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "تم تعديل الملف الشخصي بنجاح";
            return RedirectToPage();
        }
    }
}
