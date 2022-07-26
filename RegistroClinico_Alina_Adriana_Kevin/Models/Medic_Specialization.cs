using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Medic_Specialization
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string MedicId { get; set; }

        [Required]
        public string SpecializationId { get; set; }
    }
}
