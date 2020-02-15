using System;
using System.Collections.Generic;
using Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class TestEnvironment
    {
        [TestMethod]
        public void AddMenuItemToDirectory_ShouldGetTrueBoolean()
        {
            MenuItem menuItem = new MenuItem();
            MenuRepository repository = new MenuRepository();

            bool addMenuItem = repository.AddMenuItemToDirectory(menuItem);

            Assert.IsTrue(addMenuItem);
        }
        [TestMethod]
        public void GetMenuDirectory_ShouldReturnMenuDirectory()
        {
            MenuItem menuItem = new MenuItem();
            MenuRepository repository = new MenuRepository();

            repository.AddMenuItemToDirectory(menuItem);

            List<MenuItem> content = repository.GetAllMenuItems();

            bool directoryHasContent = content.Contains(menuItem);
            Assert.IsTrue(directoryHasContent);
        }


        private MenuRepository _repo;
        private MenuItem _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepository();
            _content = new MenuItem(1,"hamburger", "beef in a bun", new List<string>(){ "bun", "ketchup", "mustard", "lettuce", "pickles"}, 6.99m );
            _repo.AddMenuItemToDirectory(_content);
        }
        [TestMethod]
        public void GetMenuItemByName_ShouldReturnCorrectMenuItem()
        {
            MenuItem searchResult = _repo.GetMenuItemsByName("hamburger");
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void UpdateExistingMenu_ShouldReturnBool()
        {
            MenuItem newMenuItem = new MenuItem(1, "hamburger", "beef in a bun", new List<string>() { "bun", "ketchup", "mustard", "lettuce", "pickles" }, 7.99m);
            bool updateResult = _repo.UpdateMenuItem("hamburger", newMenuItem);
            Assert.IsTrue(updateResult);
        }
    }
}
