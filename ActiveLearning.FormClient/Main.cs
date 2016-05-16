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
    public partial class Main : Form
    {
        StudentServiceClient client = new StudentServiceClient();

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var loginForm = new Login(client);
            DialogResult result = loginForm.ShowDialog();

            //if (result == DialogResult.Cancel)
            //{
            //    Dispose();
            //    return;
            //}

            if (result != DialogResult.OK)
            {
                return;
            }

            loginForm.Dispose();

            showCourseList();
        }

        private void showCourseList()
        {
            client.GetCoursesAsync();

        }

        private void showMenu()
        {
            
        }
        private void loginoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
            {
                try
                {
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

     
    }
}
