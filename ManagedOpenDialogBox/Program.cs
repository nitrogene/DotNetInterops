using System;
using WinWrapper;

namespace ManagedOpenDialogBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            var type = Type.GetTypeFromCLSID(new Guid(CLSIDGuid.FileOpenDialog), true);
            var fileOpen = (IFileDialog)Activator.CreateInstance(type);

            if (fileOpen != null)
            {
                var hr = fileOpen.Show(new IntPtr(0));
                if (hr >= 0)
                {
                    fileOpen.GetResult(out IShellItem pItem);
                    if (pItem!=null)
                    {
                        pItem.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out string pszFilePath);

                        if (!string.IsNullOrEmpty(pszFilePath))
                        {
                            var ret=PInvoke.MessageBox(0,pszFilePath,"File Path",0);
                            Console.WriteLine($"MessageBox has exited with {ret} value");
                        }
                    }
                }
            }

        }
    }
}
