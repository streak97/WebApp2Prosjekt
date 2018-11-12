using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models.ViewModels
{
    /// <summary>
    /// ViewModel for creating a new task
    /// </summary>
    public class CreateTaskViewModel
    {

        //Task title
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Fill in a title")]
        public string Title { get; set; }

        //Task description
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Describe the task")]
        public string Description { get; set; }
        
        //Possible to choose a field
        public List<SpecialityField> SpecialityFields { get; set; }

        //Possible to choose a specific developer
        public List<IdentityUser> Developers { get; set; }
    }
}
