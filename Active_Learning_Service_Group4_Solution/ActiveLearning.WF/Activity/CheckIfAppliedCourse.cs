using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckIfAppliedCourse : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudentSid { get; set; }
        public InArgument<int> CourseSid { get; set; }

        public OutArgument<bool> HasApplied { get; set; }
        public OutArgument<string> Message { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int studentSid = context.GetValue(this.StudentSid);
            int courseSid = context.GetValue(this.CourseSid);

            bool hasApplied = false;
            string message = string.Empty;

            using (var courseManager = new CourseManager())
            {
                if (courseManager.HasStudentAppliedCourse(studentSid, courseSid, out message))
                {
                    hasApplied = true;
                }
            }

            context.SetValue(this.HasApplied, hasApplied);
            context.SetValue(this.Message, message);
        }
    }
}
