using System.ComponentModel.DataAnnotations;

namespace RegistroClinico_Alina_Adriana_Kevin.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Identification { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}


