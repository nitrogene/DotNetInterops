using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagedApplication
{
    // Pure C# implementation of DisplayMessageInterface defined in NativeLibraryWrapper assembly
    class DisplayMessageInterfaceImpl : DisplayMessageInterface
    {
        public void DisplayMessage(string from, string message, out string answer)
        {
            MessageBox.Show(message, from);

            answer = "Job's done from DisplayMessageInterfaceImpl";
        }
    }

    class Program
    {
        // This attribute is only required for Shell32 example
        [STAThread]
        static void Main(string[] args)
        {
            using (var wrapper = new NativeLibraryWrapper())
            {
                // C++/CLI wrapper
                wrapper.DisplayMessage("MessageBox invoked via C++/CLI", "Hello, world!", out string answer);
                System.Console.WriteLine($"Display message has answered: {answer}");

                // Same work, using It Just Works
                NativeLibraryWrapper.MessageBox_(new System.IntPtr(0), "MessageBox using It Just Works", "Hello, world!", 0);

                // Open a shell explorer via using Microsoft Shell controls and Automation com object 
                var shellClass = new Shell32.Shell();
                shellClass.Open("");
            }

            MyStruct myStruct; // Defined in NativeLibraryWrapper assembly
            myStruct.from = "From Russia";
            myStruct.message = "Hello";

            System.Console.WriteLine($"{myStruct.message}, {myStruct.from}");
    }
    }
}
