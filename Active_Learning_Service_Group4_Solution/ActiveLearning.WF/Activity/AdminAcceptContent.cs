using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;
using System.Activities;

namespace ActiveLearning.WF.Activity
{
    public sealed class AdminAcceptContent : CodeActivity
    {
        public InArgument<int> ContentSid { get; set; }

        public OutArgument<bool> AcceptedSuccessfully { get; set; }
        public OutArgument<string> ContentStatus { get; set; }
        public OutArgument<string> Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int contentSid = context.GetValue(this.ContentSid);

            bool acceptedSuccessfully = false;
            string message = string.Empty;
            string contentStatus = string.Empty;

            using (var contentManager = new ContentManager())
            {
                acceptedSuccessfully = contentManager.AcceptContent(contentSid, out message);
                if(!acceptedSuccessfully)
                {
                    // messagr from manager
                    contentStatus = Constants.Pending_Description;
                }
                else
                {
                    acceptedSuccessfully = true;
                    contentStatus = Constants.Accepted_Description;
                    message = Constants.ValueSuccessfuly("Content has been accepted");
                }
            }

            context.SetValue(this.AcceptedSuccessfully, acceptedSuccessfully);
            context.SetValue(this.ContentStatus, contentStatus);
            context.SetValue(this.Message, message);
        }
    }
}
