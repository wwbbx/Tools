using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGeniusModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestPasswordGenius
{
    [TestClass]
    public class FileStorageUnitTest
    {
        [TestMethod]
        public void query_will_return_password_entity_list_as_json_string()
        {
            PrepareTestingDataFile();

            var expected = "";

            // action
            IDataStorage fileStorage = new FileStorage();

            var queryString = "{\"Name\":\"nixin\"}";
            var actual = fileStorage.Query(queryString);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void query_return_all_if_no_keyword_is_specified()
        {
            PrepareTestingDataFile();

            var expected = "";

            // action
            IDataStorage fileStorage = new FileStorage();

            var queryString = "{}";
            var actual = fileStorage.Query(queryString);

            Assert.AreEqual(expected, actual);
        }

        private void PrepareTestingDataFile()
        {
            var dataFileFullName = Path.Combine(Environment.CurrentDirectory, "PasswordData.dat");

            var passwordNixin = new PasswordEntity()
            {
                Name = "nixin",
                Description = "description"
            };

            var passwordDavid = new PasswordEntity()
            {
                Name = "david",
                Password = "pdavid"
            };

            var passwordKelly = new PasswordEntity()
            {
                Name = "kelly",
                Extra = "extra"
            };

            StringBuilder content = new StringBuilder();
            content.AppendLine(passwordNixin.ToJson());
            content.AppendLine(passwordDavid.ToJson());
            content.AppendLine(passwordKelly.ToJson());

            File.WriteAllText(dataFileFullName, content.ToString());
        }

        [TestMethod]
        public void add_will_append_password_entity()
        {
            var nameKey = "gondor";

            IDataStorage dataStorage = new FileStorage();

            // make sure current one is null.
            var existingPassword = GetPasswordEntityByName(nameKey, dataStorage);
            Assert.IsNull(existingPassword);

            // add it
            var passwordToAdd = new PasswordEntity()
            {
                Name = nameKey,
                Password = "gondor"
            };

            dataStorage.Add(passwordToAdd.ToJson());

            // it should exist now.
            existingPassword = GetPasswordEntityByName(nameKey, dataStorage);
            Assert.IsNotNull(existingPassword);
        }

        [TestMethod]
        public void update_will_change_properties()
        {
            var nameKey = "nixin";
            var existingPassword = "password";
            var passwordAfterUpdate = "newpassword";

            var passwordToUpdate = new PasswordEntity()
            {
                Name = nameKey,
                Description = "description",
                Password = passwordAfterUpdate,
                Extra = "extra"
            };

            IDataStorage fileStorage = new FileStorage();

            // get existing and check its password is old one
            var currentPasswordEntity = GetPasswordEntityByName(nameKey, fileStorage);

            // make sure the first one's password is old one
            Assert.AreEqual(existingPassword, currentPasswordEntity.Password);

            // then we do the update.
            fileStorage.Update(passwordToUpdate.Name, passwordToUpdate.ToJson());

            // get it back again 
            var updatedPasswordEntity = GetPasswordEntityByName(nameKey, fileStorage);

            // make sure the password is updated to the latest one.
            Assert.AreEqual(passwordAfterUpdate, updatedPasswordEntity.Password);
        }

        private static PasswordEntity GetPasswordEntityByName(
            string nameKey, IDataStorage fileStorage)
        {
            var firstMatch = fileStorage.QueryName(nameKey);
            var currentPasswordEntity = new PasswordEntity();
            currentPasswordEntity.ParseJson(firstMatch);

            return currentPasswordEntity;
        }
    }
}
