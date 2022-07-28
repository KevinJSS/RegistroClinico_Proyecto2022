namespace RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClinicalAnnotRepository ClinicalAnnotation { get; }

        IIllnessRepository Illness { get; }

        IMedicamentRepository Medicament { get; }

        IMedicRepository Medic { get; }

        IMedic_SpecRepository Medic_Specialization { get; }

        IPatientRepository Patient { get; }

        IPatient_IllnessRepository Patient_Illness { get; }

        IPatient_MedicRepository Patient_Medic { get; }

        IPatient_MedicamentRepository Patient_Medicament { get; }

        IPatient_TreatmentRepository Patient_Treatment { get; }

        ISpecRepository Specialization { get; }

        ITestResultRepository TestResult { get; }

        ITreatmentRepository Treatment { get; }

        IAdminRepository Admin { get; }

        void Save();
    }
}
