using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews
{
    public class MedicalHistory
    {
        public int PatientId { get; set; }

        //[ValidateNever]
        //public IdentityUser Patient { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ClinicalAnnotations { get; set; }
    }
}
