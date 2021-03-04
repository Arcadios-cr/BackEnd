using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.DTO;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {


        
        private readonly Context _context;

            public StudentsController(Context context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudents()
            {
                var Student = from student in _context.student
                              join student_info in _context.student_info on student.student_id equals student_info.student_id
                              select new StudentDTO
                              {
                                  student_id = student.student_id,
                                  age = student.age,
                                  firstName = student.firstName,
                                  lastName = student.lastName,
                                  adress = student_info.adress,
                                  country = student_info.country,
                                  grade = student_info.grade

                           };

                return await Student.ToListAsync();
            }

            [HttpGet("{id}")]
            public ActionResult<StudentDTO> GetStudents_byId(int id)
            {
                var Student = from student in _context.student
                              join student_info in _context.student_info on student.student_id equals student_info.student_id
                              select new StudentDTO
                              {
                                  student_id = student.student_id,
                                  age = student.age,
                                  firstName = student.firstName,
                                  lastName = student.lastName,
                                  adress = student_info.adress,
                                  country = student_info.country,
                                  grade = student_info.grade

                              };

                var Student_by_id = Student.ToList().Find(x => x.student_id == id);

                if (Student_by_id == null)
                {
                    return NotFound();
                }
                return Student_by_id;
            }
        }
    }

