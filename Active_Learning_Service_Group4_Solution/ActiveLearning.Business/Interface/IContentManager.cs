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
        IEnumerable<Content> GetAllPendingContents(out string message);
        IEnumerable<int> GetAllContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetPendingContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetAcceptedContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetCommentedContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetRejectedContentSidsByCounrseSid(int courseSid, out string message);
        IEnumerable<int> GetAllPendingContentSids(out string message);
        String GetContentPathByContentSid(int contentSid, out string message);
        Content AddContent(string physicalUploadPath, HttpPostedFileBase file, int courseSid, out string message);
        Content AddContent(Content content, int courseSid, out string message);
        Content AddContentWithoutData(string physicalUploadPath, HttpPostedFileBase file, out string message);
        bool CheckIfContentExists(HttpPostedFileBase file, out string message);
        bool CheckIfContentValid(HttpPostedFileBase file, out string message);
        bool DeleteContent(string physicalFilePath, int contentSid, out string message);
        bool DeleteContentWithouData(string physicalFilePath, out string message);
        bool UpdateContent(Content content, out string message);
        bool ReviseContent(Content content, out string message);
        bool UpdateContentStatus(int contentSid, string status, string remark, out string message);
        bool AcceptContent(Content content, out string message);
        bool AcceptContent(int contentSid, out string message);
        bool CommentContent(Content content, out string message);
        bool CommentContent(int contentSid, string remark, out string message);
    }
}
