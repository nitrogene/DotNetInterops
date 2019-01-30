using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var wrapper = new NativeLibraryWrapper();

            wrapper.DisplayMessage("MessageBox invoked via C++/CLI", "Hello, world!");

            NativeLibraryWrapper.MessageBox_(new System.IntPtr(0), "MessageBox using It Just Works", "Hello, world!", 0);
        }
    }
}
