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

        //initialize the application
        static void TakeTest()
        {
            //get the test the user selected and display one question at a time
            //press enter to move to next question
           
        }
        static void TestChange()
        {
            //get the test the user selected and display one question at a time 
            //press enter to move to next question
           
        }
        static void ChooseTest()
        {
            //get the tests 
            //display the test
            //let user choose the test
        }

        string CheckResponce(string Question, string response, string possible1, string possible2)
        {
            bool temp = true;
            string responseHolder = "";

            while(temp)
            {
                Console.WriteLine(Question);
                response = Console.ReadLine();

                if(String.Equals(response , possible1, StringComparison.CurrentCultureIgnoreCase))
                {
                    responseHolder = possible1;
                }
                else if(String.Equals(response , possible2, StringComparison.CurrentCultureIgnoreCase))
                {
                    responseHolder = possible2;
                }
                else
                {
                    Console.WriteLine("Not A Valid Chouse. Please Try Again");
                }
            }

            return responseHolder;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Testing Center");
            Console.WriteLine("Are You a Student or Administrator");
            string response = Console.ReadLine();
            switch(response)
            {
                case "student":
                ChooseTest();
                TakeTest();

                    break;

                case "Administrator":
                ChooseTest();
                TestChange();
                    break;

                default:

                Console.WriteLine("Error: Not a valid choice please try again!");
                    break;
            }
        }
    }
}



