using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MedicController : Controller
    {
        #region HTTP GET POST
        private readonly IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnvironment;

        public MedicController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<RegistroClinico_Alina_Adriana_Kevin.Models.Medic> medicList = _unitOfWork.Medic.GetAll();
            return View();
        }

        public IActionResult Details(int id)
        {
            MedicVM medicVM = new();

            medicVM.medic = _unitOfWork.Medic.GetFirstOrDefault(u => u.Id == id);
            medicVM.medic_Specializations = new();

            IEnumerable<Medic_Specialization> medicSpecList = _unitOfWork.Medic_Specialization.GetAll();

            /* MEDIC SPECIALIZATIONS */
            foreach (Medic_Specialization ms in medicSpecList)
            {
                if (int.Parse(ms.MedicId) == id)
                {
                    medicVM.medic_Specializations.Add(ms);
                }
            }

            /* SPECIALIZATION */
            medicVM.specializations = new();
            foreach (Medic_Specialization sp in medicVM.medic_Specializations)
            {
                if (int.Parse(sp.SpecializationId) == id)
                {
                    int spId = int.Parse(sp.SpecializationId);
                    medicVM.specializations.Add(_unitOfWork.Specialization.GetFirstOrDefault(u => u.Id == spId));
                }
            }

            return View(medicVM);
        }

        /* UPSERT GET */
        public IActionResult Upsert(int? id)
        {
            MedicVM medicVM = new();
            medicVM.medic = new();

            if (id != null || id > 0)
            {
                medicVM.medic = _unitOfWork.Medic.GetFirstOrDefault(m => m.Id == id);
            }

            return View(medicVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(MedicVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"lib\images\medics");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.medic.PictureUrl != null)
                    {
                        var oldImageUrl = Path.Combine(wwwRootPath, obj.medic.PictureUrl);
                        if (System.IO.File.Exists(oldImageUrl))
                        {
                            System.IO.File.Delete(oldImageUrl);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.medic.PictureUrl = @"lib\images\medics\" + fileName + extension;
                }


                if (obj.medic.Id == 0)
                    _unitOfWork.Medic.Add(obj.medic);
                else
                    _unitOfWork.Medic.Update(obj.medic);

                _unitOfWork.Save();
                if (obj.medic.Id == 0)
                    TempData["success"] = "Médico agregado correctamente";
                else
                    TempData["success"] = "Médico actualizado correctamente";
            }
            return RedirectToAction("Index");
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
