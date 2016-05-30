using ActiveLearning.FormClient.StudentService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveLearning.FormClient
{
    public partial class CourseMaterial : Form
    {
        StudentServiceClient client;
        int courseSid;
        ContentDTO[] contents;
        ContentDTO content;
        byte[] contentBytes;
        public CourseMaterial(StudentServiceClient client, int courseSid)
        {
            this.client = client;
            this.courseSid = courseSid;
            InitializeComponent();
        }

        private async void CourseMaterial_Load(object sender, EventArgs e)
        {
            try
            {
                contents = await client.GetContentsByCourseSidAsync(courseSid);
                contentDTOBindingSource.DataSource = contents;
            }
            catch (FaultException fe)
            {
                MessageBox.Show(fe.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private async void DownloadContents()
        {
            try
            {
                Stream st = await client.DownloadFileStreamAsync(content.Sid);

                contentBytes = GetBytesFromStream(st);

                saveFileDialog1.FileName = content.OriginalFileName;
                DialogResult result = saveFileDialog1.ShowDialog();
                string path = saveFileDialog1.FileName;

                if (result != DialogResult.OK)
                    return;

                File.WriteAllBytes(path, contentBytes);
                MessageBox.Show("File save at  " + path);

            }
            catch (FaultException fe)
            {
                MessageBox.Show(fe.Message);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private byte[] GetBytesFromStream(Stream st)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = st.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                content = contents[e.RowIndex];
                DownloadContents();
            }
        }
    }
}
