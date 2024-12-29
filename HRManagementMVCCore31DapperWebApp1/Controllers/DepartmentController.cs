using HRManagementMVCCore31DapperWebApp1.Models;
using HRManagementMVCCore31DapperWebApp1.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRManagementMVCCore31DapperWebApp1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentRepository _repository;

        public DepartmentController(DepartmentRepository repository)
        {
            _repository = repository;
        }

        // GET: Department
        public async Task<IActionResult> Index()
        {
            var departments = await _repository.GetAllDepartmentsAsync();
            return View(departments);
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var department = await _repository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddDepartmentAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _repository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.UpdateDepartmentAsync(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _repository.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
