using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGeniusModel;
using Moq;
using System.Collections.Generic;

namespace TestPasswordGeniusModel
{
    [TestClass]
    public class GeniusLoadFunction
    {
        [TestMethod]
        public void load_by_key_will_return_desired_detailed_info()
        {
            // prepare
            var expected = new PasswordEntity()
            {
                Name = "nixin",
                Description = "description"
            };

            // action
            var genius = new Genius();
            genius.DataStorageService = MockDataStorageService();
            PasswordEntity password = genius.LoadByNameKey("nixin");

            // assert
            Assert.AreEqual(expected.Name, password.Name);
            Assert.AreEqual(expected.Description, password.Description);
        }

        private IDataService MockDataStorageService()
        {
            var dataStorageMock = new Mock<IDataService>();
            dataStorageMock.Setup(func => func.Search("{\"Name\":\"nixin\"}")).Returns(
                new List<PasswordEntity>()
                {
                    new PasswordEntity(){ Name = "nixin", Description = "description" },
                });

            return dataStorageMock.Object;
        }
    }
}
