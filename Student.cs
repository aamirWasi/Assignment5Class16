using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public double FineAmount { get; set; } = 0;
        public IList<BorrowBook> Borrows { get; set; }
        public IList<ReturnBook> ReturnBooks { get; set; }
    }
}
