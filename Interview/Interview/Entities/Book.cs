using System;

namespace Interview.Entities
{
    public class Book : IComparable
    {
        private int id;

        public Book(int newId)
        {
            this.id = newId;
        }

        public int CompareTo(object book)
        {
            if (book == null || book.GetType() != GetType())
            {
                return -1;
            }

            if (!(book is Book))
            {
                throw new ArgumentException("Object must be of type Book.");
            }

            return CompareTo(book as Book);
        }

        private int CompareTo(Book book)
        {
            if (id == book.id)
            {
                return 0;
            }
            else if (id > book.id)
            {
                return 1;
            }
            else return -1;
        }
    }
}
