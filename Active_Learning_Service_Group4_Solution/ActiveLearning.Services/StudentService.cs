using ActiveLearning.Business.Implementation;
using ActiveLearning.Business.Interface;
using ActiveLearning.DB;
using ActiveLearning.Common;
using ActiveLearning.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Linq;
using System.ServiceModel.Security;

namespace ActiveLearning.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class StudentService : UserNamePasswordValidator, IStudentService
    {
        private User _user;
        private Student _student;
        private IUserManager _userManager;
        private QuizManager _quizManager;
        private CourseManager _courseManager;

        public StudentService()
        {

        }

        public IEnumerable<Course> GetCourses()
        {
            if (this._student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }
            using (_courseManager = new CourseManager())
            {
                string message = string.Empty;
                var courseList = _courseManager.GetEnrolledCoursesByStudentSid(this._student.Sid, out message);
                if (courseList == null || courseList.Count() == 0)
                {
                    throw new FaultException(message);
                }

            }

            throw new NotImplementedException();
        }

        public IEnumerable<Content> GetContentsByCourseSid(int courseSid)
        {
            if (this._student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }

            throw new NotImplementedException();
        }

        public QuizQuestion GetNextQuizQuestionByCourseSid(int courseSid)
        {
            if (this._student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }

            throw new NotImplementedException();
        }

        public bool AnswerQuiz(int courseSid, int quizQuestionSid, int quizOptionSid)
        {
            if (this._student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }

            using (_quizManager = new QuizManager())
            {

            }

            throw new NotImplementedException();
        }


        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }
            using (_userManager = new UserManager())
            {
                string message = string.Empty;

                //var task = new Task(() =>
                //{
                _user = _userManager.IsAuthenticated(userName, password, out message);
                //}
                //);
                //task.Start();
                //await task;

                if (_user == null || _user.Students == null || _user.Students.Count() == 0)
                {
                    throw new MessageSecurityException(message);
                }

                switch (_user.Role)
                {
                    case Constants.User_Role_Student_Code:
                        this._student = _user.Students.FirstOrDefault();
                        Console.WriteLine("user: " + _user.Username + " authenticated");
                        break;
                    default:
                        throw new MessageSecurityException(Constants.User_Not_Logged_In);

                }
            }
        }

        public bool IsAuthenticated()
        {
            return this._student == null ? false : true;
        }

        public void Login(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }
            using (_userManager = new UserManager())
            {
                string message = string.Empty;

                //var task = new Task(() =>
                //{
                _user = _userManager.IsAuthenticated(userName, password, out message);
                //}
                //);
                //task.Start();
                //await task;

                if (_user == null || _user.Students == null || _user.Students.Count() == 0)
                {
                    throw new MessageSecurityException(message);
                }

                switch (_user.Role)
                {
                    case Constants.User_Role_Student_Code:
                        this._student = _user.Students.FirstOrDefault();
                        Console.WriteLine("user: " + _user.Username + " authenticated");
                        break;
                     default:
                        throw new MessageSecurityException(Constants.User_Not_Logged_In);

                }
            }
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
