using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactASPCrud.Model;
using System.Collections.Generic;

namespace ReactASPCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _studentDBContext;

        public StudentController(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }

        [HttpPost]
        [Route("InsertStudent")]
        public async Task<IActionResult> InsertStudent(Student student)
        {
            _studentDBContext.Students.Add(student);
            await _studentDBContext.SaveChangesAsync();

            return Ok("Student inserted successfully");
        }


        [HttpGet]
        [Route("GetStudents")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            return await _studentDBContext.Students.ToListAsync();
           
        }

        [HttpGet]
        [Route("GetStudentById/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentDBContext.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                return NotFound(); // HTTP 404
            }

            return Ok(student);
        }


        [HttpGet]
        [Route("GetStudentByName/{name}")]
        public async Task<ActionResult<Student>> GetStudentByName(string name)
        {
            var student = await _studentDBContext.Students.FirstOrDefaultAsync(s => s.StName == name);

            if (student == null)
            {
                return NotFound(); // HTTP 404
            }

            return Ok(student);

        }
        private async Task<Student> GetId(int id)
        {
            return await _studentDBContext.Students.FirstOrDefaultAsync(s => s.Id == id);
        }
/*
        [HttpPatch]
        [Route("UpdateStudentName/{id}")]
        public async Task<IActionResult> UpdateStudentName(int id)
        {
            var student = await GetId(id);
            if (student == null)
            {
                return NotFound(); // HTTP 404
            }
           *//* student.StName = stname;
            student.course = course;*//*
            await _studentDBContext.SaveChangesAsync();
            return Ok("Student name updated successfully");
        }*/

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student objStudent)
        {
            _studentDBContext.Entry(objStudent).State = EntityState.Modified;
            await _studentDBContext.SaveChangesAsync();
            return objStudent;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await GetId(id);

            if (student == null)
            {
                return NotFound(); // HTTP 404
            }

            _studentDBContext.Students.Remove(student);
            await _studentDBContext.SaveChangesAsync();

            return Ok("Student deleted successfully");
        }

    }
}
