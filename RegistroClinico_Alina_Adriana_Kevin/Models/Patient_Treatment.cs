using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Patient_Treatment
    {
        [Key]
        public int PatientId { get; set; }

        [Key]
        public int TreatmentId { get; set; }
    }
}
