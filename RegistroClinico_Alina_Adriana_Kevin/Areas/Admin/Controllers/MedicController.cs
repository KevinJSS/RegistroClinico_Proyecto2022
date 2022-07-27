using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;
using RegistroClinico_Alina_Adriana_Kevin.Models;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicController : Controller
    {
        #region HTTP GET POST
        private readonly IUnitOfWork _unitOfWork;

        public MedicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<RegistroClinico_Alina_Adriana_Kevin.Models.Medic> medicList = _unitOfWork.Medic.GetAll();
            return View();
        }
        #endregion

        #region API
        public IActionResult GetAll()
        {
            var medicList = _unitOfWork.Medic.GetAll();
            return Json(new { data = medicList });
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
