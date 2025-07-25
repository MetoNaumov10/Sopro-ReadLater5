﻿using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System.Security.Claims;

namespace ReadLater5.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Categories
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Category> model = _categoryService.GetCategories(userId);
            return View(model);
        }

        // GET: Categories/Details/5
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Category category = _categoryService.GetCategory((int)id, userId);

            if (category == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }

            return View(category);

        }

        // GET: Categories/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                category.UserId = userId;

                _categoryService.CreateCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Category category = _categoryService.GetCategory((int)id, userId);

            if (category == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }

            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                category.UserId = userId;
                _categoryService.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Category category = _categoryService.GetCategory((int)id, userId);

            if (category == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Category category = _categoryService.GetCategory(id, userId);
            _categoryService.DeleteCategory(category);

            return RedirectToAction("Index");
        }
    }
}
