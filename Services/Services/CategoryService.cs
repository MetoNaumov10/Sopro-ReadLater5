using Data;
using Entity;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ReadLaterDataContext _readLaterDataContext;
        public CategoryService(ReadLaterDataContext readLaterDataContext) 
        {
            _readLaterDataContext = readLaterDataContext;            
        }

        public Category CreateCategory(Category category)
        {
            _readLaterDataContext.Add(category);
            _readLaterDataContext.SaveChanges();
            return category;
        }

        public void UpdateCategory(Category category)
        {
            _readLaterDataContext.Update(category);
            _readLaterDataContext.SaveChanges();
        }

        public List<Category> GetCategories(string userId)
        {
            return _readLaterDataContext.Categories.Where(x=>x.UserId == userId).ToList();
        }

        public Category GetCategory(int id, string userId)
        {
            return _readLaterDataContext.Categories.FirstOrDefault(c => c.ID == id && c.UserId == userId);
        }

        public Category GetCategory(string name)
        {
            return _readLaterDataContext.Categories.FirstOrDefault(c => c.Name == name);
        }

        public void DeleteCategory(Category category)
        {
            _readLaterDataContext.Categories.Remove(category);
            _readLaterDataContext.SaveChanges();
        }
    }
}
