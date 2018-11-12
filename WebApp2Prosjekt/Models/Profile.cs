using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }

        public int LinesWritten { get; set; }

        public decimal WagePerLine { get; set; }

        public virtual IdentityUser Owner { get; set; }

    }
}
