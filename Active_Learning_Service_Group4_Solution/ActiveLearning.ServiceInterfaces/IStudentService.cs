using ActiveLearning.ServiceInterfaces.DTO;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ActiveLearning.ServiceInterfaces
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IStudentService
    {
        [OperationContract]
        bool Login(string userName, string password);

        [OperationContract]
        void Logout();

        [OperationContract]
        IEnumerable<CourseDTO> GetCourses();

        [OperationContract]
        IEnumerable<ContentDTO> GetContentsByCourseSid(int courseSid);

        [OperationContract]
        byte[] DownloadFileBytes(int contentSid);

        [OperationContract]
        QuizQuestionDTO GetNextQuizQuestionByCourseSid(int courseSid);

        [OperationContract]
        bool? AnswerQuiz(int quizQuestionSid, int quizOptionSid);
    }
}
