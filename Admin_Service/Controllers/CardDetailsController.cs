using Admin_Service.Data;
using Admin_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Service.Controllers
{
    public class CardDetailsController : Controller
    {
        private readonly StaffContext _context;

        public CardDetailsController(StaffContext context)
        {
            _context = context;
        }

        // GET: CardDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardDetails.ToListAsync());
        }

        // GET: CardDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardDetails = await _context.CardDetails
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cardDetails == null)
            {
                return NotFound();
            }

            return View(cardDetails);
        }

        // GET: CardDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CardNum,ExpDate,CvsNum")] CardDetails cardDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardDetails);
        }

        // GET: CardDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardDetails = await _context.CardDetails.SingleOrDefaultAsync(m => m.ID == id);
            if (cardDetails == null)
            {
                return NotFound();
            }
            return View(cardDetails);
        }

        // POST: CardDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CardNum,ExpDate,CvsNum")] CardDetails cardDetails)
        {
            if (id != cardDetails.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardDetailsExists(cardDetails.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cardDetails);
        }

        // GET: CardDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardDetails = await _context.CardDetails
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cardDetails == null)
            {
                return NotFound();
            }

            return View(cardDetails);
        }

        // POST: CardDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardDetails = await _context.CardDetails.SingleOrDefaultAsync(m => m.ID == id);
            _context.CardDetails.Remove(cardDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardDetailsExists(int id)
        {
            return _context.CardDetails.Any(e => e.ID == id);
        }
    }
}
