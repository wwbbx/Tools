using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGeniusModel;
using Moq;
using System.Collections.Generic;

namespace TestPasswordGeniusModel
{
    [TestClass]
    public class GeniusSearchFunction
    {
        [TestMethod]
        public void search_empty_will_return_all_results()
        {
            var genius = new Genius();
            PrepareEnvironment(genius);

            // setup expectation
            int expectedCount = 3;

            // action
            genius.Search("");

            var result = genius.SearchResult;

            // assert
            Assert.AreEqual(expectedCount, result.Count);
        }


        [TestMethod]
        public void search_nixin_will_return_one_result()
        {
            var genius = new Genius();
            PrepareEnvironment(genius);

            // setup expectation
            var nixinPassword = "password";
            var nixinDescription = "testing description";
            var nixinExtra = "extra information";

            // action
            genius.Search("nixin");

            // assert
            var result = genius.SearchResult;
            Assert.AreEqual(1, result.Count);

            var searched = result[0];
            Assert.AreEqual(nixinPassword, searched.Password);
            Assert.AreEqual(nixinDescription, searched.Description);
            Assert.AreEqual(nixinExtra, searched.Extra);
        }

        private void PrepareEnvironment(Genius genius)
        {
            var dataStorageMock = new Mock<IDataService>();

            var expectedData = ConstructQueryResultForAnything();
            // mock search function.
            dataStorageMock.Setup(func => func.Search(It.IsAny<string>())).Returns(expectedData);

            var nixinData = ConstructQueryResultForNixin();
            dataStorageMock.Setup(func => func.Search("{name:nixin}")).Returns(nixinData);

            dataStorageMock.Setup(func => func.Search("{description:nixin}")).Returns(new List<PasswordEntity>());
            dataStorageMock.Setup(func => func.Search("{extra:nixin}")).Returns(new List<PasswordEntity>());

            genius.DataStorageService = dataStorageMock.Object;
        }

        private List<PasswordEntity> ConstructQueryResultForNixin()
        {
            return new List<PasswordEntity>()
            {
                new PasswordEntity(){
                    Name="nixin",
                    Password = "password",
                    Description = "testing description",
                    Extra = "extra information"
                }
            };
        }

        private List<PasswordEntity> ConstructQueryResultForAnything()
        {
            return new List<PasswordEntity>(){
                new PasswordEntity(){Name="nixin", Password = "nixin"},
                new PasswordEntity(){Name="david", Password="david"},
                new PasswordEntity(){Name="kelly", Password="kelly"}
            };
        }

    }
}
