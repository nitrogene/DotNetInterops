using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomCOMObject
{
    // You have to set a new GUID. You may use https://www.guidgenerator.com/online-guid-generator.aspx
    // And don't forget to set com visibility
    // You can check in project build properties "Register for COM interop" so that the resulting dll is automatically registered, 
    // provided that you have launch Visual Studio with admin rights
    // This can also be manually done via RegAsm.exe CustomCOMObject.dll /tlb, in a Visual Studio command prompt (with admin rights)
    // That will create the CustomCOMObject.tlb

    [Guid("364C5E66-4412-48E3-8BD8-7B2BF09E8922")]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ISaySomething
    {
        [DispId(1)]  void Greet(string name);
    }

    [Guid("eb46cc30-3039-446a-9908-d43120168c61")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ISaySomething))]
    [ComVisible(true)]
    public class SaySomething : ISaySomething
    {
        public void Greet(string name)
        {
            MessageBox.Show("Hello", name, MessageBoxButtons.OK);
        }
    }
}
