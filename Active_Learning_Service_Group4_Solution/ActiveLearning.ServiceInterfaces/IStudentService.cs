using ActiveLearning.DB;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ActiveLearning.ServiceInterfaces
{
    [ServiceContract]
    public interface IStudentService
    {
        // Dont need Operation Contract
        void Validate(string userName, string password);
        //Student Authenticate(string userName, string password);

        [OperationContract]
        Task<IEnumerable<Course>> GetCoursesWithStudentSid();

        [OperationContract]
        Task<IEnumerable<Course>> GetCoursesByStudentSid(int studentSid);

        [OperationContract]
        Task<IEnumerable<Content>> GetContentsByCourseSid(int courseSid);

        [OperationContract]
        QuizQuestion GetNextQuiz();

        [OperationContract]
        bool AnswerQuiz(int quizQuestionSid, int quizAnswserSid);

    }

}
