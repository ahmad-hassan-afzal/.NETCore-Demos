using System;
using System.Collections.Generic;
using System.Text;

namespace Oop_Practice
{
    class Student
    {
        private int rollNo;
        private string name;
        private string email;
        private Teacher teacher;
        public Student(){}
        public Student(int rollNo, string name, string email, Teacher teacher)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.email = email;
            this.teacher = teacher;
        }

        /*public void setRollNo(int rollNo) { this.rollNo = rollNo; }
        public int getRollNo() { return this.rollNo; }
        public void setName(string name) { this.name = name; }
        public string getName() { return this.name; }
        public void setEmail(string email) { this.email = email; }
        public string getEmail() { return this.email; }*/
        public void setTeacher(Teacher teacher) { this.teacher = teacher; }
        public Teacher getTeacher() { return this.teacher; }
        public void setStudent(int rollNo, string name, string email) {
            this.rollNo = rollNo;
            this.name = name;
            this.email = email;
        }
        public Student getStudent() {
            return this;
        }


        public override string ToString()
        {
            return String.Format("Roll No: {0}\nName: {1}\nEmail: {2}\n----------\nTutor: {3}\n----------", this.rollNo, this.name, this.email, this.teacher);
        }
    }
}
