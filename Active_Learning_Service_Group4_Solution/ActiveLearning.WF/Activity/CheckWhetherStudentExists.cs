using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckWhetherStudentExists : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> StudentSid { get; set; }
        public OutArgument<bool> StudentExists { get; set; }
        public OutArgument<string> Message { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            int studentSid = context.GetValue(this.StudentSid);

            bool studentExist = false;
            string message = string.Empty;
            using (var userManager = new UserManager())
            {
                var user = userManager.GetStudentByStudentSid(studentSid, out message);
                if (user == null)
                {
                    studentExist = false;
                }
                else
                {
                    studentExist = true;
                }
            }
            context.SetValue(this.StudentExists, studentExist);
            context.SetValue(this.Message, message);
        }
    }
}
