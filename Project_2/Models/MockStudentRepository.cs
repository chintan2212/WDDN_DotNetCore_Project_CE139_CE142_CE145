using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> studentslist;

        public MockStudentRepository()
        {
            studentslist = new List<Student>()
            {
                 new Student() {Id=1,name="shail",sem=5,email="shail@gmail.com",department=Dept.CE,gender="male"},
                 new Student() {Id=2,name="virat",sem=6,email="virat@gmail.com",department=Dept.IT,gender="male"},
                 new Student() {Id=3,name="rohit",sem=7,email="rohit@yahoo.com",department=Dept.EC,gender="male"},
            };
        }
        public Student Addstudent(Student stu)
        {
            stu.Id = studentslist.Max(s => s.Id) + 1;
            studentslist.Add(stu);
            return stu;
        }

        public Student Delete(int id)
        {
            Student students = studentslist.FirstOrDefault(s => s.Id == id);
            if (students != null)
            {
                studentslist.Remove(students);
            }
            return students;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return studentslist;  
        }

        public Student GetStudent(int Id)
        {
            return this.studentslist.FirstOrDefault(s => s.Id == Id);
        }

        public Student Update(Student studentchange)
        {
            Student students = studentslist.FirstOrDefault(s => s.Id == studentchange.Id);
            if (students != null)
            {
                students.name = studentchange.name;
                students.sem = studentchange.sem;
                students.email = studentchange.email;
                students.department = studentchange.department;
                students.gender = studentchange.gender;

            }
            return students;

        }
    }
}
