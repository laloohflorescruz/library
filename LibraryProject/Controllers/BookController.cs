using System.Diagnostics;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers;


public class BookController : Controller

{
    public IActionResult Details(int id)
    {
        Book book = new()
        {
            BookId = id,
            Title = "Sample Book",
            AuthorId = 1,
            LibraryBranchId = 1,
            author = new Author  
            {
                AuthorId = 1,
                FirstName = "John Doe"
            },
            Library = new LibraryBranch  
            {
                LibraryBranchId = 1,
                BranchName = "Main Branch"
            }
        };

        BookViewModel viewModel = new BookViewModel
        {
            BookId = book.BookId,
            Title = book.Title,
            BranchName = book.Library.BranchName  
        };

        return View(viewModel);
    }
}
 