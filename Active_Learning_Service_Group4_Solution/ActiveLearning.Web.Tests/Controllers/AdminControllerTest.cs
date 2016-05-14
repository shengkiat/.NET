using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ActiveLearning.Web.Controllers;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Business.Interface;
using ActiveLearning.DB;
using System.Web.Mvc;
using ActiveLearning.Business.Mock;
using ActiveLearning.Business.Common;

namespace ActiveLearning.Web.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        private MockCourseManager _mockCourseManager;
        private MockUserManager _mockUserManager;
        private AdminController _controller;


        [TestInitialize]
        public void TestInitialize()
        {
            _mockCourseManager = new MockCourseManager();
            _mockUserManager = new MockUserManager();

            _controller = new AdminController(_mockCourseManager, _mockUserManager);
        }

        [TestMethod]
        public void ManageCourse_ExpectViewResultReturnedWithCorrectCourseCount()
        {
            // Arrange
            var stubCourses = (new List<Course>
            {
                new Course()
                {
                    Sid = 1,
                     CourseName = "Andy Lau"
                    ,CreateDT= DateTime.Now
                },
                new Course()
                {
                    Sid = 2,
                     CourseName = "Donnie Yen"
                     ,CreateDT= DateTime.Now
                }
            }).AsQueryable();

            _mockCourseManager.MockCourses = stubCourses;

            // Act
            var view = (ViewResult)_controller.ManageCourse();

            // Assert  
            var Model = (IEnumerable<Course>)view.Model;
            Assert.IsTrue(Model.Count() == 2);
        }

        [TestMethod]
        public void ManageCourse_ExpectError()
        {
            // Arrange

            // Act
            var view = (ViewResult)_controller.ManageCourse();

            // Assert  
            Assert.IsTrue(view.ViewData["Error"].ToString() == Constants.ValueNotFound(Constants.Course));
        }

        [TestMethod]
        public void CreateCourse_NoError()
        {
            // Arrange
            Course _course = new Course();
            _mockCourseManager.MockCourse = _course;

            // Act
            var action = (RedirectToRouteResult)_controller.CreateCourse(_course);

            // Assert  
            Assert.AreEqual("ManageCourse", action.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateCourse_NullParameter()
        {
            // Arrange

            // Act
            var view = (ViewResult)_controller.CreateCourse(null);

            // Assert  
            Assert.IsTrue(view.ViewData["Error"].ToString() == Constants.ValueIsEmpty(Constants.Course));
        }

        [TestMethod]
        public void CreateCourse_EF_Failure()
        {
            // Arrange
            _mockCourseManager.MockCourse = null;

            // Act
            var view = (ViewResult)_controller.CreateCourse(new Course());

            // Assert  
            Assert.IsTrue(view.ViewData["Error"].ToString() == Constants.OperationFailedDuringAddingValue(Constants.Course));
        }

        [TestMethod]
        public void ManageStudent_ExpectViewResultReturnedWithCorrectStudentsCount()
        {
            // Arrange
            var stubStudents = (new List<Student>
            {
                new Student()
                {
                    UserSid = 1

                },
                new Student()
                {
                    UserSid = 2
                }
            }).AsQueryable();

            _mockUserManager.MockStudents = stubStudents;

            // Act
            var view = (ViewResult)_controller.ManageStudent();

            // Assert  
            var Model = (IEnumerable<Student>)view.Model;
            Assert.IsTrue(Model.Count() == 2);
        }

        [TestMethod]
        public void ManageStudent_ExpectError()
        {
            // Arrange
            _mockUserManager.MockStudents = null;

            // Act
            var view = (ViewResult)_controller.ManageStudent();

            // Assert  
            Assert.IsTrue(view.ViewData["Error"].ToString() == Constants.ThereIsNoValueFound(Constants.Student));
        }

        [TestMethod]
        public void CreateStudent_NoError()
        {
            // Arrange
            Student _student = new Student();
            _mockUserManager.MockStudent = _student;

            // Act
            var action = (RedirectToRouteResult)_controller.CreateStudent(_student);

            // Assert  
            Assert.AreEqual("ManageStudent", action.RouteValues["action"]);
        }

        [TestMethod]
        public void CreateStudent_NullParameter()
        {
            // Arrange

            // Act
            var view = (ViewResult)_controller.CreateStudent(null);

            // Assert  
            Assert.IsTrue(view.ViewData["Error"].ToString() == Constants.ValueIsEmpty(Constants.Student));
        }

        [TestMethod]
        public void CreateStudent_EF_Failure()
        {
            // Arrange
            _mockUserManager.MockStudent = null;

            // Act
            var view = (ViewResult)_controller.CreateStudent(new Student());

            // Assert  
            Assert.IsTrue(view.ViewData["Error"].ToString() == Constants.OperationFailedDuringAddingValue(Constants.Student));
        }

    }
}
