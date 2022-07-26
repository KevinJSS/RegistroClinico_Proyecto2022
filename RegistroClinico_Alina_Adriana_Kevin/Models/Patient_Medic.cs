using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Patient_Medic
    {

        [Key]
        public int PatientId { get; set; }

        [Key]
        public int MedicId { get; set; }
    }
}
