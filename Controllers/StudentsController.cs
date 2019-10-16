using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment5Class16;

namespace Assignment5Class16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _context;

        public StudentsController(IStudentsService context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _context.Get();
        }

        //GET: api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _context.GetId(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        //// PUT: api/Students/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            //_context.Entry(student).State = EntityState.Modified;
            var note = _context.GetId(id);


            if (note == null)
            {
                return NotFound();
            }


            student.StudentId = id;
            _context.Update(student);

            return NoContent();
        }

            // POST: api/Students
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Student> PostStudent(Student student)
        {
            _context.Add(student);

            return CreatedAtRoute("GetStudent", new { id = student.StudentId }, student);
        }

        //// DELETE: api/Students/5
        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudent(int id)
        {
            var student = _context.GetId(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Delete(id);

            return student;
        }
        //[HttpGet("{id:int}/GetBorrowBooks")]
        //public ActionResult<IList<Book>> GetBorrowBooks(int id)
        //{
        //    var borrows = _context.GetId(id);
        //    if (borrows == null)
        //        return BadRequest();
        //    return Ok(borrows);
        //}

        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(e => e.StudentId == id);
        //}
    }
}
