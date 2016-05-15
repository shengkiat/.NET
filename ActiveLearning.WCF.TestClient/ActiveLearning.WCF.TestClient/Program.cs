using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace ActiveLearning.WCF.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            StudentSvcRef.StudentServiceClient studentClient = new StudentSvcRef.StudentServiceClient();

            studentClient.ClientCredentials.UserName.UserName = "Donnie Yen";
            studentClient.ClientCredentials.UserName.Password = "soomro";
            studentClient.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =X509CertificateValidationMode.None;


            studentClient.GetCoursesWithStudentSid();







        }
    }
}
