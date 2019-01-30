
# DotNetInterops
This is a collection of various sample projects associated to .net Interops:

* **C++/Cli**

*ManagedApplication* is a C# application, which will call **DisplayMessage** function, defined in *NativeLibrary* project, via C++/CLI

*NativeLibrary* is a pure C++ native static library project  (as opposed to a C++/CLI managed project). The main function is *DisplayMessage*, which invoke *MessageBox*:

    void NativeLibrary::DisplayMessage(const std::wstring & from, const std::wstring & message)
    {
        MessageBox(0, (LPCWSTR)message.c_str(), (LPCWSTR)from.c_str(), MB_OK);
    }

*NativeLibraryWrapper* is a C++/CLI managed dynamic library project, that is linked to *NativeLibrary* and taht is referenced in *ManagedApplication* application. There we can find an example of marshaling:

    void NativeLibraryWrapper::DisplayMessage(System::String^ from, System::String^ message)
    {
	    System::Console::WriteLine("NativeLibraryWrapper::DisplayMessage called");

	    // The native library function is:
	    // void DisplayMessage(const std::wstring& from, const std::wstring& message);
	    //
	    // We have to marshal System::String to std::wstring
	    // This can be easily done by:

	    auto nFrom = msclr::interop::marshal_as<std::wstring>(from);
	    auto nMessage = msclr::interop::marshal_as<std::wstring>(message);

	    this->p_NativeLibrary->DisplayMessage(nFrom, nMessage);
    }

This wrapper also contains the following function signature and implementation, illustrating a call to *MessageBox* using *It Just Works mechanism*

		static int MessageBox_(System::IntPtr hWnd, System::String^ text, System::String^ caption, unsigned int type);
		
There is also an example of creating a Runtime Callable Warpper to access COM services via using a reference to *Microsoft Shell controls and Automation*:

		// Open a shell explorer via using Microsoft Shell controls and Automation com object
		var shellClass = new Shell32.Shell();
		shellClass.Open("");


* **COM Object**

*OpenDialogBox* is a native C++ application, demonstrating how to consume a COM object. Original code can be found [there](https://docs.microsoft.com/en-us/windows/desktop/learnwin32/example--the-open-dialog-box).

*ManagedOpenDialogBox* is a managed C# application, doing the same job as *OpenDialogBox*.
*CustomCOMObject* is an example of COM object written in C#. 
*CustomCOMObjectClient* is a native C++ console application, using *CustomCOMObject*.

Please browse code to find usefull information. Some key points come into my mind. Both client and COM server must have the same bitness (in these examples, 64 bits). *CustomCOMObject* perform COM object registration, therefore you must launch Visual Studio as admin.

* **PInvoke**

*HelloWorld* is a C# console application, demonstrating how simple it can be to invoke a native function via Platform Invoke:

    using System;

    namespace HelloWorld
    {
        class Program
        {
            static void Main(string[] args)
            {
                var ret = (ushort)WinWrapper.PInvoke.MessageBox(
                    0,
                    "Hello World!",
                    "MessageBox invoked via PInvoke",
                   0);

                Console.WriteLine($"MessageBox has exited with {ret} value");
            }
       }
    }

* **WinWrapper**

Contains the **PInvoke** signature of **MessageBox**, defined in **user32.dll**:

    public static class PInvoke
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr MessageBox(int hWnd, String text,
        String caption, uint type);
    }
    
And also code heavily copied on [FileDialog.cs](https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/FileDialog.cs), used in **ManagedOpenDialogBox**, for easier invocation of **COM Object FileOpenDialog**. 