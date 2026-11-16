using Vekto.Models;

namespace Vekto.Controllers
{
    // UC1 Opret Medarbejder
    public class CreateEmployeeController
    {
        private EmployeeRepo employeeRepo;

        public CreateEmployeeController()
        {
            employeeRepo = new EmployeeRepo();
        }

        public Employee CreateEmployee(string name, string initials)
        {
            if (name == "" || initials == "")
                throw new Exception("Skriv medarbejderens navn og initialer.");

            if (employeeRepo.GetById(initials) != null)
                throw new Exception("Initialerne " + initials + " er allerede i brug. Vælg andre initialer.");

            Employee employee = new Employee(name, initials);
            employeeRepo.Add(employee);

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeRepo.GetAll();
        }
    }
}
