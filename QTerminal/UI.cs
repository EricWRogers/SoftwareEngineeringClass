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
                    test.STest.StudentAnswer.Add(Model.CheckResponce(test.Questions[i].Test_Question, test.Questions[i].Answer));
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
        static bool ChooseTest( string folder, string extinction, USER user )
        {
            string response = "";

            //get the tests 
            string[] testPath = Model.LoadAvailableTest(folder, extinction);
            if(testPath.Length > 0)
            {
                string[] testNames = Model.LoadTestNames(testPath,folder, extinction);

                //let user choose the test
                response = Model.CheckResponce("Choose a test", testNames);

                string[] lines = File.ReadAllLines( folder+ "/" + response + "." + extinction);
                test = Model.LoadTest(lines[0]);
                if(user == USER.Student)
                {
                    TakeTest();
                }
                return true;
            }
            else
            {
                Console.WriteLine("No file in folder: " + folder + "of type *." + extinction);
                return false;
            }
        }
        static void Main(string[] args)
        {
            Model.devMode = true;
            //CheckResponce("Welcome to the Testing Center\nAre You a Student or Administrator", "Student", "Admin");

            Console.WriteLine("Welcome to the Testing Center");
            switch(Model.CheckResponce("Which user type are you?",new string[]{"Student","Teacher"}))
            {
                case "Student":
                ChooseTest("./Test", "test", USER.Student);
                    break;

                case "Teacher":
                    switch(Model.CheckResponce("Welcome back Teacher",new string[]{"Grade","New Test","Edit Test"}))
                    {
                        case "Grade":
                            if(ChooseTest("./StudentAnswer", "testAnswer", USER.Teacher))
                            {
                                test.GradeTest();
                            }
                            else
                            {

                            }
                            break;
                        case "New Test":
                            break;
                        case "Edit Test":
                            ChooseTest("./Test", "test", USER.Teacher);
                            break;
                    }
                    break;
                default:

                Console.WriteLine("Error: Not a valid choice please try again!");
                    break;
            }
        }
    }
}



