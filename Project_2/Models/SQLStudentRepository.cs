using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public SQLStudentRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Student Addstudent(Student stu)
        {
            context.students.Add(stu);
            context.SaveChanges();
            return stu;
        }

        public Student Delete(int id)
        {
            Student stu = context.students.Find(id);
            if (stu != null)
            {
                context.students.Remove(stu);
                context.SaveChanges();
            }
            return stu;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.students;
        }

        public Student GetStudent(int Id)
        {
            return context.students.Find(Id);
        }

        public Student Update(Student studentchange)
        {
            var stu = context.students.Attach(studentchange);
            stu.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentchange;
        }
    }
}
