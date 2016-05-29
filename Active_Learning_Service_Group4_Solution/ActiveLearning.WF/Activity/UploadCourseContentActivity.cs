using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Web;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;

namespace ActiveLearning.WF.Activity
{
    public sealed class UploadCourseContentActivity : CodeActivity
    {
        public InArgument<string> PhysicalUploadPath { get; set; }
        public InArgument<int> CourseSid { get; set; }
        public InArgument<HttpPostedFileBase> file { get; set; }


        public OutArgument<string> Message { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string physicalUploadPath = context.GetValue(this.PhysicalUploadPath);

            int courseSid = context.GetValue(this.CourseSid);

            HttpPostedFileBase file = context.GetValue(this.file);

            string message = string.Empty;

            using (var contentManager = new ContentManager())
            {
                var content = contentManager.AddContent(physicalUploadPath, file, courseSid, out message);
            }

            context.SetValue(this.Message, message);


        }
    }
}
