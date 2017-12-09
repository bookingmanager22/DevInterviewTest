
using Interview.Entities;

namespace Interview.Test.Helpers
{
    public static class EmployeeHelper
    {
        public static Employee GetAnEmployeeWithId(int id)
        {
            return new Employee(id);
        }
    }
}
