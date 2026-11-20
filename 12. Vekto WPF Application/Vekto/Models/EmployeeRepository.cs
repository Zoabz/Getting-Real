using System.IO;

namespace Vekto.Models
{
    public class EmployeeRepository
    {
        private string fileName = "Employee.csv";
        private List<Employee> employees = new List<Employee>();

        public EmployeeRepository()
        {
            Load();
        }

        private void Load()
        {
            if (!File.Exists(fileName))
                return;

            foreach (string line in File.ReadAllLines(fileName))
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                    employees.Add(new Employee(parts[0], parts[1]));
            }
        }

        private void Save()
        {
            List<string> lines = new List<string>();
            foreach (Employee e in employees)
                lines.Add(e.Name + "," + e.Initials);

            File.WriteAllLines(fileName, lines);
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
            Save();
        }

        public Employee? Get(string initials)
        {
            foreach (Employee e in employees)
            {
                if (e.Initials == initials)
                    return e;
            }
            return null;
        }

        public List<Employee> GetAll()
        {
            return employees;
        }
    }
}
