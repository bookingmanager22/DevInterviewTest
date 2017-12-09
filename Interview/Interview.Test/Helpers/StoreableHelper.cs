using Interview.Entities;

namespace Interview.Test.Helpers
{
    public static class StoreableHelper
    {
        public static IStoreable GetAStoreable()
        {
            return new Storeable();
        }

        public static IStoreable WithBook(this IStoreable storeable, Book book)
        {
            storeable.Id = book;
            return storeable;
        }

        public static IStoreable WithEmployee(this IStoreable storeable, Employee employee)
        {
            storeable.Id = employee;
            return storeable;
        }
    }
}
