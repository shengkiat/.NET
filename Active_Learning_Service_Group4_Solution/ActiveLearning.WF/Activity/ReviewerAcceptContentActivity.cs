using ActiveLearning.Business.Implementation;
using System.Activities;

namespace ActiveLearning.WF.Activity
{
    public sealed class ReviewerAcceptContentActivity : CodeActivity
    {

        public InArgument<int> ContentSid { get; set; }

        public OutArgument<string> Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int contentSid = context.GetValue(this.ContentSid);

            string message = string.Empty;

            using (var contentManager = new ContentManager())
            {
                var content = contentManager.AcceptContent(contentSid, out message);
            }

            context.SetValue(this.Message, message);
        }
    }
}
