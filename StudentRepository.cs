using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class StudentRepository : IStudentRepository
    {
        private readonly LibraryContext _context;

        public StudentRepository(LibraryContext context)
        {
            _context = context;
        }

        public void DeleteStudentRow(int id)
        {
            var delete = GetById(id);
            _context.Students.Remove(delete);
            _context.SaveChanges();

        }

        public ICollection<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public Student InsertAStudent(Student student)
        {
            var insert = _context.Students.Add(student);
            _context.SaveChanges();
            student.StudentId = insert.Entity.StudentId;
            return student;
        }
    }
}
