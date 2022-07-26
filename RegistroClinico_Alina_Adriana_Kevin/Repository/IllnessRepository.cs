using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class IllnessRepository : Repository<Illness>, IIllnessRepository
    {
        private ApplicationDbContext _db;

        public IllnessRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Illness obj)
        {
            _db.Illnesses.Update(obj);
        }
    }
}
