using Data;
using Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class BookmarkService : IBookmarkService
    {
        private ReadLaterDataContext _readLaterDataContext;

        public BookmarkService(ReadLaterDataContext readLaterDataContext)
        {
            _readLaterDataContext = readLaterDataContext;
        }

        public Bookmark CreateBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Add(bookmark);
            _readLaterDataContext.SaveChanges();
            
            return bookmark;
        }

        public List<Bookmark> GetBookmarks(string userId)
        {
            return _readLaterDataContext.Bookmark.Where(x=>x.UserId == userId).Include(x=>x.Category).ToList();
        }

        public Bookmark GetBookmarkById(int id, string userId)
        {
            return _readLaterDataContext.Bookmark.Include(x => x.Category).FirstOrDefault(x => x.ID == id && x.UserId == userId);
        }

        public void UpdateBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Update(bookmark);
            _readLaterDataContext.SaveChanges();
        }

        public void DeleteBookmark(Bookmark bookmark)
        {
            _readLaterDataContext.Bookmark.Remove(bookmark);
            _readLaterDataContext.SaveChanges();
        }
    }
}
