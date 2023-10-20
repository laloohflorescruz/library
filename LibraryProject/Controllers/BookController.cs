using LibraryManagement.Models;
using LibraryManagement.Repo;
using LibraryManagement.ViewModel;
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
            var bookViewModels = books.Select(book => new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate,
                Genre = book.Genre,
                AuthorId = book.AuthorId,
                LibraryBranchId = book.LibraryBranchId
            }).ToList();

            return View(bookViewModels);
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = vm.Title,
                    ISBN = vm.ISBN,
                    PublicationDate = vm.PublicationDate,
                    Genre = vm.Genre,
                    AuthorId = vm.AuthorId,
                    LibraryBranchId = vm.LibraryBranchId,
                    CreatedAt = DateTime.UtcNow
                };

                _bookRepository.Add(book);
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

            var bookViewModel = new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate,
                Genre = book.Genre,
                AuthorId = book.AuthorId,
                LibraryBranchId = book.LibraryBranchId,
                UpdatedAt = book.UpdatedAt
            };

            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View(bookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookViewModel vm)
        {
            if (id != vm.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    BookId = vm.BookId,
                    Title = vm.Title,
                    ISBN = vm.ISBN,
                    PublicationDate = vm.PublicationDate,
                    Genre = vm.Genre,
                    AuthorId = vm.AuthorId,
                    LibraryBranchId = vm.LibraryBranchId,
                    UpdatedAt = DateTime.Now
                };

                _bookRepository.Update(book);
                await _bookRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View(vm);
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

            var bookViewModel = new BookViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate,
                Genre = book.Genre,
                AuthorId = book.AuthorId,
                LibraryBranchId = book.LibraryBranchId,
                CreatedAt = book.CreatedAt,
                UpdatedAt = book.UpdatedAt
            };

            ViewBag.AuthorItems = await GetAuthorsAsync();
            ViewBag.LibraryItems = await GetLibraryAsync();
            return View(bookViewModel);
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
