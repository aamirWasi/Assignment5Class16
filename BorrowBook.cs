using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class BorrowBook
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Barcode { get; set; }
        public int BorrowCount { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        //public IList<Book> Book { get; set; }
        //public Student Student { get; set; }
    }
}
