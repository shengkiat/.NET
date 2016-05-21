using ActiveLearning.FormClient.StudentService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveLearning.FormClient
{
    public partial class Main : Form
    {
        StudentServiceClient client = new StudentServiceClient();

        CourseDTO[] courses;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;

            //client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;

            var loginForm = new Login(client);
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            DialogResult result = loginForm.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            loginForm.Dispose();

            showCourseList();
        }

        private async void showCourseList()
        {
            try
            {
                courses = await client.GetCoursesAsync();
                LblMessage.Text = "My Courses";
                courseDTOBindingSource.DataSource = courses;
                dataGridView1.MultiSelect = false;

                DataGridViewLinkColumn links = new DataGridViewLinkColumn();
                links.UseColumnTextForLinkValue = true;
                links.HeaderText = "Course Material";
                links.DataPropertyName = "Sid";
                links.ActiveLinkColor = Color.White;
                links.LinkBehavior = LinkBehavior.SystemDefault;
                links.LinkColor = Color.Blue;
                links.TrackVisitedState = true;
                links.VisitedLinkColor = Color.Blue;
                links.Text = "Course Material";
                links.FillWeight = 20;
                links.Name = "LbtnCourseMaterial";
                dataGridView1.Columns.Add(links);

                links = new DataGridViewLinkColumn();
                links.UseColumnTextForLinkValue = true;
                links.HeaderText = "Quiz";
                links.DataPropertyName = "Sid";
                links.ActiveLinkColor = Color.White;
                links.LinkBehavior = LinkBehavior.SystemDefault;
                links.LinkColor = Color.Blue;
                links.TrackVisitedState = true;
                links.VisitedLinkColor = Color.Blue;
                links.Text = "Quiz";
                links.FillWeight = 20;
                links.Name = "LbtnQuiz";
                dataGridView1.Columns.Add(links);

            }
            catch (FaultException fe)
            {
                LblMessage.Text = fe.Message;
                return;
            }
            catch (Exception ex)
            {
                LblMessage.Text = ex.Message;
                return;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Load(sender, e);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // material
            if (e.ColumnIndex == 2)
            {
                var courseMaterial = new CourseMaterial(client, courses[e.RowIndex].Sid);
                courseMaterial.StartPosition = FormStartPosition.CenterScreen;
                courseMaterial.ShowDialog();
            }
            // quiz
            else if (e.ColumnIndex == 3)
            {
                var quiz = new Quiz(client, courses[e.RowIndex].Sid);
                quiz.StartPosition = FormStartPosition.CenterScreen;
                quiz.ShowDialog();
            }
        }
    }
}
