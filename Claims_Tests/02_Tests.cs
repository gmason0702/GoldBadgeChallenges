using System;
using System.Collections;
using System.Collections.Generic;
using Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void AddClaimToDirectory_ShouldReturnTrueBoolean()
        {
            Claim content = new Claim();
            ClaimsRepository repo = new ClaimsRepository();

            bool addClaim = repo.AddClaimToDirectory(content);

            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void GetClaimDirectory_ShouldReturnDirectory()
        {
            Claim content = new Claim();
            ClaimsRepository repo = new ClaimsRepository();

            repo.AddClaimToDirectory(content);
            Queue<Claim> newContent = repo.GetAllClaims();

            bool directoryHasContent = newContent.Contains(content);

            Assert.IsTrue(directoryHasContent);
        }
        
    }
}
