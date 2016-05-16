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
    public partial class Form1 : Form
    {
        StudentServiceClient client;

        public Form1()
        {
            InitializeComponent();

            ShowCourseForm frm = new ShowCourseForm();
            frm.Show();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPass.Text.Trim();

            using (client = new StudentServiceClient())
            {
                try
                {
                    //client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.None;
                    //client.ClientCredentials.UserName.UserName = userName;
                    //client.ClientCredentials.UserName.Password = password;
                    //await client.ValidateAsync(userName, password);
                    client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.PeerTrust;
                    client.Login(userName, password);
                    var isAuthenticated = client.IsAuthenticated();

                    MessageBox.Show(isAuthenticated.ToString());
                }
                catch (MessageSecurityException MSE)
                {
                    MessageBox.Show(MSE.InnerException.Message);
                }
                catch (FaultException FE)
                {
                    //throw FE;
                    MessageBox.Show(FE.Message);
                }
                catch (Exception EX)
                {
                    //throw FE;
                    MessageBox.Show(EX.Message);
                }
                finally
                {
                    try
                    {
                        client.Close();
                    }
                    catch (CommunicationObjectFaultedException COE)
                    {

                    }
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
