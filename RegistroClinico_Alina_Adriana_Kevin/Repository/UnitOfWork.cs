using RegistroClinico_Alina_Adriana_Kevin.Data;
using RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IClinicalAnnotRepository ClinicalAnnotation { get; private set; }

        public IIllnessRepository Illness { get; private set; }

        public IMedicamentRepository Medicament { get; private set; }

        public IMedicRepository Medic { get; private set; }

        public IMedic_SpecRepository Medic_Specialization { get; private set; }
        public IPatient_IllnessRepository Patient_Illness { get; private set; }

        public IPatient_MedicRepository Patient_Medic { get; private set; }

        public IPatient_MedicamentRepository Patient_Medicament { get; private set; }

        public IPatient_TreatmentRepository Patient_Treatment { get; private set; }

        public ISpecRepository Specialization { get; private set; }

        public ITestResultRepository TestResult { get; private set; }

        public ITreatmentRepository Treatment { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ClinicalAnnotation = new ClinicalAnnotRepository(_db);
            Illness = new IllnessRepository(_db);
            Medicament = new MedicamentRepository(_db);
            Medic = new MedicRepository(_db);
            Medic_Specialization = new Medic_SpecRepository(_db);
            Patient_Illness = new Patient_IllnessRepository(_db);
            Patient_Medic = new Patient_MedicRepository(_db);
            Patient_Medicament = new Patient_MedicamentRepository(_db);
            Patient_Treatment = new Patient_TreatmentRepository(_db);
            Specialization = new SpecRepository(_db);
            TestResult = new TestResultRepository(_db);
            Treatment = new TreatmentRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
