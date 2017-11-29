using Admin_Service.Data;
using Admin_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Admin_Service.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffContext _context;

        public StaffController(StaffContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index(Staff staff)
        {
            return View(await _context.Staff.ToListAsync());
        }

        // GET: Staff/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);

            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staff/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffName,StaffSurname,StaffRole,")] Staff staff)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(staff);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //log the error(uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(staff);
        }

        // GET: Staff/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staff.SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var staffToUpdate = await _context.Staff.SingleOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Staff>(
                staffToUpdate,
                "",
                s => s.StaffName, s => s.StaffSurname, s => s.StaffRole, s => s.EditCardPermission,
                s => s.EditInvPermission, s => s.PurchasingPermission, s => s.ViewCustMsgPermission))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    //log the error(uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
            }

            return View(staffToUpdate);
        }

        // GET: Staff/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            var staff = await _context.Staff
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                     "Delete failed. Try again, and if the problem persists " +
                     "see your system administrator.";
            }

            return View(staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staff
                    .AsNoTracking()
        .SingleOrDefaultAsync(m => m.ID == id);
            if (staff == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }    

    }
}
