using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveLearning.DB;
using System.ComponentModel.DataAnnotations;
using ActiveLearning.Common;
using System.Runtime.Serialization;

namespace ActiveLearning.DB
{
    [MetadataType(typeof(CourseMetadata))]
    public partial class Course
    {
        [Display(Name = "Available Student Quota")]
        public int AvailableQuota { get; set; }

        [Display(Name = "Fully Enrolled")]
        public bool FullyEnrolled { get; set; }
    }
    public class CourseMetadata
    {
        [Required(ErrorMessage = Constants.Please_Enter + "Course Name")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = Constants.Please_Enter + "Total Student Quota")]
        [Range(0, int.MaxValue, ErrorMessage = Constants.Please_Enter + "A Positive Ingeter")]
        [Display(Name = "Student Quota")]
        public int StudentQuota { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Created Date")]
        public DateTime CreateDT { get; set; }

        [Display(Name = "Updated Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "-")]
        public DateTime? UpdateDT { get; set; }

        [Display(Name = "Deleted Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "-")]
        public DateTime? DeleteDT { get; set; }
    }
}
