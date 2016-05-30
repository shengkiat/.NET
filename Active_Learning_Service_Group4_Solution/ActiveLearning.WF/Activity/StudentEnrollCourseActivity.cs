using System.Activities;
using ActiveLearning.Business.Implementation;
using System.ServiceModel;
using ActiveLearning.Common;

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
                // if already enrolled
                if (courseManager.HasStudentEnrolledToCourse(studentSid, courseSid, out message))
                {
                    enrollApplicationPending = false;
                    enrollApplicationSid = 0;
                }
                // if not enrolled
                else
                {
                    // if fully enrolled
                    if (courseManager.IsCourseFullyEnrolled(courseSid, out message))
                    {
                        // if already applied
                        if (courseManager.HasStudentAppliedCourse(studentSid, courseSid, out message))
                        {
                            enrollApplicationSid = 0;
                            enrollApplicationPending = false;
                        }
                        // if not applied
                        else
                        {
                            var enrollApplication = courseManager.AddStudentEnrollApplication(studentSid, courseSid, out message);
                            if ((enrollApplication == null && !string.IsNullOrEmpty(message)) ||
                                (enrollApplication.Sid == 0 && !string.IsNullOrEmpty(message)))
                            {
                                enrollApplicationSid = 0;
                                enrollApplicationPending = false;
                            }
                            if (enrollApplication != null && enrollApplication.Sid > 0)
                            {
                                message = Constants.ValueSuccessfuly("Enrollment application has been submitted");
                                enrollApplicationSid = enrollApplication.Sid;
                                enrollApplicationPending = true;
                            }
                        }
                    }
                    // if not fully enrolled
                    else
                    {
                        bool enrolled = courseManager.EnrolStudentToCourse(studentSid, courseSid, out message);
                        if (!enrolled)
                        {
                            enrollApplicationSid = 0;
                            enrollApplicationPending = false;
                        }
                        else
                        {
                            message = Constants.ValueSuccessfuly("Course has been enrolled");
                            enrollApplicationSid = 0;
                            enrollApplicationPending = false;
                        }
                    }
                }
            }
            context.SetValue(this.EnrollApplicationPending, enrollApplicationPending);
            context.SetValue(this.Message, message);
            context.SetValue(this.EnrollApplicationSid, enrollApplicationSid);
        }
    }
}
