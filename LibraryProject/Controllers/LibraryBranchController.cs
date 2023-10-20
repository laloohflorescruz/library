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
            var branches = await _libRep.GetAllAsync();
            var branchViewModels = branches.Select(branch => new LibraryBranchViewModel
            {
                LibraryBranchId = branch.LibraryBranchId,
                BranchName = branch.BranchName,
                ZipCode = branch.ZipCode,
                Address = branch.Address,
                Phone = branch.Phone,
                City = branch.City,
                Email = branch.Email,
                OpeningHours = branch.OpeningHours,


            }).ToList();

            return View(branchViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LibraryBranchViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var branch = new LibraryBranch
                {
                    BranchName = viewModel.BranchName,
                    ZipCode = viewModel.ZipCode,
                    Address = viewModel.Address,
                    Phone = viewModel.Phone,
                    City = viewModel.City,
                    Email = viewModel.Email,
                    OpeningHours = viewModel.OpeningHours,
                    CreatedAt = DateTime.Now
                };

                _libRep.Add(branch);
                await _libRep.SaveAsync();

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _libRep.GetByIdAsync(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            var viewModel = new LibraryBranchViewModel
            {
                LibraryBranchId = branch.LibraryBranchId,
                BranchName = branch.BranchName,
                ZipCode = branch.ZipCode,
                Address = branch.Address,
                Phone = branch.Phone,
                City = branch.City,
                Email = branch.Email,
                OpeningHours = branch.OpeningHours,
                UpdatedAt = DateTime.Now
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, LibraryBranchViewModel viewModel)
        {
            if (id != viewModel.LibraryBranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var branch = new LibraryBranch
                {
                    LibraryBranchId = viewModel.LibraryBranchId,
                    BranchName = viewModel.BranchName,
                    ZipCode = viewModel.ZipCode,
                    Address = viewModel.Address,
                    Phone = viewModel.Phone,
                    City = viewModel.City,
                    Email = viewModel.Email,
                    OpeningHours = viewModel.OpeningHours,
                    UpdatedAt = DateTime.Now
                };

                _libRep.Update(branch);
                await _libRep.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _libRep.GetByIdAsync(id.Value);
            if (branch == null)
            {
                return NotFound();
            }

            var viewModel = new LibraryBranchViewModel
            {
                LibraryBranchId = branch.LibraryBranchId,
                BranchName = branch.BranchName,

                ZipCode = branch.ZipCode,
                Address = branch.Address,
                Phone = branch.Phone,
                City = branch.City,
                Email = branch.Email,
                OpeningHours = branch.OpeningHours,
                CreatedAt = branch.CreatedAt,
                UpdatedAt = branch.UpdatedAt

            };

            return View(viewModel);
        }
    }
}
