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

            using (StreamReader sr = new StreamReader(fileName))
            {
                string? line = sr.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                        employees.Add(new Employee(parts[0], parts[1]));

                    line = sr.ReadLine();
                }
            }
        }

        private void Save()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Employee e in employees)
                    sw.WriteLine(e.Name + "," + e.Initials);
            }
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
