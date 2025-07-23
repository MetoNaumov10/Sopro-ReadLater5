using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace ReadLater5.Controllers
{
    public class BookmarksController : Controller
    {
        private ICategoryService _categoryService;
        private IBookmarkService _bookmarkService;

        public BookmarksController(CategoryService categoryService, BookmarkService bookmarkService)
        {
            _categoryService = categoryService;
            _bookmarkService = bookmarkService;
        }

        // GET: Bookmarks
        public IActionResult Index()
        {
            List<Bookmark> model = _bookmarkService.GetBookmarks();
            return View(model);
        }

        // GET: Bookmarks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }

            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction("Index");
            }

            return View(bookmark);
        }

        // GET: Bookmarks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        // GET: Bookmarks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            Bookmark bookmark = _bookmarkService.GetBookmarkById((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Bookmark bookmark = _bookmarkService.GetBookmarkById(id);
            _bookmarkService.DeleteBookmark(bookmark);
            return RedirectToAction("Index");
        }
    }
}
