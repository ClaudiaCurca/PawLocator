using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawLocator.Data;
using PawLocator.Models;
using PawLocator.Repository;
using PawLocator.Services;

namespace PawLocator.Controllers
{
    public class PostController : Controller
    {

        private readonly PostService postService;
        private readonly PostRepository postRepository;

        public PostController(ApplicationDbContext context)
        {
            postRepository = new PostRepository(context);
            postService = new PostService(postRepository);
        }
        // GET: PostController
        public async Task<ActionResult> Index()
        {
            var posts = await postService.GetAllAsync();

            return View("Index", posts);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await postService.CreateAsync(model);

            return RedirectToAction("Index");
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
