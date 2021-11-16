using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees;
        public MockEmployeeRepository()
        {
            employees = new List<Employee>()
            {
                new Employee(){ Id=1, Name="Ahmad", Email="ahmad@gmail.com", Department=Dept.IT },
                new Employee(){ Id=2, Name="Ali", Email="ali@gmail.com", Department=Dept.HR },
                new Employee(){ Id=3, Name="Shehroz", Email="shehroz@gmail.com", Department=Dept.IT },
                new Employee(){ Id=4, Name="Danish", Email="danish@gmail.com", Department=Dept.HR }
            };     
        }

        public Employee Add(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
            }
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(int Id)
        {
            return employees.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee EmployeeChanges)
        {
            Employee emp = employees.FirstOrDefault(e => e.Id == EmployeeChanges.Id);
            if (emp != null)
            {
                emp.Name = EmployeeChanges.Name;
                emp.Email= EmployeeChanges.Email;
                emp.Department = EmployeeChanges.Department;
            }
            return emp;
        }
    }
}
