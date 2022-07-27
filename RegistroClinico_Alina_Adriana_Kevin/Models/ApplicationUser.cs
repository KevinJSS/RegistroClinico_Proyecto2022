using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string UserIdNumber { set; get; }


        [Required]
        public string UserFullName { get; set; }
    }
}
