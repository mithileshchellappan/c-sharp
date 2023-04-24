using Forum4.Data;
using Forum4.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Forum4.Controllers
{
    [Authorize]
    public class ForumMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ForumMessagesController(ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet("{id}/ForumMessages")]
        public async Task< IActionResult> Index(int id)
        {
            var forumTopic = await _context.ForumTopics.Include(ft => ft.Messages).FirstOrDefaultAsync(ft => ft.Id == id);
            if (forumTopic == null)
            {
                return NotFound();
            }
            ViewData["ForumTopicId"] = id;
            return View(forumTopic);
        }

        [HttpGet("ForumMessages/Create")]
        public async Task<IActionResult> Create(int id)
        {
            var forumTopic = await _context.ForumTopics.Include(ft => ft.Messages).FirstOrDefaultAsync(ft => ft.Id == id);
            if (forumTopic == null)
            {
                return NotFound();
            }
            ViewData["ForumTopicId"] = id;
            return RedirectToAction("Index");
        }


        [HttpPost("ForumMessages/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,ForumMessage forumMessage)
        {
            Console.WriteLine("inside" + id + forumMessage.Message);
            if (!ModelState.IsValid)
            {
                
                forumMessage.CreatedDate = DateTime.Now;
                forumMessage.CreatedBy = _userManager.GetUserId(User);
                forumMessage.ForumTopicId = id;
                forumMessage.Id = 0;
                Console.WriteLine("valiue"+forumMessage.Id);
                _context.Add(forumMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = forumMessage.ForumTopicId });
            }
            var forumTopic = await _context.ForumTopics.Include(ft => ft.Messages).FirstOrDefaultAsync(ft => ft.Id == id);

            if(forumTopic == null)
            {
                return NotFound();
            }
            ViewData["ForumTopicId"] = id;
            return View("Index",forumTopic);
        }
    }
}
