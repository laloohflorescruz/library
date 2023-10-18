using LibraryManagement;
using LibraryManagement.Models;
using LibraryManagement.Repo;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers;

public class AuthorController : Controller
{
    private readonly IGenericRepository<Author> _authorRep;
    public AuthorController(IGenericRepository<Author> authorRep)
    {
        _authorRep = authorRep;
    }

    public IActionResult Index()
    {
        var vm = _authorRep.GetAllAsync().Result;
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
            return BadRequest(ModelState.GetErrorMessages());
        }
        else
        {
            vm.CreatedAt = DateTime.Now;
            _authorRep.Add(vm);
            _authorRep.SaveAsync();

            return RedirectToAction("Index");
        }
    }


    // GET: Author/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = _authorRep.GetByIdAsync(id.Value);
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
        _authorRep.Update(author);
        _authorRep.SaveAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: Author/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var author = _authorRep.GetByIdAsync(id.Value);
        if (author == null)
        {
            return NotFound();
        }

        return View(author);
    }
}
