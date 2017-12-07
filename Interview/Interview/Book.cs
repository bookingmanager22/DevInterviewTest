using System;

namespace Interview
{
    public class Book : IComparable<Book>, IComparable
    {
        int id;

        public Book(int id)
        {
            this.id = id;
        }

        public int CompareTo(Book other)
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

        public int CompareTo(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return -1;
            }

            if (obj != null && !(obj is Book))
            {
                throw new ArgumentException("Object must be of type Book.");
            }

            return CompareTo(obj as Book);
        }
    }
}
