using ActiveLearning.Business.Implementation;
using ActiveLearning.Business.Interface;
using ActiveLearning.DB;
using ActiveLearning.Common;
using ActiveLearning.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using ActiveLearning.ServiceInterfaces.DTO;
using System.IO;

namespace ActiveLearning.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class StudentService : IStudentService
    {
        private UserDTO userDTO;
        private StudentDTO studentDTO;
        private IUserManager userManager;
        private IQuizManager quizManager;
        private ICourseManager courseManager;
        private IContentManager contentManager;

        public StudentService()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public IEnumerable<CourseDTO> GetCourses()
        {
            if (studentDTO == null || userDTO == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }
            using (courseManager = new CourseManager())
            {
                string message = string.Empty;
                var courseList = courseManager.GetEnrolledCoursesByStudentSid(studentDTO.Sid, out message) as List<Course>;
                if (courseList == null || courseList.Count() == 0)
                {
                    throw new FaultException(message);
                }
                var courseDTOs = new List<CourseDTO>();
                foreach (var course in courseList)
                {
                    CourseDTO courseDTO = new CourseDTO();
                    Util.CopyNonNullProperty(course, courseDTO);
                    courseDTOs.Add(courseDTO);
                }
                return courseDTOs;
            }
        }

        public IEnumerable<ContentDTO> GetContentsByCourseSid(int courseSid)
        {
            if (studentDTO == null || userDTO == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }
            using (contentManager = new ContentManager())
            {
                string message = string.Empty;
                var contentList = contentManager.GetAcceptedContentsByCourseSid(courseSid, out message);
                if (contentList == null || contentList.Count() == 0)
                {
                    throw new FaultException(message);
                }
                var contentDTOs = new List<ContentDTO>();
                foreach (var content in contentList)
                {
                    ContentDTO contentDTO = new ContentDTO();
                    Util.CopyNonNullProperty(content, contentDTO);
                    contentDTOs.Add(contentDTO);
                }
                return contentDTOs;
            }
        }

        public QuizQuestionDTO GetNextQuizQuestionByCourseSid(int courseSid)
        {
            if (studentDTO == null || userDTO == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }
            using (quizManager = new QuizManager())
            {
                string message = string.Empty;
                var quizQuestion = quizManager.GetNextQuizQuestionByStudentSidCourseSid(studentDTO.Sid, courseSid, out message);
                if (quizQuestion == null)
                {
                    throw new FaultException(message);
                }

                QuizQuestionDTO quizQuestionDTO = new QuizQuestionDTO();
                Util.CopyNonNullProperty(quizQuestion, quizQuestionDTO);

                quizQuestionDTO.QuizOptions = new List<QuizOptionDTO>();
                foreach (var quizOption in quizQuestion.QuizOptions)
                {
                    QuizOptionDTO quizOptionDTO = new QuizOptionDTO();
                    Util.CopyNonNullProperty(quizOption, quizOptionDTO);
                    quizQuestionDTO.QuizOptions.Add(quizOptionDTO);
                }

                return quizQuestionDTO;
            }
        }

        public bool? AnswerQuiz(int quizQuestionSid, int quizOptionSid)
        {
            if (studentDTO == null || userDTO == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }
            string message = string.Empty;
            using (quizManager = new QuizManager())
            {
                var result = quizManager.IsQuizAnswerCorrect(studentDTO.Sid, quizQuestionSid, quizOptionSid, out message);
                if (result == null)
                {
                    throw new FaultException(message);
                }
                return result;
            }
        }

        public bool Login(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new FaultException(Constants.PleaseEnterValue(Constants.UserName + " and " + Constants.Password));
            }
            using (userManager = new UserManager())
            {
                string message = string.Empty;

                var user = userManager.IsAuthenticated(userName, password, out message);

                if (user == null || user.Students == null || user.Students.Count() == 0)
                {
                    throw new FaultException(message);
                }

                switch (user.Role)
                {
                    case Constants.User_Role_Student_Code:
                        var student = user.Students.FirstOrDefault();
                        userDTO = new UserDTO();
                        Util.CopyNonNullProperty(user, userDTO);
                        studentDTO = new StudentDTO();
                        Util.CopyNonNullProperty(student, studentDTO);
                        Console.WriteLine("user: " + userDTO.Username + " authenticated");
                        return true;
                    default:
                        throw new FaultException(Constants.User_Not_Logged_In);

                }
            }
        }

        public void Logout()
        {
            userDTO = null;
            studentDTO = null;
        }

        public Stream DownloadFileStream(int contentSid)
        {
            if (studentDTO == null || userDTO == null)
            {
                throw new FaultException(Constants.User_Not_Logged_In);
            }
            string message = string.Empty;
            using (contentManager = new ContentManager())
            {
                Content content = contentManager.GetContentByContentSid(contentSid, out message);
                if (content == null)
                {
                    throw new FaultException(message);
                }
                string uploadPath = Util.GetUploadFolderFromConfig();
                if (string.IsNullOrEmpty(uploadPath))
                {
                    throw new FaultException(Constants.ValueNotFound("UploadPath App Setting"));
                }
                string path = uploadPath + content.FileName;
                try
                {
                    return File.OpenRead(path);
                }
                catch (Exception ex)
                {
                    Log.ExceptionLog(ex);
                    Log.ExceptionLog(ex.InnerException);
                    throw new FaultException(Constants.OperationFailedDuringRetrievingValue("File"));
                }

            }
        }
    }
}
