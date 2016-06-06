using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace ActiveLearning.WF.Activity
{

    public sealed class TestUpload : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<byte[]> Bytes { get; set; }
        public InArgument<string> FileName { get; set; }
        public OutArgument<String> Message { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            byte[] bytes = context.GetValue(this.Bytes);
            string fileName = context.GetValue(this.FileName);

            string message = "Well received. File Name: " + fileName + ", File Length:" + bytes.LongLength;

            context.SetValue(Message, message);
        }
    }
}
