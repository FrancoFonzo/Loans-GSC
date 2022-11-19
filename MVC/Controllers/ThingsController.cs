using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.DataAccess;
using MVC.Dto;
using MVC.Entities;
using MVC.Models;

namespace MVC.Controllers
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

        // GET: Things
        public IActionResult Index()
        {
            var things = unitOfWork.ThingsRepository.GetAll();
            var thingsResponses = mapper.Map<IEnumerable<ThingViewModel>>(things);
            return View(thingsResponses);
        }

        // GET: Things/Details/5
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return NotFound("Thing not found");
            }

            var thing = unitOfWork.ThingsRepository.GetById(id.Value);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }

            var thingVModel = mapper.Map<ThingViewModel>(thing);
            return View(thingVModel);
        }

        // GET: Things/Create
        public IActionResult Create()
        {
            var categories = unitOfWork.CategoriesRepository.GetAll();
            ViewData["Categories"] = new SelectList(categories, "Id", "Description");
            return View();
        }

        // POST: Things/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateThingViewModel thingVModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = unitOfWork.CategoriesRepository.GetAll();
                ViewData["Categories"] = new SelectList(categories, "Id", "Description");
                return View(thingVModel);
            }

            var thing = mapper.Map<Thing>(thingVModel);
            unitOfWork.ThingsRepository.Create(thing);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Things/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound("Thing not found");
            }

            var thing = unitOfWork.ThingsRepository.GetById(id.Value);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }

            var thingVModel = mapper.Map<ThingViewModel>(thing);
            var categories = unitOfWork.CategoriesRepository.GetAll();
            ViewData["Categories"] = new SelectList(categories, "Id", "Description", thingVModel.Category);
            return View(thingVModel);
        }

        // POST: Things/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ThingViewModel thingVModel)
        {
            if (id != thingVModel.Id)
            {
                return NotFound("Thing not found");
            }

            if (!ModelState.IsValid)
            {
                var categories = unitOfWork.CategoriesRepository.GetAll();
                ViewData["Categories"] = new SelectList(categories, "Id", "Description", thingVModel.Category);
                return View(thingVModel);
            }

            var thing = mapper.Map<Thing>(thingVModel);
            unitOfWork.ThingsRepository.Update(thing);
            unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Things/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound("Thing not found");
            }

            var thing = unitOfWork.ThingsRepository.GetById(id.Value);
            if (thing is null)
            {
                return NotFound("Thing not found");
            }

            var thingVModel = mapper.Map<ThingViewModel>(thing);
            return View(thingVModel);
        }

        // POST: Things/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var thing = unitOfWork.ThingsRepository.GetById(id);
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
