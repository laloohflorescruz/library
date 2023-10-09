using BlogApp;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Controllers;

public class AuthorController : Controller
{
    private readonly AppDbContext _dbContext;

    public AuthorController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        var posts = _dbContext.Author.ToList();
        return View(posts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Author vm)
    {
        vm.CreatedAt = DateTime.Now;
        _dbContext.Author.Add(vm);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    // GET: Author/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _dbContext.Author.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }

    // POST: Author/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Author author)
    {
        if (id != author.AuthorId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            author.UpdatedAt = DateTime.Now;
            _dbContext.Update(author);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        return View(author);
    }

    // GET: Author/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = await _dbContext.Author
            .FirstOrDefaultAsync(m => m.AuthorId == id);
        if (author == null)
        {
            return NotFound();
        }

        return View(author);
    }
}

