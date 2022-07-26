using System.Linq.Expressions;

namespace RegistroClinico_Alina_Adriana_Kevin.Repository.IRepository
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll(string? includeProperties = null);

            T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);

            void Add(T obj);

            void Remove(T obj);
        }
    }
}
