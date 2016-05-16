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
using System.ServiceModel.Security;

namespace ActiveLearning.FormClient
{
    public partial class Login : Form
    {
        StudentServiceClient _client;

        public Login(StudentServiceClient client)
        {
            _client = client;
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPass.Text.Trim();

            try
            {
                await _client.LoginAsync(userName, password);
            }
            catch (FaultException FE)
            {
                MessageBox.Show(FE.Message);
                return;
            }
            catch (MessageSecurityException MSE)
            {
                MessageBox.Show(MSE.InnerException.Message);
                return;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                return;
            }

            DialogResult = DialogResult.OK;
        }
   
    }
}
