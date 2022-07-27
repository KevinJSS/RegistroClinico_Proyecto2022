using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Medic.Controllers
{
    [Area("Medic")]
    public class IllnessController : Controller
    {
        #region HTTP GET POST
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

        /* UPSERT GET */
        public IActionResult Upsert(int? id)
        {
            Illness illness = new();

            if (id != null || id > 0)
            {
                illness = _unitOfWork.Illness.GetFirstOrDefault(m => m.Id == id);
            }

            return View(illness);
        }

        /* UPSERT POST */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Illness obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                    _unitOfWork.Illness.Add(obj);
                else
                    _unitOfWork.Illness.Update(obj);

                _unitOfWork.Save();
                TempData["success"] = "Padecimiento guardado correctamente";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var illnessList = _unitOfWork.Illness.GetAll();
            return Json(new { data = illnessList });
        }

        //public IActionResult GetPatientMedicaments(int id) 
        //{
        //    //Filtrar por id
        //}

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Illness.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Illness.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Eliminado correctamente" });
        }
        #endregion 
    }
}
