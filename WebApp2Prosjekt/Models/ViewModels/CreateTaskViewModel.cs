using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models.ViewModels
{
    public class CreateTaskViewModel
    {

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Fill in a title")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Describe the task")]
        public string Description { get; set; }
        
        public List<SpecialityField> SpecialityFields { get; set; }
    }
}
