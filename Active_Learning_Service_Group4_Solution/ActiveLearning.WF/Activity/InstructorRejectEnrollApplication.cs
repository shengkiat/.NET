using System.Activities;
using ActiveLearning.Business.Implementation;
using System.ServiceModel;
using ActiveLearning.Common;

namespace ActiveLearning.WF.Activity
{

    public sealed class InstructorRejectEnrollApplication : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> EnrollApplicationSid { get; set; }
        public InArgument<string> Remark { get; set; }

        public OutArgument<bool> IsRejectedSuccessfully { get; set; }
        public OutArgument<bool> HasError { get; set; }
        public OutArgument<string> Message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            string remark = context.GetValue(this.Remark);
            int enrollApplicationSid = context.GetValue(this.EnrollApplicationSid);

            bool isRejectedSuccessfully = false;
            bool hasError = false;
            string message = string.Empty;

            using (var courseManager = new CourseManager())
            {
                isRejectedSuccessfully = courseManager.InstructorRejectStudentEnrollApplication(enrollApplicationSid, remark, out message);
                if (!isRejectedSuccessfully && !string.IsNullOrEmpty(message))
                {
                    // message from our parameter
                    hasError = true;
                }
                else
                {
                    message = Constants.ValueSuccessfuly("The enrollment application has been rejected");
                    hasError = false;
                }
            }

            context.SetValue(this.IsRejectedSuccessfully, isRejectedSuccessfully);
            context.SetValue(this.HasError, hasError);
            context.SetValue(this.Message, message);
        }
    }
}
