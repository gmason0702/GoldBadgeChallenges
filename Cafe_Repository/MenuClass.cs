using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class MenuItem
    {
        public MenuItem() { }
        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }
        //Create a Menu Class with properties, constructors, and fields.

        //A meal number, so customers can say "I'll have the #5"
        public int MealNumber { get; set; }
        //A meal name
        public string MealName { get; set; }
        //A description
        public string MealDescription { get; set; }
        //A list of ingredients,
        public List<string> MealIngredients { get; set; }
        //A price
        public decimal MealPrice { get; set; }
    }
}
