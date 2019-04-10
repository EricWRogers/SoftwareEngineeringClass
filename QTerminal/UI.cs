using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Terminal.Gui;

namespace testDotNet
{
    class UI
    {
                        
    
        static void Main(string[] args)
        {
            //initialize the application
            Application.Init ();
            var top = Application.Top;

            var win = new Window(new Rect(0,1,top.Frame.Width,top.Frame.Height-1),"Class Test Application");
            top.Add(win);

            bool studentPressed = false;
            bool teacherPressed = false;
            var student = new Button(7,14,"Student")
            {
                Clicked = () => { new Window(new Rect(0,1,top.Frame.Width,top.Frame.Height-1),"test");  studentPressed = true; }
            };
            var teacher = new Button(7,14,"Teacher")
            {
                Clicked = () => { win.Clear();  teacherPressed = true; }
            };
            var dialog = new Dialog("Selection", 60, 7, student, teacher);
            win.Add(dialog);


             Application.Run ();
             Console.WriteLine("Student"+studentPressed);
             Console.WriteLine("Teacher"+teacherPressed);
        }
    }
}


