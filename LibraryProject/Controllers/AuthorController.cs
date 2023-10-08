using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers;

public class AuthorController : Controller
    {
        public IActionResult Details(int id)
        {         

            Author author = new Author
            {
                AuthorId = 1,
                FirstName = "John The Author"
            };

           

            AuthorViewModel viewModel = new AuthorViewModel
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
            };

            return View(viewModel);
        }
    }