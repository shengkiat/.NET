using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;
using System.Activities;

namespace ActiveLearning.WF.Activity
{
    public sealed class AdminCommentContent : CodeActivity
    {
        public InArgument<int> ContentSid { get; set; }
        public InArgument<string> Remark { get; set; }
        public OutArgument<bool> CommentedSuccessfully { get; set; }
        public OutArgument<string> ContentStatus { get; set; }
        public OutArgument<string> Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int contentSid = context.GetValue(this.ContentSid);
            string remark = context.GetValue(this.Remark);

            bool commentedSuccessfully = false;
            string message = string.Empty;
            string contentStatus = string.Empty;

            using (var contentManager = new ContentManager())
            {
                commentedSuccessfully = contentManager.CommentContent(contentSid, remark, out message);
                if (!commentedSuccessfully)
                {
                    // messagr from manager
                    contentStatus = Constants.Pending_Description;
                }
                else
                {
                    commentedSuccessfully = true;
                    contentStatus = Constants.Commented_Description;
                    message = Constants.ValueSuccessfuly("Content has been commented");
                }
            }

            context.SetValue(this.CommentedSuccessfully, commentedSuccessfully);
            context.SetValue(this.ContentStatus, contentStatus);
            context.SetValue(this.Message, message);
        }
    }
}
