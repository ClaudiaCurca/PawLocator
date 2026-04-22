using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using PawLocator.Data;
using PawLocator.DTOs;
using PawLocator.Repository;
using PawLocator.Services;

namespace PawLocator.Controllers
{
    public class UpdateController : Controller
    {
        private readonly UpdateService updateService;
        private readonly UpdateRepository updateRepository;

        public UpdateController(ApplicationDbContext context)
        {
            updateRepository = new UpdateRepository(context);
            updateService = new UpdateService(updateRepository);
 
        }
        // GET: UpdateController
        public async Task<ActionResult> Index()
        {
            var updates = await updateService.GetAllAsync();

            return View("Index", updates);
        }

        // GET: UpdateController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UpdateController/Create
        public ActionResult Create()
        {
            return View("Create");
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

            return RedirectToAction("Index");
        }

        // GET: UpdateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UpdateController/Edit/5
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

        // GET: UpdateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UpdateController/Delete/5
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
