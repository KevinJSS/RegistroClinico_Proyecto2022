using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        #region HTTP GET POST
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<RegistroClinico_Alina_Adriana_Kevin.Models.Admin> adminList = _unitOfWork.Admin.GetAll();
            return View(adminList);
        }


        /* UPSERT GET */
        public IActionResult Upsert(int? id)
        {
            Patient patient = new();

            if (id != null || id > 0)
            {
                patient = _unitOfWork.Patient.GetFirstOrDefault(m => m.Id == id);
            }

            return View(patient);
        }

        /* UPSERT POST */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RegistroClinico_Alina_Adriana_Kevin.Models.Admin obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                    _unitOfWork.Admin.Add(obj);
                else
                    _unitOfWork.Admin.Update(obj);

                _unitOfWork.Save();
                TempData["success"] = "Administrador guardado correctamente";
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var adminList = _unitOfWork.Admin.GetAll();
            return Json(new { data = adminList });
        }

        [HttpDelete]
        public IActionResult DeleteAdmin(int? id)
        {
            var obj = _unitOfWork.Admin.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Admin.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Eliminado correctamente" });
        }
        #endregion

        #region API
        public IActionResult GetAllMedics()
        {
            var medicList = _unitOfWork.Medic.GetAll();
            return Json(new { data = medicList });
        }

        public IActionResult GetAllPatients()
        {
            var patientList = _unitOfWork.Patient.GetAll();
            return Json(new { data = patientList });
        }
        public IActionResult GetAllAdmins()
        {
            var adminList = _unitOfWork.Patient.GetAll();
            return Json(new { data = adminList });
        }
        #endregion
    }
}

