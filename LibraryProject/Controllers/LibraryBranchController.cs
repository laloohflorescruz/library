using System.Diagnostics;
using BlogApp;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly AppDbContext _dbContext;

        public LibraryBranchController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var vm = _dbContext.LibraryBranch.ToList();
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LibraryBranch vm)
        {
            vm.CreatedAt = DateTime.Now;
            _dbContext.LibraryBranch.Add(vm);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: LibraryBranch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _dbContext.LibraryBranch.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }
            return View(library);
        }


        // POST: LibraryBranch/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, LibraryBranch library)
        {
            if (id != library.LibraryBranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                library.UpdatedAt = DateTime.Now;
                _dbContext.Update(library);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(library);
        }

        // GET: LibraryBranch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _dbContext.LibraryBranch
                .FirstOrDefaultAsync(m => m.LibraryBranchId == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }
    }
}