using System;
using System.Collections.Generic;
using BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void AddBadgeToDirectory_ShouldAddBadge()
        {
            Badge content = new Badge();
            Repository repo = new Repository();

            bool addBadge = repo.AddBadgeToDictionary(content);
            Assert.IsTrue(addBadge);
        }
        [TestMethod]
        public void GetAllBadges_ShouldReturnBadgeDirectory()
        {
            Badge content = new Badge();
            Repository repo = new Repository();

            repo.AddBadgeToDictionary(content);
            Dictionary<int, List<string>> newDictionary = repo.GetAllBadges();

            bool directoryHasContent = newDictionary.ContainsKey(content.BadgeID);

            Assert.IsTrue(directoryHasContent);
        }


        private Repository _repo;
        private Badge _content;
        [TestInitialize]

        public void Arrange()
        {
            _repo = new Repository();
            _content = new Badge(14253, new List<string> { "B15", "E9" });
            _repo.AddBadgeToDictionary(_content);

        }
        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnAreEqual()
        {
            string updatedDoor = "E3";
            _repo.UpdateExistingBadge(14253, updatedDoor);
            Assert.AreEqual(3, _content.DoorNames.Count);

        }

        [TestMethod]
        public void DeleteDoorFromBadge_ShouldReturnAreEqual()
        {
            string doorToDelete = "B15";
            _repo.RemoveDoorFromBadge(14253, doorToDelete);
            Assert.AreEqual(1, _content.DoorNames.Count);
        }
        //[TestMethod]
        //public void MyTestMethod()
        //{

        //    //bool removeResult = _repo.RemoveDoorFromBadge(14253, new List<string> { "B15" });
        //    Assert.IsTrue(removeResult);
        //}
    }


}
    

