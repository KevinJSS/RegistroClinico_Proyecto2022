using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class TestResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        [Display(Name = "Descripci\u00F3n")]
        public string Description { get; set; }

        [ValidateNever]
        [Display(Name = "Ruta del Archivo")]
        public string FileUrl { get; set; }
    }
}
