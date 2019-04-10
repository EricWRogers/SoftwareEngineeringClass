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
        static void main()
        {
            Application.Init();
            var top = Application.Top;

            var win = new Window ("MyApp") 
            {
                X = 0,
                Y = 1, // Leave one row for the toplevel menu
                // By using Dim.Fill(), it will automatically resize without manual intervention
                Width = Dim.Fill (),
	            Height = Dim.Fill ()
            };





        }
    }


}