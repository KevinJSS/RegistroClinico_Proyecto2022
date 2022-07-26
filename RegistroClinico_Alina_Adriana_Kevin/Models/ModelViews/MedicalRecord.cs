using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews
{
    public class MedicalRecord
    {
        //public IdentityUser Patient { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> IllnessList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TreatmentList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> MedicamentList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TestResultList { get; set; }

        public MedicalHistory MedicalHistory { get; set; }
    }
}
