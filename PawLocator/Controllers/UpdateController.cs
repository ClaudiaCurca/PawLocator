using Microsoft.AspNetCore.Mvc;
using PawLocator.DTOs;
using PawLocator.Services;

namespace PawLocator.Controllers
{
    public class UpdateController : Controller
    {
        private readonly UpdateService updateService;


        public UpdateController(UpdateService updateService)
        {
            this.updateService = updateService;

        }
        // GET: UpdateController
        public async Task<ActionResult> Index()
        {
            var updates = await updateService.GetAllAsync();

            return View("Index", updates);
        }

        // GET: UpdateController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var update = await updateService.GetByIdAsync(id);

            if (update == null)
            {
                return NotFound();
            }
            return View(update);
        }

        // GET: UpdateController/Create
        public ActionResult Create(Guid postId)
        {
            var model = new UpdateDto
            {
                PostId = postId
            };

            return View("Create", model);
        }

        // POST: UpdateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UpdateDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await updateService.CreateAsync(model);

            return RedirectToAction("Details", "Post", new { id = model.PostId });
        }

        // GET: UpdateController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var update = await updateService.GetByIdAsync(id);
            if (update == null)
            {
                return NotFound();
            }
            return View(update);
        }

        // POST: UpdateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var update = await updateService.GetByIdAsync(id);

            if (update == null)
            {
                return NotFound();
            }

            var postId = update.PostId;

            await updateService.DeleteAsync(id);

            return RedirectToAction(
                "Details",
                "Post",
                new { id = postId }
            );
        }
    }
}
