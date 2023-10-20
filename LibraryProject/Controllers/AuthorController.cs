using LibraryManagement.Models;
using LibraryManagement.Repo;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IGenericRepository<Author> _authorRepository;

        public AuthorController(IGenericRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepository.GetAllAsync();
            var authorViewModels = authors.Select(author => new AuthorViewModel
            {
                AuthorId = author.AuthorId,
                LastName = author.LastName,
                FirstName = author.FirstName,
                BirthPlace = author.BirthPlace,
                NobelPrize = author.NobelPrize
            }).ToList();

            return View(authorViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    LastName = vm.LastName,
                    FirstName = vm.FirstName,
                    BirthPlace = vm.BirthPlace,
                    NobelPrize = vm.NobelPrize,
                    CreatedAt = DateTime.Now
                };
                _authorRepository.Add(author);
                await _authorRepository.SaveAsync();

                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _authorRepository.GetByIdAsync(id.Value);
            if (author == null)
            {
                return NotFound();
            }

            var authorViewModel = new AuthorViewModel
            {
                AuthorId = author.AuthorId,
                LastName = author.LastName,
                FirstName = author.FirstName,
                BirthPlace = author.BirthPlace,
                NobelPrize = author.NobelPrize,
                UpdatedAt = author.UpdatedAt
            };

            return View(authorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuthorViewModel vm)
        {
            if (id != vm.AuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var author = new Author
                {
                    AuthorId = vm.AuthorId,
                    LastName = vm.LastName,
                    FirstName = vm.FirstName,
                    BirthPlace = vm.BirthPlace,
                    NobelPrize = vm.NobelPrize,
                    UpdatedAt = DateTime.Now
                };

                _authorRepository.Update(author);
                await _authorRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(vm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _authorRepository.GetByIdAsync(id.Value);

            if (author == null)
            {
                return NotFound();
            }

            var authorViewModel = new AuthorViewModel
            {
                AuthorId = author.AuthorId,
                LastName = author.LastName,
                FirstName = author.FirstName,
                BirthPlace = author.BirthPlace,
                NobelPrize = author.NobelPrize,
                CreatedAt = author.CreatedAt,
                UpdatedAt = author.UpdatedAt

            };

            return View(authorViewModel);
        }
    }
}
