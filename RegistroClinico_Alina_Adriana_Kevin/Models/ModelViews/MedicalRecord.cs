using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews
{
    public class MedicalRecord
    {
        public Patient Patient { get; set; }

        [ValidateNever]
        public List<Illness> IllnessList { get; set; }

        [ValidateNever]
        public List<Treatment> TreatmentList { get; set; }

        [ValidateNever]
        public List<Medicament> MedicamentList { get; set; }

        [ValidateNever]
        public List<TestResult> TestResultList { get; set; }

        public MedicalHistory MedicalHistory { get; set; }
    }
}
