using System.Collections.Generic;
using Hawk_products_display.Model;

namespace Hawk_products_display.Service.DataAccess.Interface
{
    public interface ICategoryDao
    {
         List<Category> GetCategories();
        int GetCategoryId(string categoryResourceName);
        string GetCategoryName(int categoryResourceId);
    }
}