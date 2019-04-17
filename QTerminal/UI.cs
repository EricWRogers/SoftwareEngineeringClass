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
        public static void Init()
        {
            Console.WriteLine("Welcome to the Testing Center");
        }

        void CheckResponceStart(string response)
        {
            if(response != "Student" || response != "Admin")
            {

            }
        }
        static void Main(string[] args)
        {
            Init();
        }
    }
}


