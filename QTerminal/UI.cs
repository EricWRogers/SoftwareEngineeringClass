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
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        static void TestChange()
        {
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folder">Used to indicate status.</param>
        /// <param name="extinction">Used to indicate status.</param>
        /// <param name="user">Used to indicate status.</param>
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
        /// <summary>
        /// 
        /// </summary>
        static void MakeTest()
        {
            bool makeingTest = true;
            string question = "";
            string[] answer = {"","","",""};
            int[] correct = {0,0,0,0};
            int[] correctBackup = {0,0,0,0};

            // Reset Test data
            test = new Test();

            // Set Test Name
            test.TestName = Model.CheckString("Test Name");
            // Set Test Key
            test.key = Model.CheckString("Test Key");

            while(makeingTest)
            {
                switch(Model.CheckResponce("Test Menu",new string[]{"TF","ShortAnswer","Multible Choice","Save&Exit"}))
                {
                    case "TF":
                        test.AddQuestionTF(Model.CheckString("Enter Question"),("true"==Model.CheckResponce("Enter Answer", new string[] {"true","false"})));
                        break;
                    case "ShortAnswer":
                        test.AddQuestionShort(Model.CheckString("Enter Question"), Model.CheckString("Enter Answer"));
                        break;
                    case "Multible Choice":
                        question = Model.CheckString("Enter Question");
                        answer = new string[]{
                            Model.CheckString("Enter Answer #0 "),
                            Model.CheckString("Enter Answer #1 "),
                            Model.CheckString("Enter Answer #2 "),
                            Model.CheckString("Enter Answer #3 ")
                        };
                        correct = correctBackup;
                        string correctAnswer = Model.CheckResponce("Which answer is correct",answer);
                        for(int i = 0;i < answer.Length; i++)
                        {
                            if(answer[i] == correctAnswer)
                            {
                                    correct[i] = 1;
                            }
                        }

                        test.AddAnswerMulti(question,answer,correct);
                        break;
                    case "Save&Exit":
                        makeingTest = false;
                        break;
                }
            }

            // Save Test
            Model.SaveTest(test,"./Test",test.TestName,"test");
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
                                Model.SaveTest(test,"./StudentAnswer",test.TestName+test.STest.Name,"testAnswer");
                            }
                            else
                            {

                            }
                            break;
                        case "New Test":
                            MakeTest();
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