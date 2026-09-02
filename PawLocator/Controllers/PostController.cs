using Microsoft.AspNetCore.Mvc;
using PawLocator.DTOs;
using PawLocator.Services;

namespace PawLocator.Controllers
{
    public class PostController : Controller
    {

        private readonly PostService postService;

        public PostController(PostService postService)
        {
            this.postService = postService;
        }
        // GET: PostController
        public async Task<ActionResult> Index()
        {
            var posts = await postService.GetAllAsync();

            return View("Index", posts);
        }

        // GET: PostController/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var post = await postService.GetByIdAsync(id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        // GET: PostController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

            // POST: PostController/Create
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.CreateAsync(model);

            return RedirectToAction("Index");
        }


        // GET: PostController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var post = await postService.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var post = await postService.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            await postService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
