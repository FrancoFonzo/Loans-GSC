using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LoansAPI.DataAccess;
using LoansAPI.Entities;
using LoansAPI.Models;

namespace LoansAPI.Controllers
{
    public class ThingsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ThingsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var things = unitOfWork.ThingsRepository.GetAllWithCategory();
            var thingsResponses = mapper.Map<IEnumerable<ThingViewModel>>(things);
            return View(thingsResponses);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound("Thing not found");
            }

            var thing = unitOfWork.ThingsRepository.GetByIdWithCategory(id.Value);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }

            var thingVModel = mapper.Map<ThingViewModel>(thing);
            return View(thingVModel);
        }

        public IActionResult Create()
        {
            var categories = unitOfWork.CategoriesRepository.GetAll();
            ViewData["Categories"] = new SelectList(categories, "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateThingViewModel thingVModel)
        {
            if (!ModelState.IsValid)
            {
                return View(thingVModel);
            }

            var category = unitOfWork.CategoriesRepository.GetById(thingVModel.CategoryId);
            if (category is null)
            {
                ModelState.AddModelError("CategoryId", "Category not found");
                return View(thingVModel);
            }

            var thing = mapper.Map<Thing>(thingVModel);
            unitOfWork.ThingsRepository.Create(thing);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound("Thing not found");
            }

            var thing = unitOfWork.ThingsRepository.GetByIdWithCategory(id.Value);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }
            
            var categories = unitOfWork.CategoriesRepository.GetAll();
            var thingVModel = mapper.Map<CreateThingViewModel>(thing);
            ViewData["Categories"] = new SelectList(categories, "Id", "Description", thingVModel.CategoryId);
            return View(thingVModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateThingViewModel thingVModel)
        {
            var thing = unitOfWork.ThingsRepository.GetByIdWithCategory(id);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }

            if (!ModelState.IsValid)
            {
                var categories = unitOfWork.CategoriesRepository.GetAll();
                ViewData["Categories"] = new SelectList(categories, "Id", "Description", thingVModel.CategoryId);
                return View(thingVModel);
            }
            var thingToSave = mapper.Map<CreateThingViewModel, Thing>(thingVModel, thing);
            unitOfWork.ThingsRepository.Update(thingToSave);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound("Thing not found");
            }

            var thing = unitOfWork.ThingsRepository.GetByIdWithCategory(id.Value);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }

            var thingVModel = mapper.Map<ThingViewModel>(thing);
            return View(thingVModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var thing = unitOfWork.ThingsRepository.GetByIdWithCategory(id);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }

            unitOfWork.ThingsRepository.Delete(thing.Id);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
