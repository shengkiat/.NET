using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.DB;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;

namespace ActiveLearning.WF.Activity
{

    public sealed class InstructorReviseContentData : CodeActivity
    {
        public InArgument<Content> Content { get; set; }
        public OutArgument<bool> RevisedSuccessfully { get; set; }
        public OutArgument<string> ContentStatus { get; set; }
        public OutArgument<string> Message { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            Content content = context.GetValue(this.Content);

            bool revisedSuccessfully = false;
            string message = string.Empty;
            string contentStatus = string.Empty;

            using (var contentManager = new ContentManager())
            {
                revisedSuccessfully = contentManager.ReviseContent(content, out message);
                if (!revisedSuccessfully)
                {
                    // message from content manager
                }
                else
                {
                    revisedSuccessfully = true;
                    contentStatus = Constants.Pending_Description;
                    message = Constants.ValueSuccessfuly("Content Data has been revised") + ". It is now pending review";
                }
            }

            context.SetValue(this.RevisedSuccessfully, revisedSuccessfully);
            context.SetValue(this.ContentStatus, contentStatus);
            context.SetValue(this.Message, message);
        }
    }
}
