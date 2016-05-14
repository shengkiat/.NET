using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;

namespace ActiveLearning.DB.Tests.ViewModel
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void Validate_Model_Given_Valid_Model_ExpectNoValidationErrors()
        {
            var model = new ActiveLearning.DB.User();

            model.Username = "Andy Lau";
            model.Password = "Tony Chiu";
            model.FullName = "Andy Lau";
            model.CreateDT = DateTime.Now;
            model.Role = "S";


            TestModelHelper.ValidateObject(model);
        }

        [TestMethod]
        public void Validate_Model_Given_Username_Is_Null_ExpectOneValidationError()
        {
            try
            {
                var model = new ActiveLearning.DB.User();

                TestModelHelper.ValidateObject(model);
            }
            catch (ValidationException ae)
            {
                Assert.AreEqual(Common.Constants.Please_Enter + "User Name", ae.Message);
            }
        }

        [TestMethod]
        public void Validate_Model_Given_Password_Is_Null_ExpectOneValidationError()
        {
            try
            {
                var model = new ActiveLearning.DB.User();

                model.Username = "Andy Lau";
                model.FullName = "Andy Lau";
                model.CreateDT = DateTime.Now;
                model.Role = "S";

                TestModelHelper.ValidateObject(model);
            }
            catch (ValidationException ae)
            {
                Assert.AreEqual(Common.Constants.Please_Enter + "Password", ae.Message);
            }
        }









    }
}
