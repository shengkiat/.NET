using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckIfCourseExists : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> CourseSid { get; set; }
        public OutArgument<bool> CourseExists { get; set; }
        public OutArgument<string> Message{ get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int courseSid = context.GetValue(this.CourseSid);

            bool courseExists = false;
            string message = string.Empty;
            using (var courseManager = new CourseManager())
            {
                var course = courseManager.GetCourseByCourseSid(courseSid, out message);
                if(course == null)
                {
                    courseExists = false;
                }
                else
                {
                    courseExists = true;
                }
            }
            context.SetValue(this.CourseExists, courseExists);
            context.SetValue(this.Message, message);
        }
    }
}
