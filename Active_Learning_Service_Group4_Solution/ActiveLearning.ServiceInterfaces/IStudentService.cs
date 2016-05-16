using ActiveLearning.DB;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ActiveLearning.ServiceInterfaces
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IStudentService
    {
        [OperationContract]
        void Login(string userName, string password);

        [OperationContract]
        void Logout();

        [OperationContract]
        IEnumerable<Course> GetCourses();

        [OperationContract]
        IEnumerable<Content> GetContentsByCourseSid(int courseSid);

        [OperationContract]
        QuizQuestion GetNextQuizQuestionByCourseSid(int courseSid);

        [OperationContract]
        bool AnswerQuiz(int courseSid, int quizQuestionSid, int quizOptionSid);

    }

}
