using HRManagementMVCCore31DapperWebApp1.Models;
using HRManagementMVCCore31DapperWebApp1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRManagementMVCCore31DapperWebApp1.Controllers
{
    public class SalaryController : Controller
    {
        private readonly SalaryRepository _repository;

        public SalaryController(SalaryRepository repository)
        {
            _repository = repository;
        }

        // GET: Salary
        public async Task<IActionResult> Index()
        {
            var salaries = await _repository.GetAllSalariesAsync();
            return View(salaries);
        }

        // GET: Salary/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var salary = await _repository.GetSalaryByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // GET: Salary/DetailsByEmployeeId/5
        public async Task<IActionResult> DetailsByEmployeeId(int id)
        {
            var salary = await _repository.GetSalaryByEmployeeIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // GET: Salary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salary/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Salary salary)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddSalaryAsync(salary);
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        // GET: Salary/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var salary = await _repository.GetSalaryByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salary/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Salary salary)
        {
            if (id != salary.SalaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.UpdateSalaryAsync(salary);
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        // GET: Salary/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var salary = await _repository.GetSalaryByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteSalaryAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Salary/DeleteByEmployeeId/5
        public async Task<IActionResult> DeleteByEmployeeId(int id)
        {
            var salary = await _repository.GetSalaryByIdAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salary/DeleteByEmployeeId/5
        [HttpPost, ActionName("DeleteByEmployeeId")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSalaryByEmployeeId(int id)
        {
            await _repository.DeleteSalaryByEmployeeIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
