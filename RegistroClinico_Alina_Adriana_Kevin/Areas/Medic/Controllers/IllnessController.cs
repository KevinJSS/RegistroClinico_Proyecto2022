using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Medic.Controllers
{
    [Area("Medic")]
    public class IllnessController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public IllnessController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Illness> illnesList = _unitOfWork.Illness.GetAll();
            return View(illnesList);
        }
    }
}
