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
        private MedicVM _vm;

        public MedicController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
            _vm = new();
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
            medicVM.addedSpecs = new();

            IEnumerable<Medic_Specialization> medicSpecList = _unitOfWork.Medic_Specialization.GetAll();

            /* MEDIC SPECIALIZATIONS */
            foreach (Medic_Specialization ms in medicSpecList)
            {
                if (int.Parse(ms.MedicId) == id)
                {
                    int spId = int.Parse(ms.SpecializationId);
                    medicVM.medic_Specializations.Add(ms);
                    medicVM.addedSpecs.Add(_unitOfWork.Specialization.GetFirstOrDefault(u => u.Id == spId));
                }
            }

            _vm = medicVM;
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

        /* UPSERT POST */
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

        /* MedicSpecs GET */
        public IActionResult MedicSpecs(int id)
        {
            MedicVM medicVM = new();
            medicVM.medic = new();
            medicVM.medic = _unitOfWork.Medic.GetFirstOrDefault(m => m.Id == id);

            medicVM.specializations = new();
            medicVM.medic_Specializations = new();
            medicVM.addedSpecs = new();
            
            medicVM.specializations = (List<Specialization>)_unitOfWork.Specialization.GetAll();
            IEnumerable<Medic_Specialization> medicSpecList = _unitOfWork.Medic_Specialization.GetAll();

            /* MEDIC SPECIALIZATIONS */
            foreach (Medic_Specialization ms in medicSpecList)
            {
                if (int.Parse(ms.MedicId) == id)
                {
                    int spId = int.Parse(ms.SpecializationId);
                    medicVM.medic_Specializations.Add(ms);

                    medicVM.addedSpecs.Add(_unitOfWork.Specialization.GetFirstOrDefault(u => u.Id == spId));
                    medicVM.specializations.Remove(_unitOfWork.Specialization.GetFirstOrDefault(u => u.Id == spId));  
                }
            }            

            return View(medicVM);
        }

        /* MedicSpecs POST */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MedicSpecsPOST(int? id)
        {
            return RedirectToAction("Index");
        }

        public IActionResult AddSpec(int? specId) 
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region API
        public IActionResult GetAll()
        {
            var medicList = _unitOfWork.Medic.GetAll();
            return Json(new { data = medicList });
        }

        public IActionResult GetMedicVM(int medicId)
        {
            var medicList = _unitOfWork.Medic.GetAll();
            MedicVM medicVM = new();
            medicVM.specializations = (List<Specialization>)_unitOfWork.Specialization.GetAll();
            medicVM.medic = new();
            return Json(new { data = medicVM });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Medic.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error al eliminar médico" });

            _unitOfWork.Medic.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Médico eliminado correctamente" });
        }
        #endregion
    }
}
