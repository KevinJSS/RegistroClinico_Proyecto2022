using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews
{
    public class UsersVM
    {
        [ValidateNever]
        public List<Admin> AdminList { get; set; }

        [ValidateNever]
        public List<Medic> MedicList { get; set; }

        [ValidateNever]
        public List<Patient> PatientList { get; set; }

    }
}