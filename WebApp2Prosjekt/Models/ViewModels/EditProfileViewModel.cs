using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models.ViewModels
{
    public class EditProfileViewModel
    {
        public int ProfileId { get; set; }
        
        [DefaultValue(0)]
        public int LinesWritten { get; set; }

        [DefaultValue(1.00)]
        public decimal WagePerLine { get; set; }

        [DefaultValue(1)]
        public int SpecialityFieldId { get; set; }
        public List<SpecialityField> SpecialityFields { get; set; }

        public string OwnerUserName { get; set; }
    }
}
