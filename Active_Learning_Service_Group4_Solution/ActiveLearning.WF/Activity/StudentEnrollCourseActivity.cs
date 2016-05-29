using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business;
using ActiveLearning.Business.Interface;
using ActiveLearning.Business.Implementation;
using System.ServiceModel;

namespace ActiveLearning.WF.Activity
{

    public sealed class StudentEnrollCourseActivity : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudentSid { get; set; }
        public InArgument<int> CourseSid { get; set; }
        public OutArgument<bool> EnrollApplicationPending { get; set; }
        public OutArgument<string> Message { get; set; }
        public OutArgument<int> EnrollApplicationSid { get; set; }


        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int studentSid = context.GetValue(this.StudentSid);
            int courseSid = context.GetValue(this.CourseSid);


            bool enrollApplicationPending = false;
            string message = string.Empty;
            int enrollApplicationSid = 0;

            using (var courseManager = new CourseManager())
            {
                if (courseManager.IsCourseFullyEnrolled(courseSid, out message))
                {
                    var enrollApplication = courseManager.AddStudentEnrollApplication(studentSid, courseSid, out message);
                    if ((enrollApplication == null && !string.IsNullOrEmpty(message)) ||
                        (enrollApplication.Sid == 0 && !string.IsNullOrEmpty(message)))
                    {
                        throw new FaultException(message);
                    }
                    message = string.Empty;
                    enrollApplicationSid = enrollApplication.Sid;
                    enrollApplicationPending = true;
                }
                else
                {
                    bool enrolled = courseManager.EnrolStudentToCourse(studentSid, courseSid, out message);
                    if (!enrolled)
                    {
                        throw new FaultException(message);
                    }
                    message = string.Empty;
                    enrollApplicationSid = 0;
                    enrollApplicationPending = false;
                }
            }

            context.SetValue(this.EnrollApplicationPending, enrollApplicationPending);
            context.SetValue(this.Message, message);
            context.SetValue(this.EnrollApplicationSid, enrollApplicationSid);
        }
    }
}
