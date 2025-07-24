using Entity;
using System.Collections.Generic;

namespace Services
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);
        List<Category> GetCategories(string userId);
        Category GetCategory(int id, string userId);
        Category GetCategory(string name);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
