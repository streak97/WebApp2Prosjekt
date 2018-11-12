using System.ComponentModel.DataAnnotations;

namespace WebApp2Prosjekt.Models
{
    public class SpecialityField
    {
        [Key]
        public int SpecialtyFieldId { get; set; }

        public string Type { get; set; }
    }
}