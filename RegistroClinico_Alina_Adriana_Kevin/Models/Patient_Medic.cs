using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Patient_Medic
    {

        [Key]
        public int id { get; set; }

        [Required]
        public int PatientId { get; set; }
        
        [Required]
        public int MedicId { get; set; }
    }
}
