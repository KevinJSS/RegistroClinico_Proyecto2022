using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient obj)
        {
            _db.Patients.Update(obj);
        }
    }
}
