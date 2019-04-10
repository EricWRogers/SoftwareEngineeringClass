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
            Application.Init ();
            var menu = new MenuBar (new MenuBarItem [] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_Quit", "", () => { 
                        Application.RequestStop (); 
                    })
                }),
            });

            var win = new Window ("Hello") {
                X = 0,
                Y = 1,
                Width = Dim.Fill (),
                Height = Dim.Fill () - 1
            };

            // Add both menu and win in a single call
            Application.Top.Add (menu, win);
            Application.Run ();
    }
}
}


