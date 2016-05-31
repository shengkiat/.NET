using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;

namespace ActiveLearning.WF.Activity
{

    public sealed class StudentApplyToEnrollCourseActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudentSid { get; set; }
        public InArgument<int> CourseSid { get; set; }
        public OutArgument<bool> EnrollAppliedSuccessfully { get; set; }
        public OutArgument<int> EnrollApplicationSid { get; set; }
        public OutArgument<string> Message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int studentSid = context.GetValue(this.StudentSid);
            int courseSid = context.GetValue(this.CourseSid);

            bool enrollAppliedSuccessfully = false;
            string message = string.Empty;
            int enrollApplicationSid = 0;

            using (var courseManager = new CourseManager())
            {
                var enrollApplication = courseManager.AddStudentEnrollApplication(studentSid, courseSid, out message);
                if ((enrollApplication == null && !string.IsNullOrEmpty(message)) ||
                    (enrollApplication.Sid == 0 && !string.IsNullOrEmpty(message)))
                {
                    enrollApplicationSid = 0;
                    enrollAppliedSuccessfully = false;
                }
                if (enrollApplication != null && enrollApplication.Sid > 0)
                {
                    message = Constants.ValueSuccessfuly("Enrollment application has been submitted");
                    enrollApplicationSid = enrollApplication.Sid;
                    enrollAppliedSuccessfully = true;
                }
            }

            context.SetValue(this.EnrollAppliedSuccessfully, enrollAppliedSuccessfully);
            context.SetValue(this.Message, message);
            context.SetValue(this.EnrollApplicationSid, enrollApplicationSid);
        }
    }
}
