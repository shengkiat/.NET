using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using ActiveLearning.Business.Implementation;
using ActiveLearning.Common;
using ActiveLearning.DB;
using System.Linq;
using ActiveLearning.Web.Filter;
using System.Web.SessionState;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ActiveLearning.Web.Controllers
{
    [CustomAuthorize(Roles = ActiveLearning.Common.Constants.User_Role_Student_Code)]
    public class StudentController : BaseController
    {
        #region Index

        public ActionResult Index()
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }
            return View();
        }
        #endregion

        #region course
        [OutputCache(Duration = Cache_Duration)]
        public ActionResult CourseList()
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }

            string message = string.Empty;
            using (var courseManager = new CourseManager())
            {
                var courseList = courseManager.GetEnrolledCoursesByStudentSid(GetLoginUser().Students.FirstOrDefault().Sid, out message);
                if (courseList == null || courseList.Count() == 0)
                {
                    SetViewBagError(message);
                }
                return View(courseList);
            }
        }


        [OutputCache(Duration = Cache_Duration)]
        public ActionResult NewCourseList()
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }

            string message = string.Empty;
            using (var courseManager = new CourseManager())
            {
                var nonEnroledCourseList = courseManager.GetNonEnrolledNonAppliedCoursesByStudentSid(GetLoginUser().Students.FirstOrDefault().Sid, out message);
                if (nonEnroledCourseList == null || nonEnroledCourseList.Count() == 0)
                {
                    SetViewBagError(message);
                }
                else
                {
                    GetErrorAneMessage();
                }
                return View(nonEnroledCourseList);
            }
        }
        public ActionResult RequestToEnrollCourse(int courseSid)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }
            string message = string.Empty;

            int studentSid = GetLoginUser().Students.FirstOrDefault().Sid;
            int enrollApplicationSid = 0;
            bool enrolledCourseSuccesfully = false;
            bool appliedCourseSuccesfully = false;
            using (CourseEnrollService.ServiceClient client = new CourseEnrollService.ServiceClient())
            {
                try
                {
                    message = client.StudentRequestToEnrollCourse(ref studentSid, ref courseSid, out enrollApplicationSid, out appliedCourseSuccesfully, out enrolledCourseSuccesfully);
                }
                catch (Exception ex)
                {
                    ExceptionLog(ex);
                    SetTempDataError(Common.Constants.OperationFailedDuringCallingValue("course enrollment workflow service"));
                    return RedirectToAction("NewCourseList");
                }
                if(!enrolledCourseSuccesfully && !appliedCourseSuccesfully)
                {
                    SetTempDataError(message);
                    return RedirectToAction("NewCourseList");
                }
            }
            SetTempDataMessage(message);
            return RedirectToAction("NewCourseList");
        }
        #endregion

        #region chat
        public ActionResult Chat(int courseSid)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }
            string message = string.Empty;
            if (!HasAccessToCourse(courseSid, out message))
            {
                return RedirectToError(message);
            }
            var claims = new List<Claim>();


            claims.Add(new Claim(ClaimTypes.GroupSid, courseSid.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, GetLoginUser().FullName));

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties()
            {
                //ExpiresUtc = DateTime.UtcNow.(200),
                IsPersistent = true
            }, identity);

            using (var chatManager = new ChatManager())
            {
                var chatHistory = chatManager.GetChatHistoryByCourseSid(courseSid, out message);
                ViewBag.CourseSid = courseSid;
                ViewBag.StudentSid = GetLoginUser().Students.FirstOrDefault().Sid;
                SetBackURL("courselist");
                return View(chatHistory);
            }
        }
        #endregion

        #region quiz
        [OutputCache(Duration = Cache_Duration)]
        public ActionResult Quiz(int courseSid)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }
            string message = string.Empty;
            if (!HasAccessToCourse(courseSid, out message))
            {
                return RedirectToError(message);
            }

            using (var quizManager = new QuizManager())
            {
                var allQuizs = quizManager.GetActiveQuizQuestionsByCourseSid(courseSid, out message);
                if (allQuizs == null || allQuizs.Count() == 0)
                {
                    SetViewBagError(message);
                }
                ViewBag.CourseSid = courseSid;
                SetBackURL("courselist");
                return View(allQuizs);
            }
        }
        #endregion

        #region content
        [OutputCache(Duration = Cache_Duration)]
        public ActionResult Content(int courseSid)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }
            string message = string.Empty;
            if (!HasAccessToCourse(courseSid, out message))
            {
                return RedirectToError(message);
            }

            List<Content> items = new List<Content>();
            using (var contentManager = new ContentManager())
            {
                message = string.Empty;
                var contents = contentManager.GetAcceptedContentsByCourseSid(courseSid, out message);
                if (contents != null)
                {
                    items = contents.ToList();
                }
                else
                {
                    SetViewBagError(message);
                }
            }
            ViewBag.CourseSid = courseSid;
            SetBackURL("courselist");
            return View(items);
        }

        public ActionResult Download(int courseSid, int contentSid, string originalFileName)
        {
            if (!IsUserAuthenticated())
            {
                return RedirectToLogin();
            }
            string message = string.Empty;
            if (!HasAccessToCourse(courseSid, out message))
            {
                return RedirectToError(message);
            }
            string filepath;
            string fileType;
            using (var contentManager = new ContentManager())
            {
                var content = contentManager.GetAcceptedContentByContentSid(contentSid, out message);
                if (content == null)
                {
                    return RedirectToError(message);
                }
                filepath = content.Path + content.FileName;
                fileType = content.Type;
            }
            var file = File(filepath, System.Net.Mime.MediaTypeNames.Application.Octet, originalFileName);
            if (file == null)
            {
                return RedirectToError(ActiveLearning.Common.Constants.ValueNotFound(ActiveLearning.Common.Constants.File));
            }
            if (fileType.Equals(ActiveLearning.Common.Constants.Content_Type_Video))
            {
                ViewBag.VideoPath = filepath;
                SetBackURL("Content?courseSid=" + courseSid);
                return View("Video");
            }
            else if (fileType.Equals(ActiveLearning.Common.Constants.Content_Type_File))
            {
                return file;
            }
            return null;
        }
        #endregion
    }
}