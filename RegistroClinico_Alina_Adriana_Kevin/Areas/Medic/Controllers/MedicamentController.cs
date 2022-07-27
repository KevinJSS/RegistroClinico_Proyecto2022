using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Medic.Controllers
{
    [Area("Medic")]
    public class MedicamentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicamentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Medicament> medicamentList = _unitOfWork.Medicament.GetAll();
            return View(medicamentList);
        }
    }
}