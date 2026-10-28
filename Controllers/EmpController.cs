using EFCore_CodeFirst_AsynchronousRequest_AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst_AsynchronousRequest_AspNetCore.Controllers
{
    public class EmpController : Controller
    {
        EmpContext db;
        public EmpController(EmpContext db)
        {
            this.db = db;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmpModel obj)
        {
            await db.Employee.AddAsync(obj);
            await db.SaveChangesAsync();
            return RedirectToAction("Read");
        }
        public async Task<IActionResult> Read()
        {
            var data = await db.Employee.ToListAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var data = await (db.Employee.Where(x => x.Id == id).SingleOrDefaultAsync());
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, EmpModel obj)
        {
            var data = await (db.Employee.FirstOrDefaultAsync(x => x.Id == id));
            if (data != null)
            {
                data.Name = obj.Name;
                data.City = obj.City;
                data.Address = obj.Address;
                await db.SaveChangesAsync();
                return RedirectToAction("Read");
            }
            else
                return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var data = await (db.Employee.FirstOrDefaultAsync(x => x.Id == id));
            if (data != null)
            {
                db.Employee.Remove(data);
                await db.SaveChangesAsync();
                return RedirectToAction("Read");
            }
            else
                return View();
        }
    }
}
