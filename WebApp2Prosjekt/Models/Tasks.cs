using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models
{
    public class Tasks
    {
        public int TasksId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int SpecialityFieldId { get; set; }
        public virtual SpecialityField SpecialityField { get; set; }

        [DefaultValue(false)]
        public bool Complete { get; set; }

        [DefaultValue(0)]
        public int Lines { get; set; }

        public virtual IdentityUser Client { get; set; }
        
        public virtual IdentityUser Freelancer { get; set; }

    }
}
