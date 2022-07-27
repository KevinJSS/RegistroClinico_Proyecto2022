using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecializationController : Controller
    {
        #region HTTP GET POST
        private readonly IUnitOfWork _unitOfWork;

        public SpecializationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Specialization> specList = _unitOfWork.Specialization.GetAll();
            return View(specList);
        }

        /* UPSERT GET */
        public IActionResult Upsert(int? id)
        {
            Specialization spec = new();

            if (id != null || id > 0)
            {
                spec = _unitOfWork.Specialization.GetFirstOrDefault(m => m.Id == id);
            }

            return View(spec);
        }

        /* UPSERT POST */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Specialization obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                    _unitOfWork.Specialization.Add(obj);
                else
                    _unitOfWork.Specialization.Update(obj);

                _unitOfWork.Save();
                TempData["success"] = "Especialidad guardada correctamente";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var specList = _unitOfWork.Specialization.GetAll();
            return Json(new { data = specList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Specialization.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error al eliminar especialidad" });

            _unitOfWork.Specialization.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Especialidad eliminada correctamente" });
        }
        #endregion 
    }
}
