using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp2Prosjekt.Models.ViewModels
{
    public class EditProfileViewModel
    {
        public int ProfileId { get; set; }
        
        public int LinesWritten { get; set; }

        public decimal WagePerLine { get; set; }

        public int SpecialityFieldId { get; set; }
        public List<SpecialityField> specialityFields { get; set; }

        public string OwnerUserName { get; set; }
    }
}
