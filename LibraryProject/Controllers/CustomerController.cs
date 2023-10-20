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

        public async Task<IActionResult> Index()
        {
            var customers = await _repo.GetAllAsync();
            var customerViewModels = customers.Select(customer => new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                LastName = customer.LastName, 
                FirstName = customer.FirstName,
                Birthday = customer.Birthday,
                Student = customer.Student,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                MembershipSince = customer.MembershipSince
            }).ToList();

            return View(customerViewModels);
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
                    CreatedAt = viewModel.CreatedAt
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
                UpdatedAt = customer.UpdatedAt
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
                    UpdatedAt = viewModel.UpdatedAt
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
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };

            return View(viewModel);
        }
    }
}
