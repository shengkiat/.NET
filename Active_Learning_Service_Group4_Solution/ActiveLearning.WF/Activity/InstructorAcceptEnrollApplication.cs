using System.Activities;
using ActiveLearning.Business.Implementation;
using System.ServiceModel;
using ActiveLearning.Common;

namespace ActiveLearning.WF.Activity
{

    public sealed class InstructorAcceptEnrollApplication : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> EnrollApplicationSid { get; set; }
        public OutArgument<bool> IsAcceptedSuccessfully { get; set; }
        public OutArgument<bool> HasError { get; set; }
        public OutArgument<string> Message { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int enrollApplicationSid = context.GetValue(this.EnrollApplicationSid);

            bool isAcceptedSuccessfully = false;
            bool hasError = false;
            string message = string.Empty;

            using (var courseManager = new CourseManager())
            {
                isAcceptedSuccessfully = courseManager.InstructorAcceptStudentEnrollApplication(enrollApplicationSid, out message);
                if(!isAcceptedSuccessfully && !string.IsNullOrEmpty(message))
                {
                    // message from out parameter
                    hasError = true;
                }
                else
                {
                    message = Constants.ValueSuccessfuly("The enrollment application has been accepted");
                    hasError = false;
                }
            }
            
            context.SetValue(this.IsAcceptedSuccessfully, isAcceptedSuccessfully);
            context.SetValue(this.HasError, hasError);
            context.SetValue(this.Message, message);
        }
    }
}
