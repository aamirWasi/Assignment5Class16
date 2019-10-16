using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class BookRepository:IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public void DeleteBookRow(int id)
        {
            var delete = GetById(id);
            _context.Books.Remove(delete);
            _context.SaveChanges();

        }

        public ICollection<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book InsertABook(Book book)
        {
            var insert = _context.Books.Add(book);
            _context.SaveChanges();
            book.BookId = insert.Entity.BookId;
            return book;
        }


        public void UpdateBookDetails(Book book)
        {
            var update = GetById(book.BookId);
            update.Title = book.Title;
            update.Author = book.Author;
            update.Barcode = book.Barcode;
            update.CountCopy = book.CountCopy;
            update.Edition = book.Edition;
            _context.Books.Update(update);
            _context.SaveChanges();
        }
    }
}
