using System.Activities;
using ActiveLearning.Business.Implementation;
using System.ServiceModel;
using ActiveLearning.Common;

namespace ActiveLearning.WF.Activity
{

    public sealed class StudentEnrollCourse : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudentSid { get; set; }
        public InArgument<int> CourseSid { get; set; }
        public OutArgument<bool> EnrolledSuccessfully { get; set; }
        public OutArgument<string> Message { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int studentSid = context.GetValue(this.StudentSid);
            int courseSid = context.GetValue(this.CourseSid);

            bool enrolledSuccessfully = false;
            string message = string.Empty;

            using (var courseManager = new CourseManager())
            {
                enrolledSuccessfully = courseManager.EnrolStudentToCourse(studentSid, courseSid, out message);
                if (!enrolledSuccessfully)
                {
                    // message is from out parameter
                }
                else
                {
                    message = Constants.ValueSuccessfuly("Course has been enrolled");
                    enrolledSuccessfully = true;
                }
            }
            context.SetValue(this.EnrolledSuccessfully, enrolledSuccessfully);
            context.SetValue(this.Message, message);
        }
    }
}
