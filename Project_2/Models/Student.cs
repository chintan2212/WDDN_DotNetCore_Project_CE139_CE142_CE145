using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int sem { get; set; }
        public string email { get; set; }
        public Dept department { get; set; }
        public string gender { get; set; }



    }
}
