using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.Business.Implementation;
using System.Web;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckIfFileValid : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<Byte[]> FileBytes { get; set; }
        public InArgument<string> FileName { get; set; }
        public OutArgument<bool> IfFileValid { get; set; }
        public OutArgument<string> Message { get; set; }
        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            Byte[] fileBytes = context.GetValue(this.FileBytes);
            string fileName = context.GetValue(this.FileName);

            bool ifFileValid = true;
            string message = string.Empty;

            using (var contentManager = new ContentManager())
            {
                ifFileValid = contentManager.CheckIfContentValid(fileBytes.LongLength, fileName, out message);
            }

            context.SetValue(this.IfFileValid, ifFileValid);
            context.SetValue(this.Message, message);
        }
    }
}
