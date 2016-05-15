using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ActiveLearning.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost svcHost = null;
            try
            {
                // Run VS in Admin Mode!!!

                svcHost = new ServiceHost(typeof(ActiveLearning.Services.StudentService));
                svcHost.Open();
                Console.WriteLine("\n\nService is Running  at following address");
                Console.WriteLine("\n" + svcHost.BaseAddresses[0]);
                Console.ReadKey();
            }
            catch (Exception eX)
            {
                svcHost = null;
                Console.WriteLine("Service can not be started \n\nError Message [" + eX.Message + "]");
                Console.ReadKey();
            }
            if (svcHost != null)
            {
                Console.WriteLine("\nPress any key to close the Service");
                Console.ReadKey();
                svcHost.Close();
                svcHost = null;
            }
















        }
    }
}
