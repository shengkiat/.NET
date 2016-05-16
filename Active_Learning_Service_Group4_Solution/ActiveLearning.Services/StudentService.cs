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
    public class StudentService : IStudentService
    {
        private User _user;
        private Student _student;
        private IUserManager _userManager;
        private QuizManager _quizManager;
        private CourseManager _courseManager;

        public IEnumerable<Course> GetCourses()
        {
            if (_student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }
            using (_courseManager = new CourseManager())
            {
                string message = string.Empty;
                var courseList = _courseManager.GetEnrolledCoursesByStudentSid(_student.Sid, out message);
                if (courseList == null || courseList.Count() == 0)
                {
                    throw new FaultException(message);
                }
                return courseList;
            }
        }

        public IEnumerable<Content> GetContentsByCourseSid(int courseSid)
        {
            if (_student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }

            throw new NotImplementedException();
        }

        public QuizQuestion GetNextQuizQuestionByCourseSid(int courseSid)
        {
            if (_student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }

            throw new NotImplementedException();
        }

        public bool AnswerQuiz(int courseSid, int quizQuestionSid, int quizOptionSid)
        {
            if (_student == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }

            using (_quizManager = new QuizManager())
            {

            }

            throw new NotImplementedException();
        }

        public void Login(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new FaultException(Constants.PleaseEnterValue(Constants.UserName + " and " + Constants.Password));
            }
            using (_userManager = new UserManager())
            {
                string message = string.Empty;

                _user = _userManager.IsAuthenticated(userName, password, out message);

                if (_user == null || _user.Students == null || _user.Students.Count() == 0)
                {
                    throw new FaultException(message);
                }

                switch (_user.Role)
                {
                    case Constants.User_Role_Student_Code:
                        _student = _user.Students.FirstOrDefault();
                        Console.WriteLine("user: " + _user.Username + " authenticated");
                        break;
                    default:
                        throw new FaultException(Constants.User_Not_Logged_In);

                }
            }
        }

        public void Logout()
        {

        }
    }
}
