using Microsoft.AspNetCore.Mvc;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Models.ModelViews;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Areas.Medic.Controllers
{
    [Area("Medic")]
    public class PatientController : Controller
    {
        #region HTTP GET POST
        private readonly IUnitOfWork _unitOfWork;
        private MedicalRecord _medicalRecord;

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _medicalRecord = new();
        }
        public IActionResult Index()
        {
            IEnumerable<Patient> patientList = _unitOfWork.Patient.GetAll();
            return View(patientList);
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
        public IActionResult Upsert(Patient obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                    _unitOfWork.Patient.Add(obj);
                else
                    _unitOfWork.Patient.Update(obj);

                _unitOfWork.Save();
                TempData["success"] = "Paciente guardado correctamente";
            }
            return RedirectToAction("Index");
        }

        /* MEDICAL RECORD */
        public IActionResult MedicalRecordView(int id)
        {
            _medicalRecord.Patient = new();
            _medicalRecord.Patient = _unitOfWork.Patient.GetFirstOrDefault(p => p.Id == id);
            return View(_medicalRecord);
        }

        #endregion

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var patientList = _unitOfWork.Patient.GetAll();
            return Json(new { data = patientList });
        }

        public IActionResult GetPatientIllnesses(int? id)
        {
            Patient p = _unitOfWork.Patient.GetFirstOrDefault(i => i.Id == id);
            var patientIllnesses = _unitOfWork.Patient.GetAll();

            List<Patient_Illness> pIllness = (List<Patient_Illness>) _unitOfWork.Patient_Illness.GetAll();
            _medicalRecord.IllnessList = new();


            foreach (Patient_Illness pi in pIllness)
            {
                if (pi.PatientId == p.Id)
                {
                    _medicalRecord.IllnessList.Add(_unitOfWork.Illness.GetFirstOrDefault(i => i.Id == pi.IllnessId));
                }
            }
            return Json(new { data = _medicalRecord.IllnessList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Patient.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Patient.Remove(obj);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Eliminado correctamente" });
        }
        #endregion 
    }
}
