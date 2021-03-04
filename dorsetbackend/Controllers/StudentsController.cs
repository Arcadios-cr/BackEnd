using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Data;
using TestApplication.DTO;
using TestApplication.Models;

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
                          join student_info in _context.student_info on student.id equals student_info.student_id
                          select new StudentDTO
                          {
                              student_id = student.id,
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
                          join student_info in _context.student_info on student.id equals student_info.student_id
                          select new StudentDTO
                          {
                              student_id = student.id,
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
        [HttpPost]
        public async Task<ActionResult> Add_students(AddStudent studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = new Student()
            {
                age = studentDTO.age,
                firstName = studentDTO.firstName,
                lastName = studentDTO.lastName
            };

            await _context.student.AddAsync(student);
            await _context.SaveChangesAsync();

            var student_info = new Student_info()
            {
                student_id = student.id,
                country = studentDTO.country,
                adress = studentDTO.adress,
                grade = studentDTO.grade
            };
            await _context.student_info.AddAsync(student_info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getstudents", new { id = student.id }, studentDTO);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete_student(int id)
        {
            var student = _context.student.Find(id);
            var student_description = _context.student_info.SingleOrDefault(x => x.student_id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(student);
                _context.Remove(student_description);
                await _context.SaveChangesAsync();
                return student;
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update_students(int id, StudentDTO student)
        {
            if (id != student.student_id || !studentExists(id))
            {
                return BadRequest();
            }
            else
            {
                var students = _context.student.SingleOrDefault(x => x.id == id);
                var students_info = _context.student_info.SingleOrDefault(x => x.student_id == id);
                students.id = student.student_id;
                students.age = student.age;
                students.firstName = student.firstName;
                students.lastName = student.lastName;
                students_info.country = student.country;
                students_info.grade = student.grade;
                students_info.adress = student.adress;
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        private bool studentExists(int id)
        {
            return _context.student.Any(x => x.id == id);
        }
    }
}

