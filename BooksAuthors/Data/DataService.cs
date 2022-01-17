using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAuthors.Data
{
    public class DataService
    {
        public List<Author> Authors = new List<Author>();
        public List<Book> Books = new List<Book>();
        public List<AuthorRate> AuthorRates = new List<AuthorRate>();
        public List<BookRate> BookRates = new List<BookRate>();
        private int highestAuthorId = 0;
        private int highestBookId = 0;
        private int highestBookRateId = 0;
        private int highestAuthorRateId = 0;

        public double getBookRating(Book book)
        {
            int counter = 0;
            double rating = -1;
            foreach (BookRate bookRate in BookRates)
            {
                if (bookRate.FkBook == book.Id)
                {
                    if (rating == -1)
                    {
                        rating = 0;
                    }
                    counter++;
                    rating += bookRate.Value;
                }
            }
            if (rating > 0)
            {
                rating = rating / counter;
            }
            return rating;
        }

        public double getAuthorRating(Author author)
        {
            int counter = 0;
            double rating = -1;
            foreach(AuthorRate authorRate in AuthorRates)
            {
                if(authorRate.FkAuthor == author.Id)
                {
                    if(rating == -1)
                    {
                        rating = 0;
                    }
                    counter++;
                    rating += authorRate.Value;
                }
            }
            if (rating > 0)
            {
                rating = rating / counter;
            }
            return rating;
        }
        public string getAuthors(Book book)
        {
            string authors = "";
            foreach (Author author in Authors)
            {
                if (book.AuthorsIds.Contains(author.Id))
                {
                    authors += author.FirstName + " " + author.SecondName + ", ";
                }
            }
            return authors;
        }      

        public string getBooks(Author author)
        {
            string books = "";
            int counter = 0;
            foreach(Book book in Books)
            {
                if (author.booksIds.Contains(book.Id)){
                    books += book.Title + ", ";
                    counter++;
                }
            }
            if (counter >= 3)
            {
                return "Number of books: " + counter;
            }
            else
            {
                return books;
            }
        }

        public void addBook(string title, DateTime releaseDate)
        {
            highestBookId++;
            Books.Add(new Book(highestBookId, title, releaseDate));
        }

        public void rateBook(Book book, int rate)
        { 
            highestBookRateId++;
            BookRates.Add(new BookRate(highestBookRateId, rate, book.Id));
        }

        public void assign(Book book, Author author)
        {
            book.AuthorsIds.Add(author.Id);
            author.booksIds.Add(book.Id);
        }
        public void unassign(Book book, Author author)
        {
            book.AuthorsIds.Remove(author.Id);
            author.booksIds.Remove(book.Id);
        }

        public void addAuthor(string firstName, string secondName)
        {
            highestAuthorId++;
            Authors.Add(new Author(highestAuthorId, firstName, secondName));
        }

        public void rateAuthor(Author author, int rate)
        {
            highestAuthorRateId++;
            AuthorRates.Add(new AuthorRate(highestAuthorRateId, rate, author.Id));
        }

        public void unassignFromAllAuthors(Book book)
        {
            foreach(Author author in Authors)
            {
                if (author.booksIds.Contains(book.Id)){
                    author.booksIds.Remove(book.Id);
                }
            }
        }
        public void unassignFromAllBooks(Author author)
        {
            foreach(Book book in Books)
            {
                if (book.AuthorsIds.Contains(author.Id))
                {
                    book.AuthorsIds.Remove(author.Id);
                }
            }
        }
    }
}
