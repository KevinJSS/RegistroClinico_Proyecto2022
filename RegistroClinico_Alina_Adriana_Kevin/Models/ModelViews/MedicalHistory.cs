using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews
{
    public class MedicalHistory
    {
        [ValidateNever]
        public List<ClinicalAnnotation> ClinicalAnnotations { get; set; } = new();
    }
}
