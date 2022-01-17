using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAuthors.Data
{
    public class AuthorRate:Rate
    {
        public int FkAuthor;

        public AuthorRate(int id, int value, int fkAuthor)
        {
            this.Id = id;
            this.Value = value;
            this.FkAuthor = fkAuthor;
            this.Date = DateTime.Today;
        }
    }
}
