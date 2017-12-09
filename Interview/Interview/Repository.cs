using System.Collections.Generic;
using System.Linq;

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
            return list;
        }

        public void Delete(System.IComparable id)
        {
            T data = this.FindById(id);

            this.list.Remove(data);
        }

        public T FindById(System.IComparable id)
        {
            return this.list.FirstOrDefault(item => item.Id.CompareTo(id) == 0);
        }

        public void Save(T item)
        {
            if (item == null)
            {
                return;
            }

            this.list.Add(item);
        }
    }
}
