using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAuthors.Data
{
    public class BookRate:Rate
    {
        public int FkBook;

        public BookRate(int id, int value, int fkBook)
        {
            this.Id = id;
            this.Value = value;
            this.FkBook = fkBook;
            this.Date = DateTime.Today;
        }
    }
}
