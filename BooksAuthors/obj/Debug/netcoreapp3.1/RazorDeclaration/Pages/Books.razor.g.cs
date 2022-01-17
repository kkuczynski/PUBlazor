#pragma checksum "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\Pages\Books.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c47aca02c984a4bc45d1525e1aff9a29f7723483"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BooksAuthors.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using BooksAuthors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\_Imports.razor"
using BooksAuthors.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\Pages\Books.razor"
using BooksAuthors.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/books")]
    public partial class Books : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 83 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\Pages\Books.razor"
       
    public string bookButtonText = "Add Book";
    public string? inputTitle;
    public DateTime inputReleaseDate;
    public string? inputDay;
    public string? inputMonth;
    public string? inputYear;
    public string? inputRate;
    public int currentlyAssignedBookId = -1;
    public int currentlyUnassignedBookId = -1;
    public void edit(Book book)
    {
        currentlyEditing = true;
        currentlyEditedBook = book;
        inputTitle = currentlyEditedBook.Title;
        inputDay = currentlyEditedBook.ReleaseDate.Day.ToString();
        inputMonth = currentlyEditedBook.ReleaseDate.Month.ToString();
        inputYear = currentlyEditedBook.ReleaseDate.Year.ToString();
        bookButtonText = "Save Book";
    }
    public void delete(Book book) {
        DataService.unassignFromAllAuthors(book);
        DataService.Books.Remove(book);
    }
    public void showAuthorsAssign(Book book) {
        if (currentlyAssignedBookId != book.Id)
        {
            currentlyAssignedBookId = book.Id;
            currentlyUnassignedBookId = -1;
        } else
        {
            currentlyAssignedBookId = -1;
            currentlyUnassignedBookId = -1;
        }
    }
    public void showAuthorsUnassign(Book book)
    {
        if (currentlyUnassignedBookId != book.Id)
        {
            currentlyUnassignedBookId = book.Id;
            currentlyAssignedBookId = -1;
        }
        else
        {
            currentlyUnassignedBookId = -1;
            currentlyAssignedBookId = -1;
        }
    }
    public Book currentlyEditedBook;
    public bool currentlyEditing = false;
    public void addBook()
    {
        if (inputTitle != null && inputDay != null && inputMonth != null && inputYear != null)
        {
            if (inputTitle.Length > 0)
            {
                try
                {
                    inputReleaseDate = new DateTime(Convert.ToInt32(inputYear), Convert.ToInt32(inputMonth), Convert.ToInt32(inputDay));
                    if (currentlyEditing == false)
                    {
                        DataService.addBook(inputTitle, inputReleaseDate);
                        clearInputs();
                    }
                    else
                    {
                        currentlyEditedBook.Title = inputTitle;
                        currentlyEditedBook.ReleaseDate = inputReleaseDate;
                        currentlyEditing = false;
                        bookButtonText = "Add Book";
                        clearInputs();
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
    public string showRating(Book book)
    {
        double rating = DataService.getBookRating(book);
        if (rating < 0)
        {
            return "No ratings yet";
        }
        else return rating.ToString();
    }
    public void clearInputs()
    {
        inputMonth = "";
        inputDay = "";
        inputTitle = "";
        inputYear = "";
    }

    public void rate(Book book)
    {
        try
        {
            int rate = Convert.ToInt32(inputRate);
            if (rate >= 0 && rate <= 10)
            {
                DataService.rateBook(book, rate);
                inputRate = "";
            }
        }catch(Exception e) { }
    }

    public void assignAuthor(Book book, Author author)
    {
        DataService.assign(book, author);
    }

    public void unassignAuthor(Book book, Author author)
    {
        DataService.unassign(book, author);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private DataService DataService { get; set; }
    }
}
#pragma warning restore 1591