using LibraryManagement.Models;
using LibraryManagement.Repo;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IGenericRepository<Book> _bookRepository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IGenericRepository<Book> bookRepository, ILogger<HomeController> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var books = _bookRepository.GetAllAsync();
        return View(books);
    }

    public async Task<IActionResult> Search(string searchBook)
    {
        var books = await _bookRepository.GetAllAsync();
        if (!string.IsNullOrEmpty(searchBook))
        {
            books = books.Where(s => s.Title.Contains(searchBook)).ToList();
        }
        return View("SearchResults", books);
    }
}