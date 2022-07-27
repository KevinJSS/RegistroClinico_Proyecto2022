using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace ProyectoLenguajes_Adriana_Alina_Kevin.Areas.Admin.Controllers
{
    [Area("Medic")]
    public class TreatmentController : Controller
    {
        #region HTTP GET POST
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

        /* UPSERT GET */
        public IActionResult Upsert(int? id)
        {
            Treatment treatment = new();

            if (id != null || id > 0)
            {
                treatment = _unitOfWork.Treatment.GetFirstOrDefault(m => m.Id == id);
            }

            return View(treatment);
        }

        /* UPSERT POST */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Treatment obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                    _unitOfWork.Treatment.Add(obj);
                else
                    _unitOfWork.Treatment.Update(obj);

                _unitOfWork.Save();
                TempData["success"] = "tratamiento guardado correctamente";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var treatmentList = _unitOfWork.Treatment.GetAll();
            return Json(new { data = treatmentList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Treatment.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Treatment.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Eliminado correctamente" });
        }
        #endregion 

    }
}
