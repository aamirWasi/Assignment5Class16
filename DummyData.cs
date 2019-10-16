using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryContext>();
                context.Database.EnsureCreated();
                if (context.BorrowBooks != null && context.BorrowBooks.Any())
                    return;
                var borrows = GetBorrows().ToList();
                context.BorrowBooks.AddRange(borrows);
                context.SaveChanges();


                var returns = GetReturns().ToList();
                context.ReturnBooks.AddRange(returns);
                context.SaveChanges();

                var students = GetStudents(context).ToList();
                context.Students.AddRange(students);
                context.SaveChanges();
            }
        }
        public static IList<BorrowBook> GetBorrows()
        {
            var borrows = new List<BorrowBook>()
            {
                new BorrowBook
                {
                     Barcode="5555",
                      BorrowCount=3,
                       BorrowDate=DateTime.UtcNow,
                        ReturnDate=DateTime.UtcNow.AddDays(7),
                         StudentId=1
                },
                new BorrowBook
                {
                     Barcode="6666",
                      BorrowCount=1,
                       BorrowDate=DateTime.UtcNow,
                        ReturnDate=DateTime.UtcNow.AddDays(7),
                         StudentId=1
                },
                new BorrowBook
                {
                     Barcode="7777",
                      BorrowCount=2,
                       BorrowDate=DateTime.UtcNow,
                        ReturnDate=DateTime.UtcNow.AddDays(7),
                         StudentId=1
                },
                new BorrowBook
                {
                     Barcode="8888",
                      BorrowCount=1,
                       BorrowDate=DateTime.UtcNow,
                        ReturnDate=DateTime.UtcNow.AddDays(7),
                         StudentId=1
                },
            };
            return borrows;
        }
        public static IList<ReturnBook> GetReturns()
        {
            var returns = new List<ReturnBook>()
            {
                new ReturnBook
                {
                     Barcode="5555",
                      BooksReturnDate=DateTime.UtcNow.AddDays(9),
                       StudentId=1
                },
                new ReturnBook
                {
                     Barcode="1111",
                      BooksReturnDate=DateTime.UtcNow.AddDays(3),
                       StudentId=1
                },
                new ReturnBook
                {
                     Barcode="7777",
                      BooksReturnDate=DateTime.UtcNow.AddDays(7),
                       StudentId=2
                },
            };
            return returns;
        }
        public static IList<Student> GetStudents(LibraryContext context)
        {
            var students = new List<Student>()
            {
                new Student
                {
                     Name = "rashed",
                      Borrows = new List<BorrowBook>(context.BorrowBooks.Take(3)),
                       ReturnBooks = new List<ReturnBook>(context.ReturnBooks.Skip(1).Take(3))
                },
                new Student
                {
                     Name = "aamirWasi",
                      Borrows = new List<BorrowBook>(context.BorrowBooks.Take(1)),
                       ReturnBooks = new List<ReturnBook>(context.ReturnBooks)
                },
            };
            return students;
        }
    }
}
