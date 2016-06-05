using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckIfCourseFull : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> CourseSid { get; set; }
        public OutArgument<bool> IsCourseFull { get; set; }
        public OutArgument<string> Message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int courseSid = context.GetValue(this.CourseSid);

            bool isCourseFull = false;
            string message = string.Empty;

            using (var courseManager = new CourseManager())
            {
                if (courseManager.IsCourseFullyEnrolled(courseSid, out message))
                {
                    message = Constants.Course_Fully_Enrolled;
                    isCourseFull = true;
                }
            }

            context.SetValue(this.IsCourseFull, isCourseFull);
            context.SetValue(this.Message, message);
        }
    }
}
