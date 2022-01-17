using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAuthors.Data
{
    public class Author
    {
        public int Id;
        public string FirstName;
        public string SecondName;
        public List<int> booksIds;

        public Author(int id, string firstName, string secondName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.booksIds = new List<int>();
        }
    }
}
