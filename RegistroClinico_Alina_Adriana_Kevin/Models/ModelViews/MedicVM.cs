using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews
{
    public class MedicVM
    {
        public Medic medic { get; set; }

        [ValidateNever]
        public List<Medic_Specialization> medic_Specializations { get; set; }
    }
}
