using System.Diagnostics;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
 

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Details(int id)
        {         

            Customer vm = new Customer
            {
                CustomerId = 1,
                FirstName = "John The Customer"
            };

           

            CustomerViewModel viewModel = new CustomerViewModel
            {
                CustomerId = vm.CustomerId,
                FirstName = vm.FirstName,
            };

            return View(viewModel);
        }
    }
}