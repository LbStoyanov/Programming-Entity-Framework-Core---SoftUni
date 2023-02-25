using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            //string result = GetEmployeesFullInformation(context);
            //string result = GetEmployeesWithSalaryOver50000(context);
            //string result = AddNewAddressToEmployee(context);
            //string result = GetEmployeesFromResearchAndDevelopment(context);
            //string result = GetEmployeesInPeriod(context);         
            //string result = GetAddressesByTown(context);
            //string result = GetEmployee147(context);
            //string result = GetDepartmentsWithMoreThan5Employees(context);
            //string result = GetLatestProjects(context);
            //string result = IncreaseSalaries(context);
            string result = GetEmployeesByFirstNameStartingWithSa(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();


            foreach (var emp in allEmployees)
            {
                result.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
            }

            return result.ToString().TrimEnd();   
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in allEmployees)
            {
                result.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            var allEmployees = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .ToArray();

            foreach (var employee in allEmployees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }


            return result.ToString().TrimEnd();
        }

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

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder result = new StringBuilder();

            Address newAddress = new Address();
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;
            context.Addresses.Add(newAddress);

            var employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

           
            employee.Address = newAddress;
             context.SaveChangesAsync();

            var addresses = context
                .Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(e => new 
                {
                    e.Address.AddressText
                })
                .ToList();

            foreach (var ad in addresses)
            {
                result.AppendLine($"{ad.AddressText}");
            }
            

            return result.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            string dateFormat = "M/d/yyyy h:mm:ss tt";

            var employeesWithProjects = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate,
                        ProjectEndDate = ep.Project.EndDate
                    })
                })
                .Take(10)
                .ToList();

            foreach (var employee in employeesWithProjects)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.ProjectStartDate.ToString(dateFormat);
                    var endDate = project.ProjectEndDate.HasValue ? project.ProjectEndDate.Value.ToString(dateFormat) : "not finished";

                    output.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var allAddressesInTown = context
                .Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    Text = a.AddressText,
                    Town = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToList();


            foreach (var address in allAddressesInTown)
            {
               
                output.AppendLine($"{address.Text}, {address.Town} - {address.EmployeesCount} employees");
            }

            return output.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();


            var searchedEmployee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .First(e => e.EmployeeId == 147);
            

            output.AppendLine($"{searchedEmployee.FirstName} {searchedEmployee.LastName} - {searchedEmployee.JobTitle}");

            var employeeProjects =
                searchedEmployee.EmployeesProjects.OrderBy(ep => ep.Project.Name);

            foreach (var project in employeeProjects)
            {
                output.AppendLine(project.Project.Name);
            }

            

            return output.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var departmentWithMoreThan5Employees = 
                context
                    .Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        d.Name,
                        ManagerFirstName = d.Manager.FirstName,
                        ManagerLastName = d.Manager.LastName,
                        d.Employees
                      
                    });

            foreach (var department in departmentWithMoreThan5Employees)
            {
                output.AppendLine($"{department.Name} – {department.ManagerFirstName} {department.ManagerLastName}");
                //Console.WriteLine($"{department.Name} – {department.ManagerFirstName} {department.ManagerLastName}");

                var employees = 
                    department
                        .Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName);

                foreach (var employee in employees)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                    //Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }


            return output.ToString().TrimEnd();

        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            string dateFormat = "M/d/yyyy h:mm:ss tt";


            var last10StartedProjects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .Take(10)
                .ToList();
                
            var convertedProjects = last10StartedProjects.OrderBy(p => p.Name);

            foreach (var project in convertedProjects)
            {
                output.AppendLine($"{project.Name}");
                output.AppendLine($"{project.Description}");
                output.AppendLine($"{project.StartDate.ToString(dateFormat)}");
            }

                

            return output.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var searchedEmployees = context
                .Employees
                .Where(ed => ed.Department.Name == "Engineering"
                             || ed.Department.Name == "Tool Design"
                             || ed.Department.Name == "Marketing"
                             || ed.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
                

            foreach (var employee in searchedEmployees)
            {
                employee.Salary *= 1.12m;
              
                output.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
                
            }

            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

    }
}
