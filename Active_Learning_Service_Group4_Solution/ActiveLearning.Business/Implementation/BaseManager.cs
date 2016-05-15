using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ActiveLearning.Common;

namespace ActiveLearning.Business.Implementation
{
    public class BaseManager : IDisposable
    {
      
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }


        public static void ExceptionLog(Exception ex)
        {
            Log.ExceptionLog(ex);
        }

        public static void ExceptionLog(string userLog, Exception ex)
        {
            Log.ExceptionLog(userLog, ex);
        }

        public static void InfoLog(string message)
        {
            Log.InfoLog(message);
        }

        public static void DebugLog(string message)
        {
            Log.DebugLog(message);
        }

        public static void ExceptionLog(string message)
        {
            Log.ExceptionLog(message);
        }
    }
}
