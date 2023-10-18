using System;
using System.Threading.Tasks;
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
            var vm = await _repo.GetAllAsync();
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            vm.CreatedAt = DateTime.Now;
            _repo.Add(vm);
            await _repo.SaveAsync();

            return RedirectToAction("Index");
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

            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            customer.UpdatedAt = DateTime.Now;
            _repo.Update(customer);
            await _repo.SaveAsync();

            return RedirectToAction(nameof(Index));
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

            return View(customer);
        }
    }
}
