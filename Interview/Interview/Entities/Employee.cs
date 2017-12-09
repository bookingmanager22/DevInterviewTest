using System;

namespace Interview.Entities
{
    public class Employee : IComparable
    {
        int id;

        public Employee(int newId)
        {
            this.id = newId;
        }

        public int CompareTo(object employee)
        {
            if (employee == null || employee.GetType() != GetType())
            {
                return -1;
            }

            if (!(employee is Employee))
            {
                throw new ArgumentException("Object must be of type Employee.");
            }

            return CompareTo(employee as Employee);
        }

        private int CompareTo(Employee employee)
        {
            if (id == employee.id)
            {
                return 0;
            }
            else if (id > employee.id)
            {
                return 1;
            }
            else return -1;
        }
    }
}
