using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Availability_of_operators.Work
{
    namespace Models
    {
        public class Employee
        {
            public double Salary { get; set; }

            public Employee(double salary)
            {
                Salary = salary;
            }

            // Збільшення зарплати
            public static Employee operator +(Employee emp, double amount)
            {
                emp.Salary += amount;
                return emp;
            }

            // Зменшення зарплати
            public static Employee operator -(Employee emp, double amount)
            {
                emp.Salary -= amount;
                return emp;
            }

            // Порівняння зарплат
            public static bool operator ==(Employee a, Employee b)
            {
                return a.Salary == b.Salary;
            }

            public static bool operator !=(Employee a, Employee b)
            {
                return a.Salary != b.Salary;
            }

            // Більше / менше
            public static bool operator >(Employee a, Employee b)
            {
                return a.Salary > b.Salary;
            }

            public static bool operator <(Employee a, Employee b)
            {
                return a.Salary < b.Salary;
            }
        }
    }
}

    
