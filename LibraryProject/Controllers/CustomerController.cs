using LibraryManagement.Models;
using LibraryManagement.Repo;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGenericRepository<Customer> _repo;

        public CustomerController(IGenericRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)//Defaul value to be shown on Index = 10
        {
            var customer = await _repo.GetAllAsync();

            var totalItems = customer.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var customerViewModels = customer
                .Skip((page - 1) * pageSize)
                .Take(pageSize)//Values for pages = 10
                .Select(customer => new CustomerViewModel
                {
                    CustomerId = customer.CustomerId,
                    LastName = customer.LastName,
                    FirstName = customer.FirstName,
                    Birthday = customer.Birthday,
                    Student = customer.Student,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    MembershipSince = customer.MembershipSince,
                    Genre = customer.Genre

                }).ToList();

            var paginationInfo = new PaginationInfoViewModel
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages
            };

            var viewModel = new CustomerIndexViewModel
            {
                Customer = customerViewModels,
                PaginationInfo = paginationInfo
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    CustomerId = viewModel.CustomerId,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Birthday = viewModel.Birthday,
                    Student = viewModel.Student,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Address = viewModel.Address,
                    MembershipSince = viewModel.MembershipSince,
                    Genre = viewModel.Genre,
                    CreatedAt = DateTime.Now
                };

                _repo.Add(customer);
                await _repo.SaveAsync();
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

            var customer = await _repo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Birthday = customer.Birthday,
                Student = customer.Student,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                MembershipSince = customer.MembershipSince,
                Genre = customer.Genre,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = DateTime.Now
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CustomerViewModel viewModel)
        {
            if (id != viewModel.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    CustomerId = viewModel.CustomerId,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Birthday = viewModel.Birthday,
                    Student = viewModel.Student,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Address = viewModel.Address,
                    MembershipSince = viewModel.MembershipSince,
                    Genre = viewModel.Genre,
                    CreatedAt = viewModel.CreatedAt,
                    UpdatedAt = DateTime.Now
                };

                _repo.Update(customer);
                await _repo.SaveAsync();
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

            var customer = await _repo.GetByIdAsync(id.Value);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Birthday = customer.Birthday,
                Student = customer.Student,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                MembershipSince = customer.MembershipSince,
                Genre = customer.Genre,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };

            return View(viewModel);
        }
    }
}
