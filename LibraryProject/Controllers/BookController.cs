using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using LibraryManagement.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<Author> _authorRepository;
        private readonly IGenericRepository<LibraryBranch> _libraryBranchRepository;

        public BookController(IGenericRepository<Book> bookRepository,
                              IGenericRepository<Author> authorRepository,
                              IGenericRepository<LibraryBranch> libraryBranchRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _libraryBranchRepository = libraryBranchRepository;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAllAsync();
            return View(books.ToList());
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book vm)
        {
            if (ModelState.IsValid)
            {
                vm.CreatedAt = DateTime.UtcNow;
                _bookRepository.Add(vm);
                await _bookRepository.SaveAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View(vm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                book.UpdatedAt = DateTime.Now;
                _bookRepository.Update(book);
                await _bookRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View(book);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.GetByIdAsync(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View(book);
        }

        private async Task<SelectList> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();

            var authorItems = authors
                .Select(author => new
                {
                    Value = author.AuthorId,
                    Text = $"{author.FirstName} {author.LastName}"
                })
                .ToList();

            return new SelectList(authorItems, "Value", "Text");
        }
        private async Task<SelectList> GetLibraryAsync()
        {
            var branches = await _libraryBranchRepository.GetAllAsync();
            return new SelectList(branches, nameof(LibraryBranch.LibraryBranchId), nameof(LibraryBranch.BranchName));
        }
    }
}
