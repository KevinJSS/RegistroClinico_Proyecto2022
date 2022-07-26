using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class Patient_TreatmentRepository : Repository<Patient_Treatment>, IPatient_TreatmentRepository
    {
        private ApplicationDbContext _db;

        public Patient_TreatmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient_Treatment obj)
        {
            _db.Patient_Treatments.Update(obj);
        }
    }
}
