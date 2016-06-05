using System.Activities;
using System.Web;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;
using ActiveLearning.DB;

namespace ActiveLearning.WF.Activity
{
    public sealed class InstructorSaveContentData : CodeActivity
    {
        public InArgument<int> CourseSid { get; set; }
        public InArgument<Content> Content { get; set; }

        public OutArgument<int> ContentSid { get; set; }
        public OutArgument<bool> ContentDataSavedSuccessfully { get; set; }
        public OutArgument<string> ContentStatus { get; set; }
        public OutArgument<string> Message { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            int courseSid = context.GetValue(this.CourseSid);
            Content content = context.GetValue(this.Content);

            int contentSid = 0;
            bool contentDataSavedSuccessfully = false;
            string message = string.Empty;
            string contentStatus = string.Empty;

            using (var contentManager = new ContentManager())
            {
                var newContent = contentManager.AddContent(content, courseSid, out message);
                if (newContent == null || newContent.Sid == 0)
                {
                    contentDataSavedSuccessfully = false;
                    contentSid = 0;
                    // message from content manager
                }
                else
                {
                    contentDataSavedSuccessfully = true;
                    contentSid = content.Sid;
                    contentStatus = Constants.Pending_Description;
                    message = Constants.ValueSuccessfuly("Content Data has been saved") + ". It is now pending review";
                }
            }

            context.SetValue(this.ContentSid, contentSid);
            context.SetValue(this.ContentDataSavedSuccessfully, contentDataSavedSuccessfully);
            context.SetValue(this.ContentStatus, contentStatus);
            context.SetValue(this.Message, message);
        }
    }
}
