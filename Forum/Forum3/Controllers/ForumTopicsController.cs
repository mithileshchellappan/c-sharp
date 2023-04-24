using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum3.Data;
using Forum3.Models;

namespace Forum3.Controllers
{
    public class ForumTopicsController : Controller
    {
        private readonly Forum3Context _context;

        public ForumTopicsController(Forum3Context context)
        {
            _context = context;
        }

        // GET: ForumTopics
        public async Task<IActionResult> Index()
        {
            var forum3Context = _context.ForumTopic.Include(f => f.CreatedBy);
            return View(await forum3Context.ToListAsync());
        }

        // GET: ForumTopics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ForumTopic == null)
            {
                return NotFound();
            }

            var forumTopic = await _context.ForumTopic
                .Include(f => f.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumTopic == null)
            {
                return NotFound();
            }

            return View(forumTopic);
        }

        // GET: ForumTopics/Create
        public IActionResult Create()
        {
            ViewData["CreatedById"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id");
            return View();
        }

        // POST: ForumTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,CreatedDate,CreatedById")] ForumTopic forumTopic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forumTopic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedById"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", forumTopic.CreatedById);
            return View(forumTopic);
        }

        // GET: ForumTopics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ForumTopic == null)
            {
                return NotFound();
            }

            var forumTopic = await _context.ForumTopic.FindAsync(id);
            if (forumTopic == null)
            {
                return NotFound();
            }
            ViewData["CreatedById"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", forumTopic.CreatedById);
            return View(forumTopic);
        }

        // POST: ForumTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,CreatedDate,CreatedById")] ForumTopic forumTopic)
        {
            if (id != forumTopic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forumTopic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForumTopicExists(forumTopic.Id))
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
            ViewData["CreatedById"] = new SelectList(_context.Set<IdentityUser>(), "Id", "Id", forumTopic.CreatedById);
            return View(forumTopic);
        }

        // GET: ForumTopics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ForumTopic == null)
            {
                return NotFound();
            }

            var forumTopic = await _context.ForumTopic
                .Include(f => f.CreatedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forumTopic == null)
            {
                return NotFound();
            }

            return View(forumTopic);
        }

        // POST: ForumTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ForumTopic == null)
            {
                return Problem("Entity set 'Forum3Context.ForumTopic'  is null.");
            }
            var forumTopic = await _context.ForumTopic.FindAsync(id);
            if (forumTopic != null)
            {
                _context.ForumTopic.Remove(forumTopic);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForumTopicExists(int id)
        {
          return (_context.ForumTopic?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
