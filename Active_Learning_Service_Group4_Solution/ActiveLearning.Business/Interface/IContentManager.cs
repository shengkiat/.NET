using ActiveLearning.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ActiveLearning.Business.Interface
{
    public interface IContentManager : IDisposable
    {
        Content GetContentByContentSid(int contentSid, out string message);
        Content GetAcceptedContentByContentSid(int contentSid, out string message);
        Content GetCommentedContentByContentSid(int contentSid, out string message);
        Content GetRejectedContentByContentSid(int contentSid, out string message);
        IEnumerable<Content> GetAllContentsByCourseSid(int courseSid, out string message);
        IEnumerable<Content> GetPendingContentsByCourseSid(int courseSid, out string message);
        IEnumerable<Content> GetAcceptedContentsByCourseSid(int courseSid, out string message);
        IEnumerable<Content> GetCommentedContentsByCourseSid(int courseSid, out string message);
        IEnumerable<Content> GetRejectedContentsByCourseSid(int courseSid, out string message);
        IEnumerable<int> GetAllContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetPendingContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetAcceptedContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetCommentedContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetRejectedContentSidsByCounrseSid(int courseSid, out string message);
        String GetContentPathByContentSid(int contentSid, out string message);
        Content AddContent(Controller controller, HttpPostedFileBase file, int courseSid, out string message);
        //bool DeleteContent(Controller controller, Content conten, out string message);
        //bool DeleteContent(Controller controller, int contentSid, out string message);
        bool DeleteContent(string physicalFilePath, int contentSid, out string message);
    }
}
