using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = 3,
                   name = "Chintan",
                   department = Dept.CE,
                   sem = 5,
                   email = "chintan@gmail.com",
                   gender = "Male"
               }


               );
        }
    }

}
