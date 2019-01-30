using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedApplication
{
    class Program
    {
        // This attribute is only required for Shell32 example
        [STAThread]
        static void Main(string[] args)
        {
            var wrapper = new NativeLibraryWrapper();

            // C++/CLI wrapper
            wrapper.DisplayMessage("MessageBox invoked via C++/CLI", "Hello, world!");

            // Same work, using It Just Works
            NativeLibraryWrapper.MessageBox_(new System.IntPtr(0), "MessageBox using It Just Works", "Hello, world!", 0);

            // Open a shell explorer via using Microsoft Shell controls and Automation com object 
            var shellClass = new Shell32.Shell();
            shellClass.Open("");
        }
    }
}
