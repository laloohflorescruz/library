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

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)//Defaul value to be shown on Index = 10
        {
            var branches = await _libRep.GetAllAsync();

            var totalItems = branches.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var branchViewModels = branches
                .Skip((page - 1) * pageSize)
                .Take(pageSize)//Values for pages = 10
                .Select(branch => new LibraryBranchViewModel
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
                }).ToList();

            var paginationInfo = new PaginationInfoViewModel
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };

            var viewModel = new LibraryBranchIndexViewModel
            {
                LibraryBranches = branchViewModels,
                PaginationInfo = paginationInfo
            };
            return View(viewModel);
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
                throw new ArgumentException("ID cannot be null or not found");
            }

            var branch = await _libRep.GetByIdAsync(id.Value);
            if (branch == null)
            {
                throw new ArgumentException($"Branch with ID {id} not found");
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
                UpdatedAt = DateTime.Now
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, LibraryBranchViewModel viewModel)
        {
              if (id == 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var branch = new LibraryBranch
                {
                    LibraryBranchId = id,
                    BranchName = viewModel.BranchName,
                    ZipCode = viewModel.ZipCode,
                    Address = viewModel.Address,
                    Phone = viewModel.Phone,
                    City = viewModel.City,
                    Email = viewModel.Email,
                    OpeningHours = viewModel.OpeningHours,
                    CreatedAt = viewModel.CreatedAt,
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
