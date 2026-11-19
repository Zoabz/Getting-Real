using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    public class EmployeeRepository
    {
        private List<Employee> employees;

        public EmployeeRepository()
        {
            employees = new List<Employee>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            using (StreamReader sr = new StreamReader("Employee.csv"))
            {
                string? line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');
                    employees.Add(new Employee(parts[0], parts[1]));

                    line = sr.ReadLine();
                }
            }
        }

        private void Save()
        {
            List<string> lines = new List<string>();
            foreach (Employee e in employees)
            {
                lines.Add(e.Name + "," + e.Initials);
            }
            File.WriteAllLines("Employee.csv", lines);
        }

        public Employee Add(string name, string initials)
        {
            if (name == "" || initials == "")
                throw (new ArgumentException("Not all arguments are valid"));

            Employee result = new Employee(name, initials);

            employees.Add(result);
            Save();
            return result;
        }

        public Employee? Get(string initials)
        {
            Employee? result = null;

            foreach (Employee e in employees)
            {
                if (e.Initials == initials)
                {
                    result = e;
                    break;
                }
            }

            return result;
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public void Update(string name, string initials)
        {
            Employee? foundEmployee = this.Get(initials);

            if (foundEmployee == null)
                throw (new ArgumentException("Employee with initials = " + initials + " not found"));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Not all arguments for employee are valid");

            foundEmployee.Name = name;
            Save();
        }

        public void Remove(string initials)
        {
            Employee? foundEmployee = this.Get(initials);

            if (foundEmployee == null)
                throw (new ArgumentException("Employee with initials = " + initials + " not found"));

            employees.Remove(foundEmployee);
            Save();
        }
    }
}
