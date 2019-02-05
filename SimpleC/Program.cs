using System.Text;

namespace SimpleC
{
    // https://www.opengl.org/archives/resources/code/samples/glut_examples/examples/simple.c
    // via Pinvoke
    class Program
    {
        static void reshape(int w, int h)
        {
            /* Because Gil specified "screen coordinates" (presumably with an
               upper-left origin), this short bit of code sets up the coordinate
               system to correspond to actual window coodrinates.  This code
               wouldn't be required if you chose a (more typical in 3D) abstract
               coordinate system. */

           OpenGL32.glViewport(0, 0, w, h);                                     /* Establish viewing area to cover entire window. */
           OpenGL32.glMatrixMode((uint)OpenGL32.MatrixMode.GL_PROJECTION);      /* Start modifying the projection matrix. */
           OpenGL32.glLoadIdentity();                                           /* Reset project matrix. */
           OpenGL32.glOrtho(0, w, 0, h, -1, 1);                                 /* Map abstract coords directly to window coords. */
           OpenGL32.glScalef(1, -1, 1);                                         /* Invert Y axis so increasing Y goes down. */
           OpenGL32.glTranslatef(0, -h, 0);                                     /* Shift origin up to upper-left corner. */
        }

       static  void display()
        {
            OpenGL32.glClear((uint)OpenGL32.AttribMask.GL_COLOR_BUFFER_BIT);
            OpenGL32.glBegin((uint)OpenGL32.BeginMode.GL_TRIANGLES);
            OpenGL32.glColor3f(0.0f, 0.0f, 1.0f);  /* blue */
            OpenGL32.glVertex2i(0, 0);
            OpenGL32.glColor3f(0.0f, 1.0f, 0.0f);  /* green */
            OpenGL32.glVertex2i(200, 200);
            OpenGL32.glColor3f(1.0f, 0.0f, 0.0f);  /* red */
            OpenGL32.glVertex2i(20, 200);
            OpenGL32.glEnd();
            OpenGL32.glFlush();  /* Single buffered, so needs a flush. */
        }   

        static void Main(string[] args)
        {
            var argc = args.Length;
            var argv = args;

            Glut32.glutInit(ref argc, argv);
            Glut32.glutCreateWindow("single triangle");
            Glut32.glutDisplayFunc(display);
            Glut32.glutReshapeFunc(reshape);
            Glut32.glutMainLoop();
        }
    }
}
