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
    public partial class ShowCourseForm : Form
    {
        public ShowCourseForm()
        {
            InitializeComponent();


            List<StudentService.Course> a = new List<StudentService.Course>();

            a.Add(new StudentService.Course { CourseName = "asd" });


            a.ToList();

            dataGridView1.DataSource = a;


        }
    }
}
