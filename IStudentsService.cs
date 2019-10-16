using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public interface IStudentsService
    {
        ICollection<Student> Get();
        Student Add(Student student);
        Student GetId(int id);
        void Delete(int id);
        void Update(Student student);
        //IList<Book> GetBorrows(int id);
    }
}
