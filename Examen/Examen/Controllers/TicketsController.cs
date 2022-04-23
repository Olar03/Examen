using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen.Data;
using Examen.Data.Entities;
using Shooping.Helpers;
using Examen.Models;

namespace Examen.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ExamenContext _context;
        private readonly ICombosHelper _combosHelper;

        public TicketsController(ExamenContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets
                .Include(e => e.Entrance)
                .ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WasUsed,Document,Name,Date")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            EditTicketViewModel model = new()
            {

                Id = ticket.Id,
                WasUsed = ticket.WasUsed,
                Document = ticket.Document,
                Name = ticket.Name,
                Date = ticket.Date

            };
            return View(model);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ticket model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (id != model.Id)
            {
                return NotFound();
            }

            try
            {
                Ticket ticket = await _context.Tickets.FindAsync(model.Id);
                ticket.WasUsed = model.WasUsed;
                ticket.Document = model.Document;
                ticket.Name = model.Name;
                ticket.Date = model.Date;
                _context.Update(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    ModelState.AddModelError(string.Empty, "Ya existe un ticket con el mismo nombre.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                ModelState.AddModelError(string.Empty, exception.Message);
            }

            return View(model);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }


        //public async Task<IActionResult> AddEntrance(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Ticket ticket = await _context.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    AddEntranceTikectViewModel model = new()
        //    {
        //        TicketId = ticket.Id,
        //        Entrance = await _combosHelper.GetComboEntrancesAsync(),
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddCategory(AddEntranceTikectViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Ticket ticket = await _context.Tickets.FindAsync(model.TicketId);
        //        EntranceTickets entranceTickets = new()
        //        {
        //            Entrance = await _context.Entrances.FindAsync(model.EntranceId),
        //            Vehicle = ticket,
        //        };

        //        try
        //        {
        //            _context.Add(vehicleCategory);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Details), new { Id = ticket.Id });
        //        }
        //        catch (Exception exception)
        //        {
        //            ModelState.AddModelError(string.Empty, exception.Message);
        //        }
        //    }

        //    return View(model);
        //}

    }
}
