using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SimpleC
{
    public class Glut32
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void glutDisplayFuncDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void glutReshapeFuncDelegate(int width, int height);

        // void glutInit(int *argcp, char **argv);
        [DllImport("freeglut.dll", CallingConvention = CallingConvention.Winapi), SuppressUnmanagedCodeSecurity]
        public static extern void glutInit(ref int argcp, String[] argv);

        // int glutCreateWindow(char *name);
        [DllImport("freeglut.dll", CallingConvention = CallingConvention.Winapi), SuppressUnmanagedCodeSecurity]
        public static extern int glutCreateWindow(String name);

        // void glutDisplayFunc(void (*func)(void));
        [DllImport("freeglut.dll", CallingConvention = CallingConvention.Winapi), SuppressUnmanagedCodeSecurity]
        public static extern void glutDisplayFunc(glutDisplayFuncDelegate func);

        // void glutReshapeFunc(void (*func)(int width, int height));
        [DllImport("freeglut.dll", CallingConvention = CallingConvention.Winapi), SuppressUnmanagedCodeSecurity]
        public static extern void glutReshapeFunc(glutReshapeFuncDelegate func);

        //void glutMainLoop(void);
        [DllImport("freeglut.dll", CallingConvention = CallingConvention.Winapi), SuppressUnmanagedCodeSecurity]
        public static extern void glutMainLoop();
    }
}
