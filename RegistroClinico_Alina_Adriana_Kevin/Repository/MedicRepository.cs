using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class MedicRepository : Repository<Medic>, IMedicRepository
    {
        private ApplicationDbContext _db;

        public MedicRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Medic obj)
        {
            _db.Medics.Update(obj);
        }
    }
}
