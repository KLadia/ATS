using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AtsWebsite.Models
{
    public class EventCopiesController : Controller
    {
        private readonly AtsWebsiteContext _context;

        public EventCopiesController(AtsWebsiteContext context)
        {
            _context = context;
        }

        // GET: EventCopies
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventCopy.ToListAsync());
        }

        // GET: EventCopies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCopy = await _context.EventCopy
                .SingleOrDefaultAsync(m => m.event_id == id);
            if (eventCopy == null)
            {
                return NotFound();
            }

            return View(eventCopy);
        }

        // GET: EventCopies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventCopies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("event_id,event_title,date,major,desc,notes,dress_code,off_campus,address,city,state,zipcode")] EventCopy eventCopy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventCopy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventCopy);
        }

        // GET: EventCopies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCopy = await _context.EventCopy.SingleOrDefaultAsync(m => m.event_id == id);
            if (eventCopy == null)
            {
                return NotFound();
            }
            return View(eventCopy);
        }

        // POST: EventCopies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("event_id,event_title,date,major,desc,notes,dress_code,off_campus,address,city,state,zipcode")] EventCopy eventCopy)
        {
            if (id != eventCopy.event_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventCopy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventCopyExists(eventCopy.event_id))
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
            return View(eventCopy);
        }

        // GET: EventCopies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCopy = await _context.EventCopy
                .SingleOrDefaultAsync(m => m.event_id == id);
            if (eventCopy == null)
            {
                return NotFound();
            }

            return View(eventCopy);
        }

        // POST: EventCopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventCopy = await _context.EventCopy.SingleOrDefaultAsync(m => m.event_id == id);
            _context.EventCopy.Remove(eventCopy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventCopyExists(int id)
        {
            return _context.EventCopy.Any(e => e.event_id == id);
        }
    }
}
