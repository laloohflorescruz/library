using BlogApp;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CustomerController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var vm = _dbContext.Customer.ToList();
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer vm)
        {
            vm.CreatedAt = DateTime.Now;
            _dbContext.Customer.Add(vm);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _dbContext.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        // POST: Customer/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                customer.UpdatedAt = DateTime.Now;
                _dbContext.Update(customer);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customer/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _dbContext.Customer
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
    }
}