using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Web;
using ActiveLearning.Common;
using ActiveLearning.Business.Implementation;
using System.IO;

namespace ActiveLearning.WF.Activity
{

    public sealed class CheckIfFileExists : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<Byte[]> HTTPPostedFileBytes { get; set; }
        public OutArgument<bool> IfFileExists { get; set; }
        public OutArgument<string> Message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            Byte[] hTTPPostedFileBytes = context.GetValue(this.HTTPPostedFileBytes);

            bool ifFileExists = false;
            string message = string.Empty;

            using (var contentManager = new ContentManager())
            {
                //ifFileExists = contentManager.CheckIfContentExists(hTTPPostedFile, out message);
                if (!ifFileExists)
                {
                    // message is from the contentmanager
                }
                else
                {
                    message = string.Empty;
                }
            }

            context.SetValue(this.IfFileExists, ifFileExists);
            context.SetValue(this.Message, message);
        }
    }
}
