using System;

namespace Interview.Entities
{
    public class Employee : IComparable
    {
        int id;

        public Employee(int id)
        {
            this.id = id;
        }

        public int CompareTo(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return -1;
            }

            if (!(obj is Employee))
            {
                throw new ArgumentException("Object must be of type Employee.");
            }

            return CompareTo(obj as Employee);
        }

        private int CompareTo(Employee other)
        {
            if (id == other.id)
            {
                return 0;
            }
            else if (id > other.id)
            {
                return 1;
            }
            else return -1;
        }
    }
}
