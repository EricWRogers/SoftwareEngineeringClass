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
       
        public Test test;
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
            bool temp = true;
            int response;

            //get the tests 
            string[] testPath = Model.LoadAvailableTest("./Test", "test");
            string[] testNames = Model.LoadTestNames(testPath,"./Test", "test");

            //display the test
            for(int i = 0; i < testNames.Length;i++)
            {
                Console.WriteLine(i + ": " + testNames[i]);
            }

            //let user choose the test
            response = Convert.ToInt32(Console.ReadLine());
            


            while(temp)
            {
                if(response >= 0 && response < testNames.Length)
                {
                    temp = false;
                }
                else
                {
                    Console.WriteLine("Not A Valid Choice. Please Try Again");
                }
            }

            string[] lines = File.ReadAllLines(testPath[response]);
            test = Model.LoadTest(lines[0]);
        }
        static string CheckResponce(string Question, string possible1, string possible2)
        {
            bool temp = true;
            string response;
            string responseHolder = "";

            while(temp)
            {
                Console.WriteLine(Question);
                response = Console.ReadLine();

                if(String.Equals(response , possible1, StringComparison.CurrentCultureIgnoreCase))
                {
                    responseHolder = possible1;
                    temp = false;
                }
                else if(String.Equals(response , possible2, StringComparison.CurrentCultureIgnoreCase))
                {
                    responseHolder = possible2;
                    temp = false;
                }
                else
                {
                    Console.WriteLine("Not A Valid Choise. Please Try Again");
                }
            }

            return responseHolder;
        }
        static void Main(string[] args)
        {
            //CheckResponce("Welcome to the Testing Center\nAre You a Student or Administrator", "Student", "Admin");

            Console.WriteLine("Welcome to the Testing Center");
            Console.WriteLine("Are You a Student or Administrator");
            string response = Console.ReadLine();
            switch(response)
            {
                case "Student":
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



