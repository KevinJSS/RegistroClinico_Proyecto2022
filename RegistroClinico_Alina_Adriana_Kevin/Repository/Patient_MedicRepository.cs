using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class Patient_MedicRepository : Repository<Patient_Medic>, IPatient_MedicRepository
    {
        private ApplicationDbContext _db;

        public Patient_MedicRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient_Medic obj)
        {
            _db.Patient_Medics.Update(obj);
        }
    }
}
