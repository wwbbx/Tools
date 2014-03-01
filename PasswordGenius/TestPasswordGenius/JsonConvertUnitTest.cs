using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGeniusModel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestPasswordGenius
{
    [TestClass]
    public class JsonConvertUnitTest
    {
        [TestMethod]
        public void convert_json_to_password_entity()
        {
            var json = "{\"Name\":\"nixin\", \"Description\":\"description\","
                + " \"Password\":\"password\", \"Extra\":\"extra\"}";

            var expected = new PasswordEntity()
            {
                Name = "nixin",
                Description = "description",
                Password = "password",
                Extra = "extra"
            };

            var actual = JsonConvert.DeserializeObject<PasswordEntity>(json);

            Assert.IsTrue(ComparePasswordEntity(expected, actual));
        }

        [TestMethod]
        public void convert_password_entity_to_json()
        {
            var passwordEntity = new PasswordEntity()
            {
                Name = "nixin",
                Description = "description",
                Password = "password",
                Extra = "extra"
            };

            var expected = "{\"Name\":\"nixin\",\"Password\":\"password\","
                + "\"Description\":\"description\",\"Extra\":\"extra\"}";

            var actual = JsonConvert.SerializeObject(passwordEntity);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void convert_json_to_list_of_password_entity()
        {
            var json = "[{\"Name\":\"nixin\",\"Password\":\"password\","
                + "\"Description\":\"description\",\"Extra\":\"extra\"},"
                + "{\"Name\":\"nixin\",\"Password\":\"password\","
                + "\"Description\":\"description\",\"Extra\":\"extra\"}]";

            var passwordEntity = new PasswordEntity()
            {
                Name="nixin", 
                Description = "description", 
                Password = "password", 
                Extra = "extra"
            };

            var expected = new List<PasswordEntity>()
            {
                passwordEntity, passwordEntity
            };

            var actual = JsonConvert.DeserializeObject<List<PasswordEntity>>(json);

            Assert.IsTrue(actual.Count == 2);
            Assert.IsTrue(actual[0] is PasswordEntity);
        }

        [TestMethod]
        public void convert_password_entity_list_to_json()
        {
            var expected = "[{\"Name\":\"nixin\",\"Password\":\"password\","
                + "\"Description\":\"description\",\"Extra\":\"extra\"},"
                + "{\"Name\":\"nixin\",\"Password\":\"password\","
                + "\"Description\":\"description\",\"Extra\":\"extra\"}]";

            var passwordEntity = new PasswordEntity()
            {
                Name = "nixin",
                Description = "description",
                Password = "password",
                Extra = "extra"
            };

            var passwordEntityList = new List<PasswordEntity>()
            {
                passwordEntity, passwordEntity
            };

            var actual = JsonConvert.SerializeObject(passwordEntityList);

            Assert.AreEqual(expected, actual);
        }

        private bool ComparePasswordEntity(PasswordEntity expected, PasswordEntity actual)
        {
            var expectedType = expected.GetType();
            var actualType = actual.GetType();
            var properties = expectedType.GetProperties();

            foreach (var property in properties)
            {
                var expectedProperty = property.GetValue(expected) as string;
                var actualProperty = property.GetValue(actual) as string;

                if (expectedProperty != actualProperty) return false;
            }

            return true;
        }
    }
}
