using System.Activities;
using System.Web;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;
using ActiveLearning.DB;
using System;
using System.Linq;
using System.IO;
namespace ActiveLearning.WF.Activity
{
    public sealed class InstructorUploadContent : CodeActivity
    {
        public InArgument<int> CourseSid { get; set; }
        public InArgument<Byte[]> FileBytes { get; set; }
        public InArgument<string> FileName { get; set; }
        public OutArgument<int> ContentSid { get; set; }
        public OutArgument<bool> ContentUploadedSuccessfully { get; set; }
        public OutArgument<string> ContentStatus { get; set; }
        public OutArgument<string> Message { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            int courseSid = context.GetValue(this.CourseSid);
            Byte[] fileBytes = context.GetValue(this.FileBytes);
            string fileName = context.GetValue(this.FileName);

            int contentSid = 0;
            bool contentUploadedSuccessfully = false;
            string message = string.Empty;
            string contentStatus = string.Empty;


            using (var contentManager = new ContentManager())
            {
                var uploadFolder = Util.GetUploadFolderFromConfig();

                int count = 0;
                while (uploadFolder.Contains("../"))
                {
                    uploadFolder = uploadFolder.Replace("../", string.Empty);
                    count++;
                }
                string path = System.Web.HttpContext.Current.Server.MapPath("~");
                DirectoryInfo dir = new DirectoryInfo(path);
                for (int i = 0; i < count; i++)
                {
                    path = dir.Parent.FullName;
                }
                if (!uploadFolder.StartsWith("/"))
                {
                    uploadFolder = "/" + uploadFolder;
                }
                path = path + uploadFolder;

               // uploadFolder = Util.GetUploadFolderFromConfig();


                var content = contentManager.AddContentWithoutData(path, fileName, fileBytes, out message);
                if (content == null)
                {
                    contentUploadedSuccessfully = false;
                    contentSid = 0;
                }
                else
                {
                    var newContent = contentManager.AddContent(content, courseSid, out message);
                    if (newContent == null || newContent.Sid == 0)
                    {
                        contentUploadedSuccessfully = false;
                        contentSid = 0;
                        // message from content manager
                    }
                    else
                    {
                        contentUploadedSuccessfully = true;
                        contentSid = content.Sid;
                        contentStatus = Constants.Pending_Description;
                        message = Constants.ValueSuccessfuly("Content has been uploaded") + ". It is now pending review";
                    }
                }
            }

            context.SetValue(this.ContentSid, contentSid);
            context.SetValue(this.ContentUploadedSuccessfully, contentUploadedSuccessfully);
            context.SetValue(this.ContentStatus, contentStatus);
            context.SetValue(this.Message, message);
        }
    }
}
