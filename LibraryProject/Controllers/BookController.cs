using BlogApp;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Controllers;

public class BookController : Controller
{
    private readonly AppDbContext _dbContext;

    public BookController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var vm = _dbContext.Book.ToList();
        return View(vm);
    }

    public IActionResult Create()
    {
        ViewBag.AuthorItems = GetAuthors();
        ViewBag.LibraryItems = GetLibrary();

        return View();
    }

    [HttpPost]
    public IActionResult Create(Book vm)
    {
        if (!ModelState.IsValid)
        {
            // If the model is not valid, return a BadRequest response with error messages with a dictionary
            return BadRequest(ModelState.GetErrorMessages());
        }
        else
        {
            vm.CreatedAt = DateTime.UtcNow;
            _dbContext.Book.Add(vm);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    // GET: Book/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        ViewBag.AuthorItems = GetAuthors();
        ViewBag.LibraryItems = GetLibrary();

        if (id == null)
        {
            return NotFound();
        }

        var book = await _dbContext.Book.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }


    // POST: Book/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Book book)
    {
        if (id != book.BookId)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }
        else
        {
            book.UpdatedAt = DateTime.Now;
            _dbContext.Update(book);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

    // GET: Book/Details/5

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _dbContext.Book
            .FirstOrDefaultAsync(m => m.BookId == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    public IEnumerable<SelectListItem> GetAuthors()
    {
        List<Author> authors = _dbContext.Author.ToList();
        List<SelectListItem> authorItems = authors.Select(author => new SelectListItem
        {
            Value = author.AuthorId.ToString(),
            Text = author.FirstName + " " + author.LastName
        }).ToList();

        return authorItems;
    }

    public IEnumerable<SelectListItem> GetLibrary()
    {
        List<LibraryBranch> branch = _dbContext.LibraryBranch.ToList();
        List<SelectListItem> branches = branch.Select(branch => new SelectListItem
        {
            Value = branch.LibraryBranchId.ToString(),
            Text = branch.BranchName
        }).ToList();

        return branches;
    }
}