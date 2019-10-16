using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5Class16
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            :base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
