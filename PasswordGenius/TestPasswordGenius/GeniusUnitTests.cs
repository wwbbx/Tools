using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGeniusModel;
using System.Collections.Generic;

namespace TestPasswordGenius
{
    [TestClass]
    public class GeniusUnitTests
    {
        [TestMethod]
        public void merge_result_will_remove_duplicated()
        {
            var duplicatedEntity = new PasswordEntity() { Name = "nixin", Description = "description" };

            List<PasswordEntity> groupA = new List<PasswordEntity>()
            {
                duplicatedEntity
            };

            List<PasswordEntity> groupB = new List<PasswordEntity>()
            {
                duplicatedEntity
            };

            // action
            var genius = new Genius();

            var actual = genius.MergeSearchResult(groupA, groupB);

            // assert
            Assert.IsTrue(actual.Count == 1);
        }

        [TestMethod]
        public void merge_result_will_include_all()
        {
            var unique = new PasswordEntity() { Name = "nixin", Description = "abc" };
            var duplicate = new PasswordEntity() { Name = "david", Description = "bdc" };
            var uniqueInB = new PasswordEntity() { Name = "kelly", Description = "efg" };

            var groupA = new List<PasswordEntity>()
            {
                unique, duplicate
            };

            var groupB = new List<PasswordEntity>()
            {
                duplicate, uniqueInB
            };

            // action
            var genius = new Genius();
            var actual = genius.MergeSearchResult(groupA, groupB);

            // assert
            Assert.IsTrue(actual.Count == 3);
        }
    }
}
