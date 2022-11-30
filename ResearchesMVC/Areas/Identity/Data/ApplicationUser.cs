using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ResearchesMVC.Models;

namespace ResearchesMVC.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public enum Gender
{
    [Display(Name = "ذكر")]
    Male,

    [Display(Name = "أنثى")]
    Female,

}
public class ApplicationUser : IdentityUser
{
    [PersonalData]
     [Display(Name = " اسم الباحث")]
    public string? FullName { get; set; }
   

    [PersonalData]
    public int? CardId { get; set; }

    [PersonalData]
    public Gender? Gender { get; set; }

    [PersonalData]
    public int? StateId { get; set; }
    [ForeignKey("StateId")]
    public State? State { get; set; }

    [PersonalData]
    public int? CityId { get; set; }
    [ForeignKey("CityId")]
    public City? City { get; set; }

    //[PersonalData]
    //public string? Mobile { get; set; }

    [PersonalData]
    public string? Address { get; set; }

    [PersonalData]
    public string? Jop { get; set; }

    [PersonalData]
    public string? JopTitle { get; set; }

   
}

