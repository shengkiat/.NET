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
        StudentServiceClient client;

        public Login(StudentServiceClient client)
        {
            this.client = client;
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPass.Text.Trim();
            bool login = false;
            try
            {
                login = await client.LoginAsync(userName, password);
            }
            catch (FaultException fe)
            {
                MessageBox.Show(fe.Message);
                return;
            }
            catch (MessageSecurityException mse)
            {
                MessageBox.Show(mse.InnerException.Message);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (login)
            {
                DialogResult = DialogResult.OK;
            }
        }

    }
}
