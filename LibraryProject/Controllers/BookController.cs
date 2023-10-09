using BlogApp;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book vm)
    {
        vm.CreatedAt = DateTime.Now;
        _dbContext.Book.Add(vm);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    // GET: Book/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
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
        if (id != book.AuthorId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            book.UpdatedAt = DateTime.Now;
            _dbContext.Update(book);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    // GET: Book/Details/5

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _dbContext.Book
            .FirstOrDefaultAsync(m => m.AuthorId == id);
        if (author == null)
        {
            return NotFound();
        }

        return View(author);
    }
}
