using Data;
using Entity;
using System.Collections.Generic;
using System.Linq;

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

        public List<Bookmark> GetBookmarks()
        {
            return _readLaterDataContext.Bookmark.ToList();
        }

        public Bookmark GetBookmarkById(int id)
        {
            return _readLaterDataContext.Bookmark.FirstOrDefault(x => x.ID == id);
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
