using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Models;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class TestResultRepository : Repository<TestResult>, ITestResultRepository
    {
        private ApplicationDbContext _db;

        public TestResultRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TestResult obj)
        {
            _db.TestResults.Update(obj);
        }
    }
}
