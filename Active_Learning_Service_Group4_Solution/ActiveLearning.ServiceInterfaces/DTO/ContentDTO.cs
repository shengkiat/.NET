using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveLearning.ServiceInterfaces.DTO
{
    public class ContentDTO
    {
        public int Sid { get; set; }
        public int CourseSid { get; set; }
        public string Type { get; set; }
        public string OriginalFileName { get; set; }
        public System.DateTime CreateDT { get; set; }
        public Nullable<System.DateTime> UpdateDT { get; set; }
        public Nullable<System.DateTime> DeleteDT { get; set; }
    }
}
