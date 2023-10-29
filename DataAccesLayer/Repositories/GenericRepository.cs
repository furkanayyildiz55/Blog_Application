using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;

namespace DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new Context();
            context.Remove(t);
        }

        public T GetByID(int ID)
        {
            using var context = new Context();
            return context.Set<T>().Find(ID);
        }

        public List<T> GetListAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();  
        }

        public void Insert(T t)
        {
            using var context = new Context();
            context.Add(t);

        }

        public void Update(T t)
        {
            using var context = new Context();
            context.Update(t);
        }
    }
}
