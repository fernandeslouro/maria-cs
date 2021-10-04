using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_03_Exercise
{
    class Program
    {

        int employee_FinalSalary(string employee_Type, int employee_salary, int employee_HoursWorked, int employee_bonus, int employee_RatePerHour)
        {
            if (employee_Type == "Monthly Salaried")
            {
                return employee_salary + employee_bonus;
            }
            else if (employee_Type == "Hourly Salaried")
            {
                return (employee_RatePerHour * employee_HoursWorked) + employee_bonus;
            }
            else
            {
                return 0;
            }

        }

        static void Main2(string[] args)
        {

            Console.WriteLine("****Employee Information****");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("");

            Console.WriteLine("Please provide the following details: ");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("");

            Console.Write("First Name: ");
            string employee_FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string employee_LastName = Console.ReadLine();
            Console.ReadLine();
            Console.Write("Country: ");
            string employee_Country = Console.ReadLine();
            Console.Write("Date of Birth (dd-MM-yyyy): ");
            DateTime employee_dob = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            Console.Write("Employee Type (Monthly Salaried / Hourly Salaried): ");
            string employee_Type = Console.ReadLine();

            int employee_RatePerHour = 0;
            int employee_HoursWorked = 0;
            int employee_salary = 0;

            if (employee_Type == "Hourly Salaried")
            {
                Console.Write("Rate per Hour (£): ");
                employee_RatePerHour = int.Parse(Console.ReadLine());
                Console.Write("Hours Worked: ");
                employee_HoursWorked = int.Parse(Console.ReadLine());
            }
            else if (employee_Type == "Hourly Salaried")
            {
                Console.Write("Monthly Salary (£): ");
                employee_salary = int.Parse(Console.ReadLine());
            }

            Console.Write("Bonus (£): ");
            int employee_bonus = int.Parse(Console.ReadLine());


            Program prog = new Program();
            int final_salary = prog.employee_FinalSalary(employee_Type, employee_salary, employee_HoursWorked, employee_bonus, employee_RatePerHour);
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("");

            Console.WriteLine("******** Information Output ********");
            Console.WriteLine($"Name: {employee_FirstName} {employee_LastName}");
            Console.WriteLine($"Country: {employee_Country}");
            Console.WriteLine($"Date of Birth: {employee_dob}");
            Console.WriteLine($"Employee Type: {employee_Type}");
            Console.WriteLine($"Monthly Rate: {final_salary}");

            Console.ReadLine();
        }
    }
}


