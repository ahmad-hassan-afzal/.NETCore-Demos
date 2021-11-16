using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Oop_Practice
{
                                    // Generics
    class Generic_Example<T>
    {
        T[] arr;
        public T[] Arr { 
            get 
            {
                return this.arr;
            }
            set
            {
                this.arr = value;
            }
        }

        public void displayArray()
        {
            for (int i = 0; i < this.arr.Length; i++)
            {
                Console.Write(this.arr[i] + " ");
            }
            Console.WriteLine();
        }

        public void displayArray<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
        }
    }
                                    // Interfaces
    interface Test_Interface
    {
        void welcome();
    }
    class Test_Implementer : Test_Interface
    {
        public void welcome()
        {
            Console.WriteLine("Welcome: Inside Test Implementation");
        }
    }

                                    // Abstract Class
    abstract class Abstract_Class
    {
        public abstract void method();
        public virtual void method2()
        {
            Console.WriteLine("Inside Abstract Class");
        }
    }
    class Abstract_Child : Abstract_Class
    {
        public override void method()
        {
            Console.WriteLine("Abstract Child Class");
        }
        public override void method2()
        {
            Console.WriteLine("Abstract Child Class method 2");
        }

    }

                                    // Method Overrriding + Sealed + Virtual

    //class Parent
    //{
    //    public virtual void print()
    //    {
    //        Console.WriteLine("Parent Class");
    //    }
    //}
    //sealed class Child : Parent
    //{
    //    public sealed override void print()
    //    {
    //        Console.WriteLine("Child Class");
    //    }
    //}
    //class GrandChild : Child
    //{
    //    public override void print()
    //    {
    //        Console.WriteLine("Grand Child Class");
    //    }
    //}

                                    // Inheritance Basics + Ctor Overloading + base() + Virtual
    //class Vehicle 
    //{
    //    public string Company { get; set; }
    //    public int FuelCapacity { get; set; }
    //    public Vehicle() { }
    //    public Vehicle(string company, int fuel)
    //    {
    //        Company = company;
    //        FuelCapacity = fuel;
    //    }
    //}
    //class Car : Vehicle
    //{
    //    public int Seats { get; set; }
    //    public Car(string company, int fuelCapacity, int seats) : base(company, fuelCapacity)
    //    {
    //        Seats = seats;
    //    }

    //}
    //class Bike : Vehicle
    //{
    //    public int ModelYear { get; set; }
    //    public Bike() : base() { }
    //    public Bike(string company, int fuelCapacity, int model ) : base(company, fuelCapacity)
    //    {
    //        ModelYear = model;
    //    }

    //}
    class Program
    {

//         Multi-Threading
        static void function1()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine("Function 1: " + i );
            }
        }
        static void function2()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine("Function 2: " + i);
                if ( i == 25 )
                {
                    Console.WriteLine("This Thread is Put to sleep for 5 seconds");
                    Thread.Sleep(5000);
                }
            }
        }
        static void function3()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine("Function 3: " + i);
            }
        }
        static void Main(string[] args)
        {

            //            Extension Methods
            //SomeClass obj = new SomeClass();
            //obj.method1();
            //obj.method2();
            //obj.method3();
            //obj.method4(); // Extended
            //obj.method5(); // Extended


            //            Multi-Threading

            //Thread th1 = new Thread(function1);
            //Thread th2 = new Thread(function2);
            //Thread th3 = new Thread(function3);

            //th1.Start();
            //th2.Start();
            //th3.Start();

            //            Misc.

            //ArrayList departments = new ArrayList();
            //ArrayList students = new ArrayList();

            //string choice = "";
            //while (choice != "x" || choice != "X")
            //{
            //    Console.WriteLine("a:\tNew Student");
            //    Console.WriteLine("d:\tNew Department");
            //    Console.WriteLine("t:\tNew Teacher");
            //    Console.WriteLine("l:\tList All Student");
            //    Console.WriteLine("x:\tExit");

            //    choice = Console.ReadLine();

            //    if (choice == "a") { }
            //    else if (choice == "d")
            //    {
            //        Console.Write("Enter Department Name: ");
            //        string dpt = Console.ReadLine();
            //        departments.Add(new Department(dpt));
            //        Console.WriteLine("{0} Added to Departments", dpt);
            //    }
            //    else if (choice == "l")
            //    {
            //        foreach (Student i in students)
            //        {
            //            Console.WriteLine(i);
            //        }
            //    }

            //}

            //Console.Write("Enter Department Name: ");
            //string dptName = Console.ReadLine();
            //departments.Add(new Department(dptName));
            //Console.WriteLine("{0} Added to Departments", dptName);

            //Department depart = new Department("CS");
            //Teacher teacher = new Teacher("Waqar Ahmad", depart);

            //Student obj = new Student(123, "Danish Tariq", "danish133@gmail.com", teacher);

            //Console.WriteLine(obj.ToString());
            //Console.WriteLine(obj.getStudent().ToString());

            //            Oop Basics

            //Car city = new Car("Honda", 40, 4);

            //Bike cg125 = new Bike();
            //cg125.Company = "Honda";
            //cg125.FuelCapacity = 11;
            //cg125.ModelYear = 2020;

            //Console.WriteLine(city);

            //Parent obj = new Child();
            //obj.print();

            //Abstract_Child obj = new Abstract_Child();
            //obj.method2();

            //Test_Implementer obj = new Test_Implementer();
            //obj.welcome();

            //            Generics 

            //int[] numbers = { 1, 2, 3, 4, 5 };
            //string[] strings = {"A","B","C"};
            //float[] floats = { 1.3f, 2f, 3.4f, 4.6f, 5.2f };

            //Generic_Example<string> obj = new Generic_Example<string>();

            //obj.Arr = strings;
            //obj.displayArray();
            //Console.WriteLine("-------------------------");
            //obj.displayArray(numbers);
            //obj.displayArray(strings);
            //obj.displayArray(floats);

            //            ArrayList

            //ArrayList obj = new ArrayList();
            //obj.Add(2);
            //obj.Add("jsd");
            //obj.Add(1.2f);
            //obj.Add('a');
            //obj.Add(1.2);
            //foreach (object i in obj)
            //{
            //    Console.Write(i+" ");
            //}
            //Console.WriteLine();

            //            HashTables & methods

            //Hashtable data = new Hashtable();
            //data.Add("EmpID", 2134);
            //data.Add("Name", "Ali Ahmad");
            //data.Add("Salary", 45000);
            //data.Add("Joining", DateTime.Now);

            //Hashtable data = new Hashtable()
            //{
            //    { "EmpID", 2134 },
            //    { "Name", "Ali Ahmad" },
            //    { "Salary", 45000 },
            //    { "Joining", DateTime.Now },
            //    { "Age", 22 }
            //};

            //foreach (object key in data.Keys)
            //{
            //    Console.WriteLine(key + ": " + data[key]);
            //}

            //data.Remove("Age");
            //data.Clear();
            //data.Contains("Name");
            //data.ContainsKey("Name");
            //data.ContainsValue("Ali Ahmad");
            //Console.WriteLine(data.Count);
            //"EmpID".GetHashCode();

            //Console.WriteLine("----------------------");

            //foreach (object key in data.Keys)
            //{
            //    Console.WriteLine(key + ": " + data[key]);
            //}

            //            Stack

            //Stack obj = new Stack();
            //obj.Push(10);
            //obj.Push("Ali");
            //obj.Push(15.0f);
            //obj.Push(23.2);
            //obj.Push(null);
            //obj.Push("Ali Ahmad");

            //Console.WriteLine("Pop: {0}", obj.Pop());
            //Console.WriteLine("Pop(null): {0}", obj.Pop());
            //Console.WriteLine("Count: {0}", obj.Count);
            //Console.WriteLine("Peek: {0}", obj.Peek());
            //Console.WriteLine("Contains(Ali): {0}", obj.Contains("Ali"));
            //obj.Clear();

            //Console.WriteLine();

            //foreach (object i in obj)
            //    Console.WriteLine(i);


            //            Queue

            //Queue obj = new Queue();
            //obj.Enqueue(10);
            //obj.Enqueue("Ali");
            //obj.Enqueue(15.0f);
            //obj.Enqueue(23.2);
            //obj.Enqueue(false);

            //Console.WriteLine("Pop(10): {0}", obj.Dequeue());
            //Console.WriteLine("Pop(Ali): {0}", obj.Dequeue());
            //Console.WriteLine("Count: {0}", obj.Count);
            //Console.WriteLine("Peek: {0}", obj.Peek());
            //Console.WriteLine("Contains(Ali): {0}", obj.Contains("Ali"));
            //obj.Clear();

            //Console.Write("Elements in Queue: ");

            //foreach (object i in obj)
            //    Console.Write(i+" ");

            //            Generic List<T>

            //List<string> list = new List<string>();
            //list.Add("something");
            //list.Remove("something");
            //list.RemoveAt(0);
            //Console.WriteLine(list.Count);
            //Console.WriteLine(list.Capacity);
            //Console.WriteLine(list[0]);

            //List<int> numbers = new List<int>();
            //numbers.Add(34);
            //numbers.Add(56);
            //numbers.Add(323);
            //numbers.Add(56);
            //numbers.Add(36);

            //foreach (object i in numbers)
            //    Console.Write(i + " ");
            //Console.WriteLine("\n---------------------");

            //numbers.Sort();
            //numbers.Reverse();
            //numbers.AddRange(numbers);
            //numbers.Insert(2, 90);
            //numbers.InsertRange(2, numbers);
            //numbers.Remove(56);
            //numbers.RemoveAt(2);
            //numbers.RemoveRange(1, 2);
            //Console.WriteLine(numbers.Contains(323));
            //Console.WriteLine(numbers.IndexOf(323));
            //Console.WriteLine(numbers.LastIndexOf(56));
            //numbers.Clear();
            //int[] arr = numbers.ToArray();

            //            students.RemoveAll(std => std.age < 18);
            //            students.Exists(std => std.age < 18);
            //            Student std = students.Find(s => s.age > 18); // First Student with age > 18
            //            Student std = students.Find(s => s.age > 18); // First Student with age > 18
            //            List<Student> stds = students.FindAll(s => s.age > 18); // All Student with age > 18
            //            students.FindIndex(s => s.age > 18); // Index of First Student with age > 18
            //            students.FindLastIndex(s => s.age > 18); // Index of Last Student with age > 18


            //foreach (object i in numbers)
            //    Console.Write(i + " ");
            //Console.WriteLine("\n---------------------");


            //            Dictionary

            //Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //dictionary.Add("one", 1);
            //dictionary.Add("two", 2);
            //dictionary.Add("three", 3);
            //dictionary.Add("four", 4);

            //foreach (string key in dictionary.Keys)
            //{
            //    Console.WriteLine(key + ": " + dictionary[key]);
            //}

            //Dictionary<string, int> data = new Dictionary<string, int>()
            //{
            //    { "one", 1 },
            //    { "two", 2 },
            //    { "three", 3 },
            //    { "four", 4 }
            //};
            //foreach (KeyValuePair<string, int> i in data)
            //{
            //    Console.WriteLine(i.Key + ": " + i.Value);
            //}

            //            Exception Handling
            //try
            //{
            //int x = 0;
            //Console.WriteLine(10/x);

            //string x = null;
            //Console.WriteLine(x.Length);

            //    int[] arr = { 10 };
            //    Console.WriteLine(arr[1]);
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("DBZE: " + ex.Message);
            //}
            //catch (NullReferenceException ex)
            //{
            //    Console.WriteLine("NRE: " + ex.Message);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Finally Block Executed.");
            //}

            //try
            //{
            //    Console.Write("Enter Age: ");
            //    int age = int.Parse(Console.ReadLine());
            //    if (age >= 18)
            //    {
            //        Console.WriteLine("Vote Casted..");
            //    }
            //    else
            //    {
            //        throw new Exception("You're not eligible for voting.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
    }
}
