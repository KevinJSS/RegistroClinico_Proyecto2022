using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class SpecRepository : Repository<Specialization>, ISpecRepository
    {
        private ApplicationDbContext _db;

        public SpecRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Specialization obj)
        {
            _db.Specializations.Update(obj);
        }
    }
}
