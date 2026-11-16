using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vekto.Models
{
    public class EmployeeRepository
    {
        private List<Employee> employee;

        public EmployeeRepository()
        {
            employee = new List<Employee>();
            InitializeRepository();
        }

        private void InitializeRepository()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("Employee.csv"))
                {
                    // Read the stream to a string, and instantiate a Person object
                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(',');

                        // parts[0] contains first name, parts[1] contains last name, parts[2] contains age as text, parts[3] contains phone

                        this.Add(parts[0], parts[1]);

                        //Read the next line
                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Employee Add(string name, string initials)
        {
            Employee result = null;

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(initials))
            {
                result = new Employee()
                {
                    Name = name,
                    Initials = initials
                };

                // Add to persons list
                employee.Add(result);
            }
            else
                throw (new ArgumentException("Not all arguments are valid"));

            return result;
        }

        public Employee Get(string initials)
        {
            Employee result = null;

            foreach (Employee e in employee)
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
            return employee;
        }

        public void Update(string name, string initials)
        {
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Employee foundEmployee = this.Get(initials);

            if (foundEmployee != null)
            {
                if (!string.IsNullOrEmpty(name) &&
                    !string.IsNullOrEmpty(initials))
                {
                    // Update only changed properties for this person
                    if (foundEmployee.Name != name)
                        foundEmployee.Name = name;
                    if (foundEmployee.Initials != initials)
                        foundEmployee.Initials = initials;
                }
                else
                    throw (new ArgumentException("Not all arguments for employee are valid"));
            }
            else
                throw (new ArgumentException("Employee with initials = " + initials + " not found"));
        }

        public void Remove(string initials)
        {
            // Find the person in the internal persons list with same Id as the 'id'-parameter
            Employee foundPerson = this.Get(initials);

            if (foundPerson != null)
                employee.Remove(foundPerson);
            else
                throw (new ArgumentException("Employee with initials = " + initials + " not found"));
        }
    }
}

