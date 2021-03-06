#pragma checksum "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\Pages\Authors.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d632afe14838780aca2d3009b90b34f846f85aaf"
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
#line 2 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\Pages\Authors.razor"
using BooksAuthors.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/authors")]
    public partial class Authors : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 87 "C:\Users\Krzyś\source\repos\BooksAuthors\BooksAuthors\Pages\Authors.razor"
       
    public string authorButtonText = "Add Author";
    public string? inputRate;
    public string? inputFirstName;
    public string? inputLastName;
    public DateTime inputReleaseDate;
    public Author currentlyEditedAuthor;
    public int currentlyAssignedAuthorId = -1;
    public int currentlyUnassignedAuthorId = -1;
    public void edit(Author author)
    {
        currentlyEditing = true;
        currentlyEditedAuthor = author;
        inputFirstName = currentlyEditedAuthor.FirstName;
        inputLastName = currentlyEditedAuthor.SecondName;

        authorButtonText = "Save Author";
    }
    public void delete(Author author)
    {
        DataService.unassignFromAllBooks(author);
        DataService.Authors.Remove(author);
    }
    public void showBooksAssign(Author author) {
        if (currentlyAssignedAuthorId != author.Id)
        {
            currentlyAssignedAuthorId = author.Id;
            currentlyUnassignedAuthorId = -1;
        } else
        {
            currentlyAssignedAuthorId = -1;
            currentlyUnassignedAuthorId = -1;
        }
    }

    public void showBooksUnassign(Author author)
    {
        if (currentlyUnassignedAuthorId != author.Id)
        {
            currentlyUnassignedAuthorId = author.Id;
            currentlyAssignedAuthorId = -1;
        }
        else
        {
            currentlyUnassignedAuthorId = -1;
            currentlyAssignedAuthorId = -1;
        }
    }

    public bool currentlyEditing = false;

    public void addAuthor()
    {
        if (inputFirstName != null && inputLastName != null)
        {
            if (inputLastName.Length > 0 && inputFirstName.Length > 0)
            {
                try
                {

                    if (currentlyEditing == false)
                    {
                        DataService.addAuthor(inputFirstName, inputLastName);
                        clearInputs();
                    }
                    else
                    {
                        currentlyEditedAuthor.FirstName = inputFirstName;
                        currentlyEditedAuthor.SecondName = inputLastName;
                        currentlyEditing = false;
                        authorButtonText = "Add Author";
                        clearInputs();
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
    public string showRating(Author author)
    {
        double rating = DataService.getAuthorRating(author);
        if (rating < 0)
        {
            return "No ratings yet";
        }
        else return rating.ToString();
    }
    public void clearInputs()
    {
        inputFirstName = "";
        inputLastName = "";

    }

    public void rate(Author author)
    {
        try
        {
            int rate = Convert.ToInt32(inputRate);
            if (rate >= 0 && rate <= 10)
            {
                DataService.rateAuthor(author, rate);
                inputRate = "";
            }
        }
        catch (Exception e) { }
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
