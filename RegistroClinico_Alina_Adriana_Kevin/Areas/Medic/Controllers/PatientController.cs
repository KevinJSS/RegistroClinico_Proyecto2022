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


        public IActionResult AddIllness(int id) 
        {
            Patient p = _unitOfWork.Patient.GetFirstOrDefault(m => m.Id == id);
            return View(p);
        }

        public IActionResult AddIllnessPost(string id)
        {

            string[] ids = id.Split("@");

            Patient_Illness pi = new();
            pi.PatientId = int.Parse(ids[1]);
            pi.IllnessId = int.Parse(ids[0]);

            _unitOfWork.Patient_Illness.Add(pi);

            _unitOfWork.Save();
            TempData["success"] = "Padecimiento agregado correctamente";
            return RedirectToAction("index");
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

        public IActionResult GetPatientTreatments(int? id)
        {
            Patient p = _unitOfWork.Patient.GetFirstOrDefault(i => i.Id == id);

            List<Patient_Treatment> pTreatment = (List<Patient_Treatment>)_unitOfWork.Patient_Treatment.GetAll();
            _medicalRecord.TreatmentList = new();


            foreach (Patient_Treatment pt in pTreatment)
            {
                if (pt.PatientId == p.Id)
                {
                    _medicalRecord.TreatmentList.Add(_unitOfWork.Treatment.GetFirstOrDefault(i => i.Id == pt.TreatmentId));
                }
            }
            return Json(new { data = _medicalRecord.TreatmentList });
        }

        public IActionResult GetPatientMedicaments(int? id)
        {
            Patient p = _unitOfWork.Patient.GetFirstOrDefault(i => i.Id == id);

            List<Patient_Medicament> pMedicament = (List<Patient_Medicament>)_unitOfWork.Patient_Medicament.GetAll();
            _medicalRecord.MedicamentList = new();


            foreach (Patient_Medicament pM in pMedicament)
            {
                if (pM.PatientId == p.Id)
                {
                    _medicalRecord.MedicamentList.Add(_unitOfWork.Medicament.GetFirstOrDefault(i => i.Id == pM.MedicamentId));
                }
            }
            return Json(new { data = _medicalRecord.MedicamentList });
        }

        public IActionResult GetMedicalHistory(int? id)
        {
            Patient p = _unitOfWork.Patient.GetFirstOrDefault(i => i.Id == id);

            List<ClinicalAnnotation> cAnnot = (List<ClinicalAnnotation>)_unitOfWork.ClinicalAnnotation.GetAll();
            _medicalRecord.MedicalHistory = new();


            foreach (ClinicalAnnotation c in cAnnot)
            {
                if (c.PatientId == p.Id)
                {
                    _medicalRecord.MedicalHistory.ClinicalAnnotations.Add(_unitOfWork.ClinicalAnnotation.GetFirstOrDefault(i => i.Id == c.Id));
                }
            }
            return Json(new { data = _medicalRecord.MedicalHistory.ClinicalAnnotations });
        }

        public IActionResult GetTestResults(int? id)
        {
            Patient p = _unitOfWork.Patient.GetFirstOrDefault(i => i.Id == id);

            List<TestResult> tResults = (List<TestResult>)_unitOfWork.TestResult.GetAll();
            _medicalRecord.TestResultList = new();


            foreach (TestResult t in tResults)
            {
                if (t.PatientId == p.Id)
                {
                    _medicalRecord.TestResultList.Add(_unitOfWork.TestResult.GetFirstOrDefault(i => i.Id == t.Id));
                }
            }
            return Json(new { data = _medicalRecord.TestResultList });
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
