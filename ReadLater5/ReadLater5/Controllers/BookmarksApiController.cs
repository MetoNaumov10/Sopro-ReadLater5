using Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksApiController : ControllerBase
    {
        private IBookmarkService _bookmarkService;

        public BookmarksApiController(IBookmarkService bookmarkService) 
        { 
            _bookmarkService = bookmarkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookmarks = await Task.Run(() =>
                _bookmarkService.GetBookmarks(userId)
            );

            return Ok(bookmarks);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Bookmark bookmark)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bookmark.UserId = userId;
            bookmark.CreateDate = DateTime.Now;

            await Task.Run(() =>
                _bookmarkService.CreateBookmark(bookmark));

            return CreatedAtAction(nameof(GetAll), new { id = bookmark.ID }, bookmark);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Bookmark updated)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookmark = await Task.Run(() =>
                _bookmarkService.GetBookmarkById(id, userId));
            if (bookmark == null || bookmark.UserId != userId)
                return NotFound();

            bookmark.URL = updated.URL;
            bookmark.ShortDescription = updated.ShortDescription;
            bookmark.CategoryId = updated.CategoryId;

            await Task.Run(() =>
                _bookmarkService.UpdateBookmark(bookmark));

            return Ok(bookmark);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var bookmark = await Task.Run(() =>
                _bookmarkService.GetBookmarkById(id, userId));
            if (bookmark == null || bookmark.UserId != userId)
                return NotFound();

            await Task.Run(() =>
                _bookmarkService.DeleteBookmark(bookmark));

            return NoContent();
        }
    }
}
