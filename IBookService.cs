using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public interface IBookService
    {
        ICollection<Book> Get();
        Book Add(Book book);
        Book GetId(int id);
        void Delete(int id);
        void Update(Book book);
    }
}
