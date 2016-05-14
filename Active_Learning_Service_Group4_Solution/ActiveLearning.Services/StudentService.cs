using ActiveLearning.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ActiveLearning.DB;
using System.IdentityModel.Selectors;
using ActiveLearning.Business.Interface;
using ActiveLearning.Business.Implementation;

namespace ActiveLearning.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StudentService : UserNamePasswordValidator, IStudentService
    {
        private IUserManager _userManager;

        public StudentService(IUserManager UserManager)
        {
            _userManager = UserManager;
        }

        public bool AnswerQuiz(int quizQuestionSid, int quizAnswserSid)
        {
            throw new NotImplementedException();
        }

        public Student Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Content> GetContentsByCourseSid(int courseSid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesByStudentSid(int studentSid)
        {
            throw new NotImplementedException();
        }

        public QuizQuestion GetNextQuiz()
        {
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

                var user = _userManager.IsAuthenticated(userName, password, out message);

                if (user == null)
                {
                    throw new FaultException(message);
                }
            }
        }
    }
}
