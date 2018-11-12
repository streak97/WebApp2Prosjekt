using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models
{
    public class Task
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Complete { get; set; }

        public int Lines { get; set; }

        public virtual IdentityUser Client { get; set; }

        public virtual IdentityUser Freelancer { get; set; }

    }
}
