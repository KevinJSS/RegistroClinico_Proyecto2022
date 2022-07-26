using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Medic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "N\u00FAmero de Colegiado")]
        public string LicenseNumber { get; set; }

        [ValidateNever]
        [Display(Name = "Fotograf\u00EDa")]
        public string PictureUrl { get; set; }
    }
}
