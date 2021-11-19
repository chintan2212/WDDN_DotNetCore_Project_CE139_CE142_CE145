using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int Id);

        Student Addstudent(Student stu);
        Student Update(Student studentchange);

        Student Delete(int id);
    }
}
