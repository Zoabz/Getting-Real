using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Vekto.Commands;
using Vekto.Models;

namespace Vekto.ViewModels
{
    public class CreateEmployeeController : INotifyPropertyChanged
    {
        private EmployeeRepository employeeRepository;

        public ObservableCollection<Employee> Employees { get; }
        public Employee? SelectedEmployee { get; set; }

        private string name = "";
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string initials = "";
        public string Initials
        {
            get { return initials; }
            set { initials = value; OnPropertyChanged(nameof(Initials)); }
        }

        public ICommand NewEmployee { get; }

        public CreateEmployeeController()
        {
            employeeRepository = new EmployeeRepository();
            Employees = new ObservableCollection<Employee>(employeeRepository.GetAll());
            NewEmployee = new NewEmployee();
        }

        public Employee CreateEmployee()
        {
            string newName = Name.Trim();
            string newInitials = Initials.Trim();

            if (newName == "" || newInitials == "")
                throw new Exception("Udfyld navn og initialer.");

            if (employeeRepository.Get(newInitials) != null)
                throw new Exception($"Initialerne {newInitials} eksisterer allerede. Vælg nogen andre initialer.");

            Employee employee = employeeRepository.Add(newName, newInitials);
            Employees.Add(employee);

            Name = "";
            Initials = "";
            return employee;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
