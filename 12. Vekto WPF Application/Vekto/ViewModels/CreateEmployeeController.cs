using System.Collections.ObjectModel;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateEmployeeController
    {
        private EmployeeRepository employeeRepository = new EmployeeRepository();

<<<<<<< HEAD
        // Listen, som ListBox'en er bundet til (ItemsSource="{Binding Employees}")
        public ObservableCollection<Employee> employees { get; }
=======
        public ObservableCollection<Employee> Employees { get; }
>>>>>>> 3a906def2ec59b06df0522a196eb16893ed1f8b7

        public CreateEmployeeController()
        {
            employees = new ObservableCollection<Employee>(employeeRepository.GetAll());
        }

        public Employee CreateEmployee(string name, string initials)
        {
            name = name.Trim();
            initials = initials.Trim();

            if (name == "" || initials == "")
                throw new Exception("Udfyld navn og initialer.");

            if (name.Contains(',') || initials.Contains(','))
                throw new Exception("Navn og initialer må ikke indeholde komma.");

            if (employeeRepository.Get(initials) != null)
                throw new Exception("Initialerne " + initials + " findes allerede. Vælg nogle andre initialer.");

            Employee employee = new Employee(name, initials);
            employeeRepository.Add(employee);
<<<<<<< HEAD
            employees.Add(employee); // ListBox'en opdateres selv
=======
            Employees.Add(employee);
>>>>>>> 3a906def2ec59b06df0522a196eb16893ed1f8b7
            return employee;
        }
    }
}
