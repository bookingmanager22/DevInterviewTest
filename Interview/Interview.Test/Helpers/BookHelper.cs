namespace Interview.Test.Helpers
{
    public static class BookHelper
    {
        public static Book GetABookWithId(int id)
        {
            return new Book(id);
        }
    }
}
