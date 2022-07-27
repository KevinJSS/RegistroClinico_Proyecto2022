using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace ProyectoLenguajes_Adriana_Alina_Kevin.Areas.Admin.Controllers
{
    [Area("Medic")]
    public class TreatmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TreatmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Treatment> treatmentList = _unitOfWork.Treatment.GetAll();
            return View(treatmentList);
        }

    }
}
