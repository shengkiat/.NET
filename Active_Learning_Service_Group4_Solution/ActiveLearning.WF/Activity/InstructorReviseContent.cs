using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using ActiveLearning.DB;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;
using System.IO;

namespace ActiveLearning.WF.Activity
{

    public sealed class InstructorReviseContent : CodeActivity
    {
        public InArgument<int> ContentSid { get; set; }
        public InArgument<Byte[]> FileBytes { get; set; }
        public InArgument<string> FileName { get; set; }
        public OutArgument<bool> RevisedSuccessfully { get; set; }
        public OutArgument<string> ContentStatus { get; set; }
        public OutArgument<string> Message { get; set; }


        protected override void Execute(CodeActivityContext context)
        {
            int contentSid = context.GetValue(this.ContentSid);
            Byte[] fileBytes = context.GetValue(this.FileBytes);
            string fileName = context.GetValue(this.FileName);

            bool revisedSuccessfully = false;
            string message = string.Empty;
            string contentStatus = string.Empty;

            using (var contentManager = new ContentManager())
            {
                var oldContent = contentManager.GetContentByContentSid(contentSid, out message);
                if (oldContent == null || oldContent.Sid == 0)
                {
                    revisedSuccessfully = false;
                    context.SetValue(this.RevisedSuccessfully, revisedSuccessfully);
                    context.SetValue(this.ContentStatus, contentStatus);
                    context.SetValue(this.Message, message);

                    return;
                }

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

                bool oldFileDeleted = contentManager.DeleteContentWithouData(path + oldContent.FileName, out message);

                if (!oldFileDeleted)
                {
                    // LOG message                     
                }

                var newContent = contentManager.AddContentWithoutData(path, fileName, fileBytes, out message);
                if (newContent == null)
                {
                    revisedSuccessfully = false;
                    context.SetValue(this.RevisedSuccessfully, revisedSuccessfully);
                    context.SetValue(this.ContentStatus, contentStatus);
                    context.SetValue(this.Message, message);

                    return;
                }

                newContent.Sid = oldContent.Sid;
                newContent.CourseSid = oldContent.CourseSid;
                newContent.CreateDT = oldContent.CreateDT;
                newContent.Remark = oldContent.Remark;

                revisedSuccessfully = contentManager.ReviseContent(newContent, out message);
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
