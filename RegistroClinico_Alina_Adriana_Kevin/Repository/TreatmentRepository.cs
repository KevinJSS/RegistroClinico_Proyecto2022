using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        private ApplicationDbContext _db;

        public TreatmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Treatment obj)
        {
            _db.Treatments.Update(obj);
        }
    }
}
