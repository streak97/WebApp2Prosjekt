using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models
{
    /// <summary>
    /// Individual developers profile
    /// </summary>
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        /// Lines written this month
        public int LinesWritten { get; set; }

        //Payment per line
        public decimal WagePerLine { get; set; }

        //Field of speciality
        public virtual SpecialityField SpecialityField { get; set; }

        //Profile of...
        public virtual IdentityUser Owner { get; set; }

    }
}
