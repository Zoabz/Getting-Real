using System.IO;

namespace Vekto.Models
{
    public class EmployeeRepo
    {
        private List<Employee> employees;
        private string fileName = "Employee.csv";

        public EmployeeRepo()
        {
            employees = new List<Employee>();
            Load();
        }

        public Employee GetById(string initials)
        {
            foreach (Employee employee in employees)
            {
                if (employee.Initials == initials)
                    return employee;
            }

            return null;
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
            Save();
        }

        // Henter medarbejderne fra tekstfilen. Én medarbejder pr. linje: navn;initialer
        private void Load()
        {
            if (!File.Exists(fileName))
                return;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] parts = line.Split(';');

                    if (parts.Length == 2)
                        employees.Add(new Employee(parts[0], parts[1]));

                    line = reader.ReadLine();
                }
            }
        }

        // Gemmer alle medarbejderne i tekstfilen
        private void Save()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Employee employee in employees)
                {
                    writer.WriteLine(employee.Name + ";" + employee.Initials);
                }
            }
        }
    }
}
