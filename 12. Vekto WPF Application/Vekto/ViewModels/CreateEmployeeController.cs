using System.Collections.ObjectModel;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateEmployeeController
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();

        // Listen, som ListBox'en er bundet til (ItemsSource="{Binding Employees}")
        public ObservableCollection<Employee> Employees { get; }

        public CreateEmployeeController()
        {
            Employees = new ObservableCollection<Employee>(employeeRepository.GetAll());
        }

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
            Employees.Add(employee); // ListBox'en opdateres selv
            return employee;
        }
    }
}
