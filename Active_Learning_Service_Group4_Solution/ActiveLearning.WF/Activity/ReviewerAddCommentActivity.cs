using ActiveLearning.Business.Implementation;
using System.Activities;

namespace ActiveLearning.WF.Activity
{
    public sealed class ReviewerAddCommentActivity : CodeActivity
    {
        public InArgument<int> ContentSid { get; set; }
        public InArgument<string> Comment { get; set; }

        public OutArgument<string> Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int contentSid = context.GetValue(this.ContentSid);

            string comment = context.GetValue(this.Comment);

            string message = string.Empty;

            using (var contentManager = new ContentManager())
            {
                var content = contentManager.CommentContent(contentSid, comment, out message);
            }

            context.SetValue(this.Message, message);
        }
    }
}
