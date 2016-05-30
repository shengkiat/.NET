using System.Activities;
using ActiveLearning.Business.Implementation;
using System.ServiceModel;

namespace ActiveLearning.WF.Activity
{

    public sealed class InstructorAcceptEnrollApplicationActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudentSid { get; set; }
        public InArgument<int> CourseSid { get; set; }
        public InArgument<int> EnrollApplicationSid { get; set; }
        
        public OutArgument<bool> Result { get; set; }
        public OutArgument<string> Message { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int studentSid = context.GetValue(this.StudentSid);
            int courseSid = context.GetValue(this.CourseSid);
            int enrollApplicationSid = context.GetValue(this.EnrollApplicationSid);

            bool result = false;
            string message = string.Empty;

            using (var courseManager = new CourseManager())
            {
                result = courseManager.InstructorAcceptStudentEnrollApplication(studentSid, courseSid, out message);
                if(!result && !string.IsNullOrEmpty(message))
                {
                    throw new FaultException(message);
                }
                message = string.Empty;
            }
            
            context.SetValue(this.Result, result);
            context.SetValue(this.Message, message);
        }
    }
}
