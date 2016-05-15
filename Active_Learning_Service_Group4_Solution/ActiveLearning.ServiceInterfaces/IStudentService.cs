using ActiveLearning.DB;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ActiveLearning.ServiceInterfaces
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        void Validate(string userName, string password);

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
