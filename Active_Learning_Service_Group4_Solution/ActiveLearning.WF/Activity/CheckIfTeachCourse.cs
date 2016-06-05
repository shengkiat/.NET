using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckIfTeachCourse : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> InstructorSid { get; set; }
        public InArgument<int> CourseSid { get; set; }
        public OutArgument<bool> IfTeachCourse { get; set; }
        public OutArgument<string> Message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int instructorSid = context.GetValue(this.InstructorSid);
            int courseSid = context.GetValue(this.CourseSid);

            bool ifTeachCourse = false;
            string message = string.Empty;

            using (var courseManager = new CourseManager())
            {
                ifTeachCourse = courseManager.CheckIfInstructorEnrolledCourse(instructorSid, courseSid, out message);
                if (!ifTeachCourse)
                {
                    // message is from the contentmanager
                }
                else
                {
                    message = string.Empty;
                }
            }

            context.SetValue(this.IfTeachCourse, ifTeachCourse);
            context.SetValue(this.Message, message);
        }
    }
}
