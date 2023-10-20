using LibraryManagement.Models;
using LibraryManagement.Repo;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

public class HomeController : Controller
{
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IGenericRepository<Book> bookRepository, ILogger<HomeController> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _bookRepository.GetAllAsync();
        var bookViewModels = books.Select(book => new BookViewModel
        {
            BookId = book.BookId,
            Title = book.Title,
            AuthorId = book.AuthorId,
            Genre = book.Genre,
        }).ToList();

        return View(bookViewModels);
    }

    public async Task<IActionResult> Search(string searchBook)
    {
        var books = await _bookRepository.GetAllAsync();
        if (!string.IsNullOrEmpty(searchBook))
        {
            books = books.Where(s => s.Title.Contains(searchBook)).ToList();
        }

        var bookViewModels = books.Select(book => new BookViewModel
        {
            BookId = book.BookId,
            Title = book.Title,
            AuthorId = book.AuthorId,
            Genre = book.Genre,
        }).ToList();

        return View("SearchResults", bookViewModels);
    }
}
