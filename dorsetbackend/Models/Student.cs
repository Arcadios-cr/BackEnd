using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public int student_id { get; set; }
        public int age { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
