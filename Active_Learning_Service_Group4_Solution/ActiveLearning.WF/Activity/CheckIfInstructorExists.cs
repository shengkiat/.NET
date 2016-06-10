using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckIfInstructorExists : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<int> InstructorSid { get; set; }
        public OutArgument<bool> IfInstructorExists { get; set; }
        public OutArgument<string> Message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            log4net.Config.XmlConfigurator.Configure();

            // Obtain the runtime value of the Text input argument
            int instructorSid = context.GetValue(this.InstructorSid);

            bool ifInstructorExists = false;
            string message = string.Empty;

            using (var userManager = new UserManager())
            {
                var instructor = userManager.GetActiveInstructorByInstructorSid(instructorSid, out message);
                if (instructor == null)
                {
                    ifInstructorExists = false;
                }
                else
                {
                    message = string.Empty;
                    ifInstructorExists = true;
                }
            }

            context.SetValue(this.IfInstructorExists, ifInstructorExists);
            context.SetValue(this.Message, message);
        }
    }
}
