using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class Patient_IllnessRepository : Repository<Patient_Illness>, IPatient_IllnessRepository
    {
        private ApplicationDbContext _db;

        public Patient_IllnessRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Patient_Illness obj)
        {
            _db.Patient_Illnesses.Update(obj);
        }
    }
}
