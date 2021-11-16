using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //// Aggregate Extension Methods
            //IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);
            //IEnumerable<int> oddNumbers = numbers.Where(n => n % 2 == 1);

            //IEnumerable<int> evens = from num in numbers
            //                         where num % 2 == 0
            //                         select num; // numbers.Where(n => n % 2 == 0);
            //IEnumerable<int> odds = from num in numbers
            //                        where num % 2 == 1
            //                        select num; // numbers.Where(n => n % 2 == 1);

            //int min = numbers.Min();
            //int minEven = numbers.Where(n => n % 2 == 0).Min();
            //int minOdd = numbers.Where(n => n % 2 == 1).Min();
            //int max = numbers.Max();
            //int maxEven = numbers.Where(n => n % 2 == 0).Max();
            //int maxOdd = numbers.Where(n => n % 2 == 1).Max();
            //int count = numbers.Count();
            //int sum = numbers.Sum();
            //double average = numbers.Average();

            //string[] strings = { "abc", "def", "ghi" };
            //Console.WriteLine(strings.Aggregate((a, b) => a + ", " + b));

            //int _min = (from num in numbers select num).Min();
            //int _minEven = (from num in numbers where num % 2 == 0 select num).Min();
            //int _minOdd = (from num in numbers where num % 2 == 1 select num).Min();
            ////same for Max(), Count(), Sum(), Average()


            //List<Employee> employeesHR = new List<Employee>()
            //{
            //    new Employee(){ Name = "Ali" },
            //    new Employee(){ Name = "Sara" },
            //    new Employee(){ Name = "Huma" }
            //};

            //List<Employee> employeesIT = new List<Employee>()
            //{
            //    new Employee(){ Name = "Ahmad",  Salary = 34000 },
            //    new Employee(){ Name = "Hamza", Salary = 43000 },
            //    new Employee(){ Name = "Danish", Salary = 54000 }
            //};

            //List<Department> departments = new List<Department>()
            //{
            //    new Department(){ Name = "HR", Employees = employeesHR },
            //    new Department(){ Name = "IT", Employees = employeesIT }
            //};

            //var result = departments.Where(dept => dept.Name == "HR" || dept.Name == "IT");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item.Name + ": ");
            //    Console.WriteLine("-------------------");
            //    foreach (var emp in item.Employees.Select(emp => new { Name = emp.Name, AnnualSalary = emp.Salary * 12, Bonus = emp.Salary * .1 }))
            //        Console.WriteLine("\tName: " + emp.Name + " - Annual Salary: " + emp.AnnualSalary + " - Monthly Bonus: " + emp.Bonus);

            //}

            //// SelectMany()
            //Console.WriteLine("\n\t============================================");
            //var allEmployees = departments.SelectMany(d => d.Employees, (dpt, emp) =>
            //                                            new { EmployeeName = emp.Name, DepartmentName = dpt.Name });
            //allEmployees = from department in departments
            //               from employee in department.Employees
            //               select new { EmployeeName = employee.Name, DepartmentName = department.Name };

            //foreach (var emp in allEmployees)
            //    Console.WriteLine($"Employee: {emp.EmployeeName} \tDepartement: {emp.DepartmentName}");


            //Console.WriteLine("\n\t============================================");

            //// Ordering in linq
            //foreach (var item in employeesIT.OrderByDescending(emp => emp.Salary))
            //    Console.WriteLine(item.Name);


            //Console.WriteLine();

            //foreach (var item in (from emp in employeesIT orderby emp.Salary ascending select emp))
            //    Console.WriteLine(item.Name);


            //Console.WriteLine("--------------");

            //foreach (var item in employeesIT.OrderByDescending(emp => emp.Salary).ThenByDescending(emp => emp.Name))
            //    Console.WriteLine(item.Name);

            //Console.WriteLine();

            //var employees = from emp in employeesIT 
            //                orderby emp.Salary ascending, emp.Name descending 
            //                select new { emp.Name, emp.Salary };

            //foreach (var item in employees)
            //    Console.WriteLine($"{item.Name}: {item.Salary}");

            //foreach (var item in numbers.Reverse()) //Reverse
            //    Console.WriteLine(item);


            //Console.WriteLine("\n\t============================================");

            //// Ordering in linq
            ////Take(count)
            //foreach (var item in numbers.Reverse().Take(5)) // (from n in numbers select n).Take(5)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();
            ////Skip(count)
            //foreach (var item in numbers.Reverse().Skip(5)) // (from n in numbers select n).Skip(5)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();
            ////TakeWhile(condition)
            //foreach (var item in numbers.TakeWhile(n => n > 10)) // (from n in numbers select n).Skip(5)
            //{
            //    Console.WriteLine(item);
            //}




            // Paging usin Skip() && Take()


            List<Employee> employees = new List<Employee>()
            {
                new Employee(){ Name = "1 Ahmad",  Salary = 34000, City = "Faisalabad" },
                new Employee(){ Name = "2 Hamza", Salary = 43000, City = "Islamabad" },
                new Employee(){ Name = "3 Danish", Salary = 54000, City = "Lahore" },
                new Employee(){ Name = "4 Ahmad",  Salary = 34000, City = "Islamabad" },
                new Employee(){ Name = "5 Hamza", Salary = 43000, City = "Faisalabad" },
                new Employee(){ Name = "6 Danish", Salary = 54000, City = "Lahore" },
                new Employee(){ Name = "7 Ahmad",  Salary = 34000, City = "Lahore" },
                new Employee(){ Name = "8 Hamza", Salary = 43000, City = "Faisalabad" },
                new Employee(){ Name = "9 Danish", Salary = 54000, City = "Islamabad" },
                new Employee(){ Name = "10 Ahmad",  Salary = 34000, City = "Faisalabad" },
                new Employee(){ Name = "11 Hamza", Salary = 43000, City = "Lahore" },
                new Employee(){ Name = "12 Danish", Salary = 54000, City = "Lahore" },
                new Employee(){ Name = "13 Ahmad",  Salary = 34000, City = "Islamabad" },
                new Employee(){ Name = "14 Hamza", Salary = 43000, City = "Faisalabad" },
                new Employee(){ Name = "15 Danish", Salary = 54000, City = "Islamabad" },
                new Employee(){ Name = "16 Ahmad",  Salary = 34000, City = "Lahore" },
                new Employee(){ Name = "17 Hamza", Salary = 43000, City = "Lahore" },
                new Employee(){ Name = "18 Danish", Salary = 54000, City = "Faisalabad" },
                new Employee(){ Name = "19 Ahmad",  Salary = 34000, City = "Islamabad" },
                new Employee(){ Name = "19 Hamza", Salary = 43000, City = "Faisalabad" }
            };

            int pageNumber;
            int pageSize = 5;

            Console.Write("Enter Page Number [1-4]:");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out pageNumber))
                Console.WriteLine("Page Number must be [1-4]");
            else
            {
                if (pageNumber < 1 || pageNumber > 4)
                    Console.WriteLine($"Page: {pageNumber} does not exist. Please Enter a Valid Page Number");
                else
                {
                    var employeesOnCurrentPage = employees.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                    foreach (var item in employeesOnCurrentPage)
                    {
                        Console.WriteLine($"Name: {item.Name}\tSalary: {item.Salary}");
                    }
                }
            }

            // Type Conversion
            Console.WriteLine("\n\n");
            Employee[] employeeArray = employees.ToArray();
            Dictionary<string, double> employeeDict = employees.ToDictionary(e => e.Name, e => e.Salary ); // Keys has to be unique
            Dictionary<string, Employee> employeeDict2 = employees.ToDictionary(e => e.Name); // only key-selector

            ILookup<string, Employee> employeesByCity = employees.ToLookup(e => e.City); // Similar to dictionary but we can put multiple elements with same key

            foreach (var kvp in employeesByCity)
            {
                Console.WriteLine(kvp.Key);
                foreach (var employee in employeesByCity[kvp.Key])
                    Console.WriteLine($"\t{employee.Name}\t-\t{employee.Salary}");
            }

            //Cast vs OfType

            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add("4");
            list.Add("string");

            IEnumerable<int> listCastedToInt = list.Cast<int>();  // Defer execution going to throw exception on "4"
            IEnumerable<int> listOfTypeInt = list.OfType<int>();  // Defer execution going to ignore elements other than int-type

            var employeeGroup = employees.GroupBy(emp => emp.City);
            foreach (var item in employeeGroup)
            {
                Console.WriteLine($"Count({item.Key}): {item.Count()}");
                Console.WriteLine($"Max-Salary({item.Key}): {item.Max(e => e.Salary)}");
                Console.WriteLine($"Sum-Salary({item.Key}): {item.Sum(e => e.Salary)}");
                Console.WriteLine($"Count({item.Key}, Salary > 35k): {item.Count(e => e.Salary > 35000)}");
            }


        }
    }
}
