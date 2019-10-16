using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class StudentRepository : IStudentRepository, IReportRepository
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
            return _context.Students
                .Include(b=>b.Borrows)
                .Include(r=>r.ReturnBooks)
                .ToList();
        }

        //public IList<Book> GetBorrowBooks(int id,string barcode)
        //{
        //    var b = _context.Books.Find(barcode);
        //    var s = _context.Students.Find(id);
        //    if (b.CountCopy > 0)
        //    {
        //        if (s.StudentId == id && b.Barcode == barcode)
        //        {
        //            _context.BorrowBooks.Add(new BorrowBook
        //            {
        //                 Barcode=barcode,
        //                  BorrowCount=3,
        //                    StudentId=id,
        //                     BorrowDate=DateTime.UtcNow,
        //                      ReturnDate=DateTime.UtcNow.AddDays(7),
        //                       Books = new List<Book>
        //                       {
        //                           new Book
        //                           {
        //                                Barcode=b.Barcode,
        //                                Author=b.Author,
        //                                 BookId=b.BookId,
        //                                  CountCopy=b.CountCopy,
        //                                   Edition=b.Edition,
        //                                    Title=b.Title
        //                           }
        //                       }
        //            });
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Quantity is greater than the available stocks");
        //    }

        //}

        public Student GetById(int id)
        {
            return _context.Students
                .Include(b => b.Borrows)
                .Include(r => r.ReturnBooks)
                .FirstOrDefault(s=>s.StudentId==id);
        }

        public Student InsertAStudent(Student student)
        {
            var insert = _context.Students.Add(student);
            _context.SaveChanges();
            student.StudentId = insert.Entity.StudentId;
            return student;
        }

        public double LateFee(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == id);
            //var student = _context.Students
            //    .Where(x => x.StudentId == bookReturn.StudentId)
            //    .FirstOrDefault();
            var bookIssue = _context.BorrowBooks.FirstOrDefault(b => b.StudentId == id);
            var bookReturn = _context.ReturnBooks.FirstOrDefault(b=>b.StudentId==id);
            //var bookReturn = DateTime.UtcNow.AddDays(10);

            /*
             var student = context.Students
                .Where(x => x.StudentId == bookReturn.StudentId)
                .FirstOrDefault();
            var bookIssue = context.BookIssues
                .Where(x => x.Barcode == bookReturn.Barcode)
                .FirstOrDefault();
            if (bookReturn.BookReturnDate > bookIssue.ReturnDate)
            {
                var timeSpan = bookReturn.BookReturnDate - bookIssue.ReturnDate;
                var days = timeSpan.Days;
                for (int i = 0; i < days; i++)
                {
                    student.FineAmount += 10;
                }
            }
             */
            if(bookIssue!=null && bookReturn != null)
            {
                var timeSpan = bookReturn.BooksReturnDate - bookIssue.ReturnDate;
                var days = timeSpan.Days;
                if (days > 0)
                {
                    for (int i = 0; i < days; i++)
                    {
                        student.FineAmount += 10;
                    }
                }
                else
                {
                    student.FineAmount = 0;
                }
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Not issue a single  book");
            }
            return student.FineAmount;
        }

        public void UpdateStudentDetails(Student student)
        {
            var update = GetById(student.StudentId);
            update.Name = student.Name;
            update.FineAmount = student.FineAmount;
            _context.Students.Update(update);
            _context.SaveChanges();
        }
    }
}
