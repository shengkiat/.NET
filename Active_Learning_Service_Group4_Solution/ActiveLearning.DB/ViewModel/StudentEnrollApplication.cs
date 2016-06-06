using ActiveLearning.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveLearning.DB
{
    [MetadataType(typeof(StudentEnrollApplicationMetadata))]
    public partial class StudentEnrollApplication
    {
        public string StatusDescription
        {
            get
            {
                switch (Status)
                {
                    case Constants.Pending_Code:
                        return Constants.Pending_Description;
                    case Constants.Accepted_Code:
                        return Constants.Accepted_Description;
                    case Constants.Rejected_Code:
                        return Constants.Rejected_Description;
                    default:
                        return Constants.UnknownValue(Constants.Status);
                }
            }
        }
    }
    public class StudentEnrollApplicationMetadata
    {
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Created Date")]
        public DateTime CreateDT { get; set; }

        [Display(Name = "Updated Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "-")]
        public DateTime? UpdateDT { get; set; }

        [Display(Name = "Deleted Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "-")]
        public DateTime? DeleteDT { get; set; }

        [DisplayFormat(NullDisplayText = "-")]
        public string Remark { get; set; }
    }
}
