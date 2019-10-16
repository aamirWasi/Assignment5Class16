using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class BookService:IBookService
    {
        private readonly IBookRepository _context;

        public BookService(IBookRepository context)
        {
            _context = context;
        }

        public Book Add(Book book)
        {
            return _context.InsertABook(book);
        }

        public void Delete(int id)
        {
            _context.DeleteBookRow(id);
        }

        public ICollection<Book> Get()
        {
            return _context.GetAll();
        }

        public Book GetId(int id)
        {
            return _context.GetById(id);
        }

        public void Update(Book book)
        {
            _context.UpdateBookDetails(book);
        }
    }
}
