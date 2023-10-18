using LibraryManagement;
using LibraryManagement.Models;
using LibraryManagement.Repo;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers;

public class AuthorController : Controller
{
    private readonly IGenericRepository<Author> _authorRepository;
    public AuthorController(IGenericRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public IActionResult Index()
    {
        var vm = _authorRepository.GetAllAsync().Result;
        return View(vm);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Author vm)
    {
        if (ModelState.IsValid)
        {
            vm.CreatedAt = DateTime.Now;
            _authorRepository.Add(vm);
            _authorRepository.SaveAsync();

            return RedirectToAction("Index");
        }
        return View(vm);

    }


    // GET: Author/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = _authorRepository.GetByIdAsync(id.Value).Result; // Note: Avoid using Result in production code, consider using async/await all the way.
        if (author == null)
        {
            return NotFound();
        }
        return View(author);
    }

    // POST: Author/Edit/5
    [HttpPost]
    public IActionResult Edit(int id, Author author)
    {
        if (id != author.AuthorId)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        author.UpdatedAt = DateTime.Now;
        _authorRepository.Update(author);
        _authorRepository.SaveAsync().Wait(); // Note: Avoid using Wait in production code, consider using async/await all the way.

        return RedirectToAction(nameof(Index));
    }

    // GET: Author/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = _authorRepository.GetByIdAsync(id.Value).Result; // Note: Avoid using Result in production code, consider using async/await all the way.

        if (author == null)
        {
            return NotFound();
        }

        return View(author);
    }
}
