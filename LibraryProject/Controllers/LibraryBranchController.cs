using System.Diagnostics;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers;
public class LibraryBranchController : Controller
{
    public IActionResult Details(int id)
    {

        LibraryBranch vm = new LibraryBranch
        {
            LibraryBranchId = 1,
            BranchName = "The Main Branch"
        };



        LibraryBranchViewModel viewModel = new LibraryBranchViewModel
        {
            LibraryBranchId = vm.LibraryBranchId,
            BranchName = vm.BranchName,
        };

        return View(viewModel);
    }
}