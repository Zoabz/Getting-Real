using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateEmployeeController
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        // UC1: opret medarbejderen (følger SD UC1)
        public Employee CreateEmployee(string name, string initials)
        {
            name = name.Trim();
            initials = initials.Trim();

            if (name == "" || initials == "")
                throw new Exception("Udfyld navn og initialer.");

            // Komma bruges til at adskille felterne i csv-filen
            if (name.Contains(',') || initials.Contains(','))
                throw new Exception("Navn og initialer må ikke indeholde komma.");

            if (employeeRepository.Get(initials) != null)
                throw new Exception("Initialerne " + initials + " findes allerede. Vælg nogle andre initialer.");

            Employee employee = new Employee(name, initials);
            employeeRepository.Add(employee);
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepository.GetAll();
        }
    }
}
