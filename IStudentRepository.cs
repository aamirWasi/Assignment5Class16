using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public interface IStudentRepository
    {
        ICollection<Student> GetAll();
        Student InsertAStudent(Student student);
        Student GetById(int id);
        void DeleteStudentRow(int id);
    }
}
