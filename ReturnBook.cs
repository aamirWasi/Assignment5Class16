using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class ReturnBook
    {
        [Key]
        public string Barcode { get; set; }
        public int StudentId { get; set; }
        public DateTime BooksReturnDate { get; set; }
    }
}
