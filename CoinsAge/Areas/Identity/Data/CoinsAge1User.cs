using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinsAge.Models;
using Microsoft.AspNetCore.Identity;

namespace CoinsAge.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CoinsAge1User class
    public class CoinsAge1User : IdentityUser
    {
        [PersonalData]
        public string FullName { set; get; }

        [PersonalData]
        public string Address { set; get; }

        [PersonalData]
        public string Gender { set; get; }

        [PersonalData]
        public DateTime DOB { set; get; }

        public ICollection<News> News { get; set; }


    }
}
