using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGeniusModel;
using Moq;

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
            var nixinExtra = "extra information for nixin";

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
            var dataStorageMock = new Mock<IDataStorage>();

            string expectedData = ConstructJsonArrayQueryResult();
            // mock search function.
            dataStorageMock.Setup(func => func.Read(It.IsAny<string>())).Returns(expectedData);

            string nixinData = ConstructJsonArrayQueryResultForNixin();
            dataStorageMock.Setup(func => func.Read("{Name:nixin}")).Returns(nixinData);

            genius.DataStorageService = dataStorageMock.Object;
        }

        private string ConstructJsonArrayQueryResultForNixin()
        {
            return "[{Name:\"nixin\", Password:\"good\"}," 
                + "{Name:david, Password:\"good\"}," 
                + "{Name:kelly, Password:\"good\"}]";
        }

        private string ConstructJsonArrayQueryResult()
        {
            return "{Name:\"nixin\", Password:\"password\"," 
                + " Description:\"testing description\", " 
                + "Extra:\"extra information for nixin\"}";
        }

    }
}
