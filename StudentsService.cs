﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentRepository _context;

        public StudentsService(IStudentRepository context)
        {
            _context = context;
        }

        public Student Add(Student student)
        {
            return _context.InsertAStudent(student);
        }

        public void Delete(int id)
        {
            _context.DeleteStudentRow(id);
        }

        public ICollection<Student> Get()
        {
            return _context.GetAll();
        }

        public Student GetId(int id)
        {
            return _context.GetById(id);
        }
    }
}
