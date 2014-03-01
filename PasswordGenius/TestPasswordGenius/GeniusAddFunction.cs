﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGeniusModel;
using Moq;
using System.Collections.Generic;

namespace TestPasswordGeniusModel
{
    [TestClass]
    public class GeniusAddFunction
    {
        [TestMethod]
        public void add_detailed_info_will_store_it()
        {
            // make sure DB doesn't have the one that we are going to insert
            var passwordEntityToInsert = new PasswordEntity()
            {
                Name="nixin", Description = "description", Password = "pd", Extra = "extra"
            };

            var genius = new Genius();
            genius.DataStorageService = MockStorageServiceBeforeInsert();
            var exist = genius.Has(passwordEntityToInsert);

            Assert.IsFalse(exist);
            
            // insert it
            genius.Add(passwordEntityToInsert);
            genius.DataStorageService = MockStorageServiceAfterInsert();

            // check DB should have it now.
            exist = genius.Has(passwordEntityToInsert);
            Assert.IsTrue(exist);
        }

        private IDataService MockStorageServiceAfterInsert()
        {
            var storageMock = new Mock<IDataService>();
            storageMock.Setup(func => func.Contains(It.IsAny<PasswordEntity>())).Returns(true);

            return storageMock.Object;
        }

        private IDataService MockStorageServiceBeforeInsert()
        {
            var storageMock = new Mock<IDataService>();
            storageMock.Setup(func => func.Contains(It.IsAny<PasswordEntity>())).Returns(false);

            return storageMock.Object;
        }
    }
}
