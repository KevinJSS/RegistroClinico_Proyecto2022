using Microsoft.AspNetCore.Mvc;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Medic.Controllers
{
    [Area("Medic")]
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
