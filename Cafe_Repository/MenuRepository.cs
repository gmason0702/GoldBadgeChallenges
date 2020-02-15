using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuRepository
    {
        protected readonly List<MenuItem> _menuRepo = new List<MenuItem>();
        protected readonly List<MenuItem> _ingredientDirectory = new List<MenuItem>();

        //Create
        public bool AddMenuItemToDirectory(MenuItem menuItem)
        {
            int directoryLength = _menuRepo.Count();
            _menuRepo.Add(menuItem);
            bool wasMenuItemAdded = directoryLength + 1 == _menuRepo.Count();
            return wasMenuItemAdded;
        }

        //Read
        public List<MenuItem> GetAllMenuItems()
        {
            return _menuRepo;
        }

        public MenuItem GetMenuItemsByName(string menuName)
        {
            foreach (MenuItem menuItem in _menuRepo)
            {
                if (menuItem.MealName.ToLower() == menuName.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }

        //Update
        public bool UpdateMenuItem(string originalMenuItem, MenuItem newMenuItem)
        {
            MenuItem oldMenuItem = GetMenuItemsByName(originalMenuItem);
            if (oldMenuItem!=null)
            {
                oldMenuItem.MealNumber = newMenuItem.MealNumber;
                oldMenuItem.MealName = newMenuItem.MealName;
                oldMenuItem.MealDescription = newMenuItem.MealDescription;
                oldMenuItem.MealIngredients = newMenuItem.MealIngredients;
                oldMenuItem.MealPrice = newMenuItem.MealPrice;
                return true;
            }
            return false;
        }
        public bool AddIngredients(MenuItem ingredient)
        {
            List<string> mealIngredients = new List<string> { };
            int ingredientDirectoryLength = _ingredientDirectory.Count();
            _ingredientDirectory.Add(ingredient);
            bool wasIngredientAdded = ingredientDirectoryLength + 1 == _ingredientDirectory.Count();
            return wasIngredientAdded;

        }
        //Delete
        public bool DeleteExistingMenuItem(string menuName)
        {
            MenuItem foundMenuItem = GetMenuItemsByName(menuName);
            bool deleteMenuItem = _menuRepo.Remove(foundMenuItem);
            return deleteMenuItem;
        }
    }
}
