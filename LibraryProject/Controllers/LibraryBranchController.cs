using LibraryManagement.Models;
using LibraryManagement.Repo;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class LibraryBranchController : Controller
    {
        private readonly IGenericRepository<LibraryBranch> _libRep;

        public LibraryBranchController(IGenericRepository<LibraryBranch> libRep)
        {
            _libRep = libRep;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _libRep.GetAllAsync();
            return View(vm.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LibraryBranch vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            vm.CreatedAt = DateTime.Now;
            _libRep.Add(vm);
            await _libRep.SaveAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBranch = await _libRep.GetByIdAsync(id.Value);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            return View(libraryBranch);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, LibraryBranch libraryBranch)
        {
            if (id != libraryBranch.LibraryBranchId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            libraryBranch.UpdatedAt = DateTime.Now;
            _libRep.Update(libraryBranch);
            await _libRep.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryBranch = await _libRep.GetByIdAsync(id.Value);
            if (libraryBranch == null)
            {
                return NotFound();
            }

            return View(libraryBranch);
        }
    }
}
