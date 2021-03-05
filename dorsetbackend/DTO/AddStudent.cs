using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.DTO
{
    public class AddStudent
    {
        [Required]
        public int age { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public int grade { get; set; }
        [Required]
        public string adress { get; set; }
    }
}
