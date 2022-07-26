using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Patient_Medicament
    {
        [Key]
        public int PatientId { get; set; }

        [Key]
        public int MedicamentId { get; set; }
    }
}
