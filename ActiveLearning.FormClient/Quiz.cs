using ActiveLearning.FormClient.StudentService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveLearning.FormClient
{
    public partial class Quiz : Form
    {
        StudentServiceClient client;
        int courseSid;
        public Quiz(StudentServiceClient client, int courseSid)
        {
            this.client = client;
            this.courseSid = courseSid;
            InitializeComponent();
        }
    }
}
