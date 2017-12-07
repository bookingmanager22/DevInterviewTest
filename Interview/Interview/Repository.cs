using System.Collections.Generic;

namespace Interview
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {
        private HashSet<T> list;

        public Repository()
        {
            list = new HashSet<T>();
        }

        public IEnumerable<T> All()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(System.IComparable id)
        {
            throw new System.NotImplementedException();
        }

        public T FindById(System.IComparable id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
