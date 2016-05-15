using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActiveLearning.FormClient.StudentService;
using System.ServiceModel;

namespace ActiveLearning.FormClient
{
    public partial class Form1 : Form
    {
        StudentServiceClient client;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPass.Text.Trim();

            using (client = new StudentServiceClient())
            {
                try
                {
                    client.ClientCredentials.UserName.UserName = userName;
                    client.ClientCredentials.UserName.Password = password;
                    //await client.ValidateAsync(userName, password);
 

                }
                catch (FaultException FE)
                {
                    //throw FE;
                    MessageBox.Show(FE.Message);
                }
            }
        }

        private void Client_ValidateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show(e.ToString());

            MessageBox.Show("Validation completed");
        }
    }
}
