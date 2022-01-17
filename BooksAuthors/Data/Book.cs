using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAuthors.Data
{
    public class Book
    {
        public int Id;
        public string Title;
        public DateTime ReleaseDate;
        public List<int> AuthorsIds;

        public Book(int id, string title, DateTime releaseDate)
        {
            this.Id = id;
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.AuthorsIds = new List<int>();
        }
    }


}
