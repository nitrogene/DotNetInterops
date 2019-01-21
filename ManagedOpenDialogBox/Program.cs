using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//ftp://ftp.oreilly.com/examples/9780596527570/COMIntegrationC%23Nutshell2ndEd.pdf
namespace ManagedOpenDialogBox
{
    public class Program
    {
        [DllImport("shlwapi.dll")]
        internal static extern int IUnknown_QueryService(IntPtr pUnk, ref Guid guidService, ref Guid riid, out IntPtr ppvOut);


        static void Main(string[] args)
        {
            Guid g = new Guid("000214F1-0000-0000-C000-000000000046"); // SID_SExplorerBrowserFrame
            Guid g2 = new Guid("d57c7288-d4ad-4768-be02-9d969532d960"); // IFileOpenDialog

            IntPtr pp;
            int rrc = Win32.IUnknown_QueryService(pUnkSite, ref g, ref g2, out pp);

            FileDialogNative.IFileOpenDialog dlg = Marshal.GetObjectForIUnknown(pp) as FileDialogNative.IFileOpenDialog;
            Marshal.Release(pp);
        }
    }
}
