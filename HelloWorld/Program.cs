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
