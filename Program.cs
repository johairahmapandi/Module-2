using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Position: {Position}, Salary: {Salary:C}";
        }

    }
    public class EmployeeManagementSystem
    {
        private List<Employee> _employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            if (_employees.Any(e => e.Id == employee.Id))
            {
                Console.WriteLine("Error: Employee with this ID already exists.");
                return;
            }
            _employees.Add(employee);
            Console.WriteLine("Employee added successfully.");
        }
        public void ListAllEmployees()
        {
            if (_employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }
            Console.WriteLine("\nEmployee List:");
            _employees.ForEach(e => Console.WriteLine(e));
        }
        public void FindEmployeeById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }
            Console.WriteLine($"\nEmployee Found: {employee}");
        }
        public void UpdateEmployee(int id, string name, string position, decimal salary)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                Console.WriteLine("Error: Employee not found.");
                return;
            }
            employee.Name = name;
            employee.Position = position;
            employee.Salary = salary;
            Console.WriteLine("Employee details updated successfully.");
        }
        public void DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                Console.WriteLine("Error: Employee not found.");
                return;
            }
            _employees.Remove(employee);
            Console.WriteLine("Employee removed successfully.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var system = new EmployeeManagementSystem();
            while (true)
            {
                Console.WriteLine("\nEmployee Management Menu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. List All Employees");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoose an option: ");

                int choice = int.Parse(Console.ReadLine() ?? "6");
                if (choice == 6) break;

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Employee ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Position: ");
                        string position = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());
                        system.AddEmployee(new Employee { Id = id, Name = name, Position = position, Salary = salary });
                        break;
                    case 2:
                        system.ListAllEmployees();
                        break;
                    case 3:
                        Console.Write("Enter Employee ID to Find: ");
                        id = int.Parse(Console.ReadLine());
                        system.FindEmployeeById(id);
                        break;
                    case 4:
                        Console.Write("Enter Employee ID to Update: ");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        name = Console.ReadLine();
                        Console.Write("Enter New Position: ");
                        position = Console.ReadLine();
                        Console.Write("Enter New Salary: ");
                        salary = decimal.Parse(Console.ReadLine());
                        system.UpdateEmployee(id, name, position, salary);
                        break;
                    case 5:
                        Console.Write("Enter Employee ID to Delete: ");
                        id = int.Parse(Console.ReadLine());
                        system.DeleteEmployee(id);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;

                }
            }
        }
    }
}
