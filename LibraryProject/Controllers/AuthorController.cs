using BlogApp;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
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
        var vm = _dbContext.Author.ToList();
        return View(vm);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Author vm)
    {
        if (!ModelState.IsValid)
        {
            // If the model is not valid, return a BadRequest response with error messages with a dictionary
            return BadRequest(ModelState.GetErrorMessages());
        }
        else
        {
            vm.CreatedAt = DateTime.Now;
            _dbContext.Author.Add(vm);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
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
        if (!ModelState.IsValid)
        {
             return BadRequest(ModelState.GetErrorMessages());
        }
        else
        {
            author.UpdatedAt = DateTime.Now;
            _dbContext.Update(author);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
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

