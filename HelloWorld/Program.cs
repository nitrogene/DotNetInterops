using System;
using System.Runtime.InteropServices;

public class Win32
{
    public class Type
    {
        public const ulong MB_ABORTRETRYIGNORE= 0x00000002L;
        public const ulong MB_CANCELTRYCONTINUE = 0x00000006L;
        public const ulong MB_HELP = 0x00004000L;
        public const ulong MB_OK = 0x00000000L;
        public const ulong MB_OKCANCEL = 0x00000001L;
        public const ulong MB_RETRYCANCEL = 0x00000005L;
        public const ulong MB_YESNO = 0x00000004L;
        public const ulong MB_YESNOCANCEL = 0x00000003L;

        public const ulong MB_ICONEXCLAMATION = 0x00000030L;
        public const ulong MB_ICONWARNING = 0x00000030L;
        public const ulong MB_ICONINFORMATION = 0x00000040L;
        public const ulong MB_ICONASTERISK = 0x00000040L;
        public const ulong MB_ICONQUESTION = 0x00000020L;
        public const ulong MB_ICONSTOP = 0x00000010L;
        public const ulong MB_ICONERROR = 0x00000010L;
        public const ulong MB_ICONHAND = 0x00000010L;

        public const ulong MB_DEFBUTTON1 = 0x00000000L;
        public const ulong MB_DEFBUTTON2 = 0x00000100L;
        public const ulong MB_DEFBUTTON3 = 0x00000200L;
        public const ulong MB_DEFBUTTON4 = 0x00000300L; 

        public const ulong MB_APPLMODAL = 0x00000000L;
        public const ulong MB_SYSTEMMODAL = 0x00001000L;
        public const ulong MB_TASKMODAL = 0x00002000L;
        public const ulong MB_DEFAULT_DESKTOP_ONLY = 0x00020000L;
        public const ulong MB_RIGHT = 0x00080000L;
        public const ulong MB_RTLREADING = 0x00100000L;
        public const ulong MB_SETFOREGROUND = 0x00010000L;
        public const ulong MB_TOPMOST = 0x00040000L;
        public const ulong MB_SERVICE_NOTIFICATION = 0x00200000L;
    }

    public class ReturnType
    {
        public const ushort IDOK=1;
        public const ushort IDCANCEL=2;
        public const ushort IDABORT=3;
        public const ushort IDRETRY=4;
        public const ushort IDIGNORE=5;
        public const ushort IDYES=6;
        public const ushort IDNO=7;
        public const ushort IDTRYAGAIN=10;
        public const ushort IDCONTINUE =11;
    }



    // Please see the following link for full description of MessageBox API
    // https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox
    //
    // In the following example, we have the following type mapping
    //
    //                          unmanaged                   managed
    // return value            int                         IntPtr
    // hWnd                    HWND                        int
    // lpText                  LPCTSTR                     String
    // lpCaption               LPCTSTR                     String
    // uType                   UINT                        uint
    //
    // The full map is avaiable there:
    // https://docs.microsoft.com/en-us/dotnet/framework/interop/marshaling-data-with-platform-invoke

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr MessageBox(int hWnd, String text,
                    String caption, uint type);


}

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var ret=(ushort)Win32.MessageBox(
                0, 
                "Hello World!", 
                "MB_ABORTRETRYIGNORE", 
                (uint)(Win32.Type.MB_ABORTRETRYIGNORE|  Win32.Type.MB_DEFBUTTON1)
                );

            switch(ret)
            {
                case Win32.ReturnType.IDOK:
                    Console.WriteLine("The OK button was selected.");
                    break;

                case Win32.ReturnType.IDCANCEL:
                    Console.WriteLine("The Cancel button was selected.");
                    break;

                case Win32.ReturnType.IDABORT:
                    Console.WriteLine("The Abort button was selected.");
                    break;

                case Win32.ReturnType.IDRETRY:
                    Console.WriteLine("The Retry button was selected.");
                    break;

                case Win32.ReturnType.IDIGNORE:
                    Console.WriteLine("The Ignore button was selected.");
                    break;

                case Win32.ReturnType.IDYES:
                    Console.WriteLine("The Yes button was selected.");
                    break;

                case Win32.ReturnType.IDNO:
                    Console.WriteLine("The No button was selected.");
                    break;

                case Win32.ReturnType.IDTRYAGAIN:
                    Console.WriteLine("The Try Again button was selected.");
                    break;

                case Win32.ReturnType.IDCONTINUE:
                    Console.WriteLine("The Continue button was selected.");
                    break;
            }
        }
    }
}
