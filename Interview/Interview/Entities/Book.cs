using System;

namespace Interview.Entities
{
    public class Book : IComparable
    {
        int id;

        public Book(int id)
        {
            this.id = id;
        }

        public int CompareTo(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return -1;
            }

            if (!(obj is Book))
            {
                throw new ArgumentException("Object must be of type Book.");
            }

            return CompareTo(obj as Book);
        }

        private int CompareTo(Book other)
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
