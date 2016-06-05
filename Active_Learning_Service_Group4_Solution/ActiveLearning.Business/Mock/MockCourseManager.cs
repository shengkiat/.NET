using ActiveLearning.Business.Interface;
using ActiveLearning.DB;
using ActiveLearning.Repository;
using ActiveLearning.Repository.CustomExcepetion;
using ActiveLearning.Repository.Interface;
using ActiveLearning.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveLearning.Repository.Context;
using ActiveLearning.Common;
using System.Transactions;
using ActiveLearning.Business.Implementation;

namespace ActiveLearning.Business.Mock
{
    public class MockCourseManager : ICourseManager, IManagerFactoryBase<ICourseManager>
    {
        public MockCourseManager()
        {


        }

        public ICourseManager Create()
        {
            return this;
        }

        public void Dispose()
        {

        }

        #region Course Mock Data

        public IQueryable MockCourses { get; set; }

        public Course MockCourse { get; set; }


        #endregion

        #region Course
        public bool CourseNameExists(string courseName, out string message)
        {
            throw new NotImplementedException();
        }
        public Course GetCourseByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Course> GetAllCourses(out string message)
        {
            message = string.Empty;
            try
            {
                var mock = MockCourses as IEnumerable<Course>;
                if (mock == null || mock.Count() == 0)
                {
                    message = Constants.ValueNotFound(Constants.Course);
                }
                return mock;
            }
            catch (Exception ex)
            {
                message = Constants.OperationFailedDuringRetrievingValue(Constants.Course);
                return null;
            }
        }
        public Course AddCourse(Course course, out string message)
        {
            message = string.Empty;
            if (course == null)
            {
                message = Constants.ValueIsEmpty(Constants.Course);
                return null;
            }
            try
            {
                if (MockCourse == null)
                {
                    throw new Exception();
                }

                return MockCourse;
            }
            catch (Exception ex)
            {
                message = Constants.OperationFailedDuringAddingValue(Constants.Course);
                return null;
            }
        }
        public bool UpdateCourse(Course course, out string message)
        {
            throw new NotImplementedException();
        }
        public bool DeleteCourse(Course course, out string message)
        {
            throw new NotImplementedException();
        }
        public bool DeleteCourse(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Student Enrolment
        public IEnumerable<Student> GetEnrolledStudentsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetEnrolledStudentSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetEnrolledStudentUserSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();

        }
        public IEnumerable<Student> GetNonEnrolledStudentsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetNonEnrolledStudentSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetNonEnrolledStudentUserSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();

        }
        public IEnumerable<Course> GetEnrolledCoursesByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetEnrolledCourseSidsByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Course> GetNonEnrolledCoursesByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetNonEnrolledCourseSidsByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool EnrolStudentsToCourse(IEnumerable<Student> students, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool EnrolStudentsToCourse(IEnumerable<int> studentSids, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudentsFromCourse(IEnumerable<Student> students, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool RemoveStudentsFromCourse(IEnumerable<int> studentSids, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudentsCourseEnrolment(IEnumerable<Student> students, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool UpdateStudentsCourseEnrolment(IEnumerable<int> studentSids, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Instructor enrolment
        public IEnumerable<Instructor> GetEnrolledInstructorsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetEnrolledInstructorSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetEnrolledInstructorUserSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Instructor> GetNonEnrolledInstructorsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetNonEnrolledInstructorSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetNonEnrolledInstructorUserSidsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Course> GetEnrolledCoursesByInstructorSid(int InstructorSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetEnrolledCourseSidsByInstructorSid(int InstructorSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Course> GetNonEnrolledCoursesByInstructorSid(int InstructorSid, out string message)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<int> GetNonEnrolledCourseSidsByInstructorSid(int InstructorSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool EnrolInstructorsToCourse(IEnumerable<Instructor> Instructors, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool EnrolInstructorsToCourse(IEnumerable<int> InstructorSids, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool RemoveInstructorsFromCourse(IEnumerable<Instructor> Instructors, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool RemoveInstructorsFromCourse(IEnumerable<int> InstructorSids, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool UpdateInstructorsCourseEnrolment(IEnumerable<Instructor> Instructors, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }
        public bool UpdateInstructorsCourseEnrolment(IEnumerable<int> InstructorSids, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStudentsCourseEnrolmentByHasEnrolledIndicator(IEnumerable<Student> students, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInstructorsCourseEnrolmentByHasEnrolledIndicator(IEnumerable<Instructor> Instructors, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudentsWithHasEnrolledIndicatorByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instructor> GetAllInstructorsWithHasEnrolledIndicatorByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool IsCourseFullyEnrolled(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public int GetCourseAvailableQuota(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public StudentEnrollApplication AddStudentEnrollApplication(Student student, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetPendingStudentEnrollApplications(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool InstructorAcceptStudentEnrollApplication(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool InstructorRejectStudentEnrollApplication(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public StudentEnrollApplication AddStudentEnrollApplication(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool EnrolStudentToCourse(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllPendingStudentEnrollApplications(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetPendingStudentEnrollApplications(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetRejectedStudentEnrollApplications(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetApprovedStudentEnrollApplications(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetNonEnrolledNonPendingNonRejectedCoursesByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetNonEnrolledNonPendingNonRejectedCourseSidsByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllRejectedStudentEnrollApplications(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllAcceptedStudentEnrollApplications(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAcceptedStudentEnrollApplications(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllPendingStudentEnrollApplicationsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllRejectedStudentEnrollApplicationsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllAcceptedStudentEnrollApplicationsByCourseSid(int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllPendingStudentEnrollApplicationsByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllRejectedStudentEnrollApplicationsByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllAcceptedStudentEnrollApplicationsByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }

        public StudentEnrollApplication GetStudentEnrollApplicationsByStudentSidCourseSid(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetNonEnrolledNonAppliedCoursesByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetNonEnrolledNonAppliedCourseSidsByStudentSid(int studentSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool InstructorRejectStudentEnrollApplication(int studentSid, int courseSid, string remark, out string message)
        {
            throw new NotImplementedException();
        }

        public bool HasStudentEnrolledToCourse(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public StudentEnrollApplication GetStudentEnrollApplicationByStudentSidCourseSid(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool HasStudentAppliedCourse(int studentSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }

        public StudentEnrollApplication GetStudentEnrollApplicationBySidCourseSid(int enrollApplicationSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool InstructorAcceptStudentEnrollApplication(int enrollApplicationSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool InstructorRejectStudentEnrollApplication(int enrollApplicationSid, string remark, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllPendingStudentEnrollApplicationsByCourseSids(List<int> courseSids, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllRejectedStudentEnrollApplicationsByCourseSids(List<int> courseSids, out string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentEnrollApplication> GetAllAcceptedStudentEnrollApplicationsByCourseSids(List<int> courseSids, out string message)
        {
            throw new NotImplementedException();
        }

        public StudentEnrollApplication GetStudentEnrollApplicationBySid(int enrollApplicationSid, out string message)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfInstructorEnrolledCourse(int instructorSid, int courseSid, out string message)
        {
            throw new NotImplementedException();
        }



        #endregion

    }
}
