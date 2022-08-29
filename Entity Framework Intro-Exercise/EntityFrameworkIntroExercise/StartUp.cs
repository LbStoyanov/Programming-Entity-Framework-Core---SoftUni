using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //string result = GetEmployeesFullInformation(context);
            //string result = GetEmployeesWithSalaryOver50000(context);
            string result = GetEmployeesFromResearchAndDevelopment(context);
            Console.WriteLine(result);
        }

        //public static string GetEmployeesFullInformation(SoftUniContext context)
        //{
        //    StringBuilder result = new StringBuilder();

        //    var allEmployees = context
        //        .Employees
        //        .OrderBy(e => e.EmployeeId)
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.LastName,
        //            e.MiddleName,
        //            e.JobTitle,
        //            e.Salary
        //        })
        //        .ToArray();

        //    foreach (var e in allEmployees)
        //    {
        //        result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        //    }

        //    return result.ToString().TrimEnd();
        //}

        //public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        //{
        //    StringBuilder result = new StringBuilder();

        //    var allEmployees = context
        //        .Employees
        //        .OrderBy(e => e.FirstName)
        //        .Select(e => new
        //        {
        //            e.FirstName,
        //            e.Salary
        //        })
        //        .Where(e => e.Salary > 50000)
        //        .ToArray();

        //    foreach (var employee in allEmployees)
        //    {
        //        result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        //    }


        //    return result.ToString().TrimEnd();
        //}

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context
                .Employees.OrderBy(e=> e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e=> new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .ToList();

            foreach (var e in allEmployees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary:f2}");
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
