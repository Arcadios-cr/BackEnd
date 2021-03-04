using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class Student_info
    {
        [Key]
        public int student_id { get; set; }
        public string adress { get; set; }
        public string country { get; set; }
        public int grade { get; set; }

    }
}
