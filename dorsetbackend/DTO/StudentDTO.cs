using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.DTO
{
    public class StudentDTO
    {
        public int student_id{get;set;}
        public int age { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string adress { get; set; }
        public string country { get; set; }
        public int grade { get; set; }


    }
}
