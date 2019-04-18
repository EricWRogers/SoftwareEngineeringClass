using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Terminal.Gui;


namespace QTerminal
{
    class UI
    {
       
        public static Test test;
        //initialize the application
        static void TakeTest()
        {
         
            test.STest = new StudentsTest();
            string holder = "";

            //Student id
            Console.WriteLine("Student Name");
            test.STest.Name = Console.ReadLine();
            Console.WriteLine("Student ID");
            test.STest.Id = Console.ReadLine();
            

            //get the test the user selected and display one question at a time
            for(int i = 0; i < test.HowManyQuestions();i++)
            {
                switch(test.Questions[i].Q_Type)
                {
                    case QTYPE.MultiChoice:
                        Console.WriteLine("MC question #"+i+test.Questions[i].Test_Question);
                        for(int t = 0; t < test.Questions[i].Answer.Length;t++)
                        {
                            Console.WriteLine( t +":" +test.Questions[i].Answer[t]);
                        }
                        test.STest.StudentAnswer.Add(test.Questions[i].Answer[Convert.ToInt32(Console.ReadLine())] );
                       
                        break;

                    case QTYPE.ShortAnswer:
                        Console.WriteLine("SA question #"+ i +":" +test.Questions[i].Test_Question);
                        holder = Console.ReadLine();
                        test.STest.StudentAnswer.Add(holder);
                        break;

                    case QTYPE.TF:
                        Console.WriteLine("TF question #"+ i +":" +test.Questions[i].Test_Question);
                        for(int t = 0; t < test.Questions[i].Answer.Length;t++)
                        {
                            Console.WriteLine(t + ": " + test.Questions[i].Answer[t]);
                        }
                        holder = "";
                        holder = Console.ReadLine();
                        int dfasdf = Convert.ToInt32(holder);
                        test.STest.StudentAnswer.Add(test.Questions[i].Answer[dfasdf] );
                        break;

                }

               
            }
            //save the test
            Model.SaveTest(test,"./StudentAnswer",test.TestName+test.STest.Name,"testAnswer");
            //press enter to move to next question
           
        }
        static void TestChange()
        {
            //get the test the user selected and display one question at a time 
            //press enter to move to next question
           
        }
        static void ChooseTest( string folder, string extinction )
        {   
            bool temp = true;
            int response;

            //get the tests 
            string[] testPath = Model.LoadAvailableTest(folder, extinction);
            string[] testNames = Model.LoadTestNames(testPath,folder, extinction);

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

            string[] lines = File.ReadAllLines( folder+ "/" + testNames[response] + "." + extinction);
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
                ChooseTest("./Test", "test");
                TakeTest();

                    break;

                case "Administrator":
                ChooseTest("./StudentAnswer", "testAnswer");
                TestChange();

                    break;

                default:

                Console.WriteLine("Error: Not a valid choice please try again!");
                    break;
            }
        }
    }
}



