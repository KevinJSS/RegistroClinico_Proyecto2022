using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Medic.Controllers
{
    [Area("Medic")]
    public class MedicamentController : Controller
    {
        #region HTTP GET POST
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

        /* UPSERT GET */
        public IActionResult Upsert(int? id)
        {
            Medicament medicament = new();

            if (id != null || id > 0) {
                medicament = _unitOfWork.Medicament.GetFirstOrDefault(m => m.Id == id);
            }

            return View(medicament);
        }

        /* UPSERT POST */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Medicament obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {  
                if (obj.Id == 0)
                    _unitOfWork.Medicament.Add(obj);
                else
                    _unitOfWork.Medicament.Update(obj);

                _unitOfWork.Save();
                TempData["success"] = "Medicamento guardado correctamente";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var medicamentList = _unitOfWork.Medicament.GetAll();
            return Json(new { data = medicamentList });
        }

        //public IActionResult GetPatientMedicaments(int id) 
        //{
        //    //Filtrar por id
        //}

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Medicament.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Medicament.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Eliminado correctamente" });
        }
        #endregion 
    }
}