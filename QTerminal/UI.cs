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
            Rect mainRect =  new Rect(0,1,top.Frame.Width,top.Frame.Height-1);
            var win = new Window(mainRect,"Class Test Application");
            top.Add(win);

            bool studentPressed = false;
            bool teacherPressed = false;
            var student = new Button(7,14,"Student")
            {
                Clicked = () => {   studentPressed = true; }
            };
            var teacher = new Button(7,14,"Teacher")
            {
                Clicked = () => {  teacherPressed = true; }
            };
            var dialog = new Dialog("Selection", 60, 7, student, teacher);
            win.Add(dialog);
            //var testView = new ListView(new Rect(4, 8, top.Frame.Width, 200), MovieDataSource.GetList(forKidsOnly.Checked, 0).ToList());
            //var testView = new ListView(new Rect(4, 8, top.Frame.Width, 200), MovieDataSource.GetList(forKidsOnly.Checked, 0).ToList());


            if(studentPressed)
            {
            win.Remove(dialog);
            win.Redraw(mainRect);
            //win.Add();
            }

            if(teacherPressed)
            {
            win.Remove(dialog);
            win.Redraw(mainRect);
            //win.Add();
            }
             Application.Run ();
        }
    }
}


