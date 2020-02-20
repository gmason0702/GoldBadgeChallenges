using Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Cafe
{
    public class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Select an option number below: \n" +
                    "1.  Display all menu items\n" +
                    "2.  Add new menu item\n" +
                    "3.  Update menu item\n" +
                    "4.  Remove menu item\n" +
                    "5.  Exit");
                // Console.Clear();
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");

                switch (userInput)
                {
                    case "1":
                        DisplayAllMenuItems();
                        break;
                    case "2":
                        AddMenuItem();
                        break;
                    case "3":
                        UpdateMenu();
                        break;
                    case "4":
                        RemoveMenuItem();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void DisplayAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> menuDirectory = _menuRepo.GetAllMenuItems();
            foreach (MenuItem item in menuDirectory)
            {
                Console.WriteLine($"Menu item number:  {item.MealNumber}\n" +
                    $"Menu item name:  {item.MealName}\n" +
                    $"Menu item description:  {item.MealDescription}\n" +
                    $"Menu item ingredients:  " + (string.Join(", ", item.MealIngredients)) +
                    $"\nMenu item price:  {item.MealPrice}\n\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void AddMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            Console.WriteLine("Please enter the item number");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the menu item name");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Please enter the description of the menu item");
            newItem.MealDescription = Console.ReadLine();
            _menuRepo.AddIngredients(newItem);


            List<string> mealIngredients = new List<string> { };
            Console.WriteLine("Please add an ingredient to the list");
            mealIngredients.Add(Console.ReadLine());
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Would you like to add another ingredient? Enter yes or no");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "yes":
                        Console.WriteLine("Please enter the ingredient you would like to add");
                        mealIngredients.Add(Console.ReadLine());
                        
                        break;
                    case "no":
                        Console.WriteLine("Ingredient list added!");
                        newItem.MealIngredients = mealIngredients;
                        keepGoing = false;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Please enter the price of the menu item");
            newItem.MealPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Your new menu item has been added! Press any key to continue...");
            Console.ReadKey();
            _menuRepo.AddMenuItemToDirectory(newItem);
            
        }
        private void UpdateMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the menu item you would like to update");
            string nameInput = Console.ReadLine();
            MenuItem existingMenuContent = _menuRepo.GetMenuItemsByName(nameInput);

            if (existingMenuContent == null)
            {
                Console.WriteLine("Unfortunately that item name is not in the menu directory.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                MenuItem item = new MenuItem();
                Console.WriteLine($"Current menu number:  {existingMenuContent.MealNumber}\n" +
                    $"Please enter a new item number");
                item.MealNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"Current name: {existingMenuContent.MealName}\n" +
                    $"Please enter a new name: ");
                item.MealName = Console.ReadLine();

                Console.WriteLine($"Current description: {existingMenuContent.MealDescription}\n" +
                    $"Please enter a new description: ");
                item.MealDescription = Console.ReadLine();

                //needs work
                Console.WriteLine($"Current ingredient list:  " + (string.Join(", ", existingMenuContent.MealIngredients)) +
                 $"\nPlease enter a new ingredient list");
                List<string> mealIngredients = new List<string> { };
                Console.WriteLine("Please add an ingredient to the list");
                mealIngredients.Add(Console.ReadLine());
                bool keepGoing = true;
                while (keepGoing)
                {
                    Console.WriteLine("Would you like to add another ingredient? Enter yes or no");
                    string answer = Console.ReadLine();
                    switch (answer)
                    {
                        case "yes":
                            Console.WriteLine("Please enter the ingredient you would like to add");
                            mealIngredients.Add(Console.ReadLine());

                            break;
                        case "no":
                            Console.WriteLine("Ingredient list added!");
                            item.MealIngredients = mealIngredients;
                            keepGoing = false;
                            break;
                        default:
                            break;
                    }
                }

                Console.WriteLine($"Current menu item price:  {existingMenuContent.MealPrice}\n" +
                    $"Please enter the new price");
                item.MealPrice = Convert.ToDecimal(Console.ReadLine());
            }
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the menu item you would like to remove from the menu");
            string nameInput = Console.ReadLine();

            MenuItem existingMenuItem = _menuRepo.GetMenuItemsByName(nameInput);
            _menuRepo.DeleteExistingMenuItem(nameInput);

            Console.WriteLine("Your content has been deleted. Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            MenuItem hamburger = new MenuItem(1, "hamburger", "beef in a bun", new List<string>() { "bun", "ketchup", "mustard", "lettuce", "pickles" }, 7.99m);
            _menuRepo.AddMenuItemToDirectory(hamburger);
            MenuItem hotdog = new MenuItem(2, "hotdog", "skinny pig in a long bun", new List<string>() { "bun", "mustard" }, 3.99m);
            _menuRepo.AddMenuItemToDirectory(hotdog);
            MenuItem blt = new MenuItem(3, "BLT", "stuff and breads", new List<string>() { "bread", "bacon", "lettuce", "tomato" }, 4.99m);
            _menuRepo.AddMenuItemToDirectory(blt);
        }
    }
}
