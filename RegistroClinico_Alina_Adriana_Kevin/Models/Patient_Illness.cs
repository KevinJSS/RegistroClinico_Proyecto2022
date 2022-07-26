using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Patient_Illness
    {
        [Key]
        public int PatientId { get; set; }

        [Key]
        public int IllnessId { get; set; }
    }
}
