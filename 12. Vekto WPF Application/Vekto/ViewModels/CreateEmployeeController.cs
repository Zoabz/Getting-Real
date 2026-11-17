using System;
using System.Collections.Generic;
using System.Text;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateEmployeeController
    {
        private EmployeeRepository employeeRepository;

        public CreateEmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }

        public Employee CreateEmployee(string name, string initials)
        {
            if (name == "" || initials == "")
            throw new Exception("Udfyld navn og initialer.");

            Employee existing = employeeRepository.Get(initials);
            if (existing != null)
                throw new Exception($"Initialerne {initials} eksisterer allerede. Vælg nogen andre initialer.");

            Employee employee = employeeRepository.Add(name, initials);
            return employee;
        }

        public List<Employee> GetAllEmployees()
        { 
            return employeeRepository.GetAll();
        }
    }
}
