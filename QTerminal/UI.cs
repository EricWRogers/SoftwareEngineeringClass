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
                if(test.Questions[i].Q_Type == QTYPE.ShortAnswer)
                {
                    Console.WriteLine("SA question #"+ i +":" +test.Questions[i].Test_Question);
                    holder = Console.ReadLine();
                    test.STest.StudentAnswer.Add(holder);
                }else{
                    test.STest.StudentAnswer.Add(CheckResponce(test.Questions[i].Test_Question, test.Questions[i].Answer));
                }
            }
            // Save the test
            Model.SaveTest(test,"./StudentAnswer",test.TestName+test.STest.Name,"testAnswer");
        }
        static void TestChange()
        {
            string holder = "";
            string answer;
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

                            Console.WriteLine("Do you want to change this question: Y/N");
                            answer = Console.ReadLine();
                            if( answer == "y" || answer == "Y" )
                            {
                                
                            }
                            else
                            {

                            }
                        }
                        Console.WriteLine("");                       
                        break;

                    case QTYPE.ShortAnswer:
                        Console.WriteLine("SA question #"+ i +":" +test.Questions[i].Test_Question);

                         Console.WriteLine("Do you want to change this question: Y/N");
                            answer = Console.ReadLine();
                            if( answer == "y" || answer == "Y" )
                            {
                                
                            }
                            else
                            {

                            }

                        Console.WriteLine("");  
                        break;

                    case QTYPE.TF:
                        Console.WriteLine("TF question #"+ i +":" +test.Questions[i].Test_Question);
                        for(int t = 0; t < test.Questions[i].Answer.Length;t++)
                        {
                            Console.WriteLine(t + ": " + test.Questions[i].Answer[t]);

                            Console.WriteLine("Do you want to change this question: Y/N");
                            answer = Console.ReadLine();
                            if( answer == "y" || answer == "Y" )
                            {
                                
                            }
                            else
                            {

                            }
                        }
                        Console.WriteLine("");  
                        break;

                }
            //press enter to move to next question
           
        }
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
        static string CheckResponce(string Question, string[] possible)
        {
            bool loopControl = true;
            string response = "";

            while(loopControl)
            {
                Console.WriteLine("");
                Console.WriteLine(Question);
                
                // Print answer choices
                for(int i = 0; i < possible.Length; i++)
                {
                    Console.WriteLine(i + ": " + possible[i]);
                }

                // Read the user response
                response = Console.ReadLine();
                int point = Convert.ToInt32(response);
                Model.DebugLog("point: " + point + " possible.Length" + possible.Length);
                if( -1 < point && point < possible.Length)
                {
                    //if(String.Equals(possible[point] , possible[i], StringComparison.CurrentCultureIgnoreCase))
                    response = possible[point];
                    loopControl = false;
                }

                if(loopControl)
                {
                    Console.WriteLine("Not A Valid Choise. Please Try Again");
                }
            }

            return response;
        }
        static void Main(string[] args)
        {
            Model.devMode = true;
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
                /* ??ask question to either grade or change a test
                
                //Grade....ChooseTest("./StudentAnswer", "testAnswer");
                Change A test*/
                ChooseTest("./Test", "test");
                TestChange();

                    break;

                default:

                Console.WriteLine("Error: Not a valid choice please try again!");
                    break;
            }
        }
    }
}



