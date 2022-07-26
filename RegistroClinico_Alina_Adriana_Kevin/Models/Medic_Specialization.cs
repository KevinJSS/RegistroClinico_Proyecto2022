using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Medic_Specialization
    {
        [Key]
        public string MedicId { get; set; }

        [Key]
        public string SpecializationId { get; set; }
    }
}
