using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public interface IBookRepository
    {
        ICollection<Book> GetAll();
        Book InsertABook(Book book);
        Book GetById(int id);
        void DeleteBookRow(int id);
        void UpdateBookDetails(Book book);
    }
}
