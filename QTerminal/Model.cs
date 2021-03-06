﻿using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace QTerminal
{
    public class Test
    {
        public string key { get; set; }
        public string TestName { get; set; }
        public List<Question> Questions = new List<Question>();
        public StudentsTest STest = new StudentsTest();
        public void GradeTest()
        {
            Grade grade = new Grade();
            for(int q = 0; q < Questions.Count; q++)
            {
                Model.DebugSpace();
                Console.WriteLine("Question: " + Questions[q].Test_Question);
                switch( Questions[q].Q_Type )
                {
                    case QTYPE.TF:
                        for(int i = 0;i < Questions[q].C_Answers.Length;i++)
                        {
                            if(Questions[q].C_Answers[i] == 1)
                            {
                                Console.WriteLine(i+": " + Questions[q].Answer[i] + " Correct");
                                if(Questions[q].Answer[i] == STest.StudentAnswer[q])
                                {
                                    grade.TF_Correct++;
                                }
                            }
                            else{
                                Console.WriteLine(i+": " + Questions[q].Answer[i] + " Incorrect");
                                if(Questions[q].Answer[i] == STest.StudentAnswer[q])
                                {
                                    grade.TF_Wrong++;
                                }
                            }
                        }                        
                        Model.DebugSpace();
                        Console.WriteLine("Students Answer: " + STest.StudentAnswer[q]);
                        break;
                    case QTYPE.ShortAnswer:
                        Model.DebugSpace();
                        Console.WriteLine("Students Answer: " + STest.StudentAnswer[q]);
                        if("yes" == Model.CheckResponce("Is the answer acceptable?", new string[] {"yes", "no"}))
                        {
                            grade.ShortAnswer_Correct++;
                        }
                        else
                        {
                            grade.ShortAnswer_Wrong++;
                        }
                        break;
                    case QTYPE.MultiChoice:
                        for(int i = 0;i < Questions[q].C_Answers.Length;i++)
                        {
                            if(Questions[q].C_Answers[i] == 1)
                            {
                                Console.WriteLine(i+": " + Questions[q].Answer[i] + " Correct");
                                if(Questions[q].Answer[Questions[q].C_Answers[i]] == STest.StudentAnswer[q])
                                {
                                    grade.MultiChoice_Correct++;
                                }
                            }
                            else{
                                Console.WriteLine(i+": " + Questions[q].Answer[i] + " Incorrect");
                                if(Questions[q].Answer[Questions[q].C_Answers[i]] == STest.StudentAnswer[q])
                                {
                                    grade.MultiChoice_Wrong++;
                                }
                            }
                        }
                        Model.DebugSpace();
                        Console.WriteLine("Students Answer: " + STest.StudentAnswer[q]);
                        break;
                }
                
            }
            Console.WriteLine("grade.TF_Correct "+grade.TF_Correct);
            Console.WriteLine("grade.TF_Wrong "+grade.TF_Wrong);
            Console.WriteLine("grade.ShortAnswer_Correct "+grade.ShortAnswer_Correct);
            Console.WriteLine("grade.ShortAnswer_Wrong "+grade.ShortAnswer_Wrong);
            Console.WriteLine("grade.MultiChoice_Correct "+grade.MultiChoice_Correct);
            Console.WriteLine("grade.MultiChoice_Wrong "+grade.MultiChoice_Wrong);
            STest.Graded = true;
            STest.StudentGrade = grade;
        }
        #region QuestionHelper
        public void AddQuestionTF( string question, bool answer )
        {
            if(answer) { Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {1,0}}); }
            else { Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {0,1}}) ; }
        }
        public void AddQuestionShort( string question, string answer)
        {
            Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.ShortAnswer, Answer = new string[] { answer } });
        }
        public void AddQuestionMulti( string question, string[] answer, int[] correct )
        {
            Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.MultiChoice, Answer = answer, C_Answers = correct});
        }
        public void OverWriteQuestionTF( int location, string question, bool answer )
        {
            if(answer) { Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {1,0}}; }
            else { Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {0,1}} ; }
        }
        public void OverWriteQuestionShort( int location, string question, string answer)
        {
            Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.ShortAnswer, Answer = new string[] { answer } };
        }
        public void OverWriteQuestionMulti( int location, string question, string[] answer, int[] correct )
        {
            Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.MultiChoice, Answer = answer, C_Answers = correct};
        }
        public int HowManyQuestions()
        {
            return Questions.Count;
        }
        public Question GetQuestionByLocation(int location)
        {
            return Questions[location];
        }
        public void AddAnswerTF( string question, bool answer )
        {
            if(answer) { Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {1,0}}); }
            else { Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {0,1}}) ; }
        }
        public void AddAnswerShort( string question, string answer)
        {
            Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.ShortAnswer, Answer = new string[] { answer } });
        }
        public void AddAnswerMulti( string question, string[] answer, int[] correct )
        {
            Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.MultiChoice, Answer = answer, C_Answers = correct});
        }
        public void OverWriteAnswerTF( int location, string question, bool answer )
        {
            if(answer) { Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {1,0}}; }
            else { Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.TF, Answer = new string[] { "true", "false" } , C_Answers = new int[] {0,1}} ; }
        }
        public void OverWriteAnswerShort( int location, string question, string answer)
        {
            Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.ShortAnswer, Answer = new string[] { answer } };
        }
        public void OverWriteAnswerMulti( int location, string question, string[] answer, int[] correct )
        {
            Questions[location] = new Question{ Test_Question = question, Q_Type = QTYPE.MultiChoice, Answer = answer, C_Answers = correct};
        }
        #endregion
    }
    public class StudentsTest
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool Graded = false;
        public List<string> StudentAnswer = new List<string>();
        public Grade StudentGrade = new Grade();
    }
    public class Question
    {
        public string Test_Question { get; set; }
        public QTYPE Q_Type { get; set; }
        public string[] Answer { get; set; }
        public int[] C_Answers { get; set; }
    }
    public class Grade{
        public int TF_Correct { get; set; }
        public int TF_Wrong { get; set; }
        public int ShortAnswer_Correct { get; set; }
        public int ShortAnswer_Wrong { get; set; }
        public int MultiChoice_Correct { get; set; }
        public int MultiChoice_Wrong  { get; set; }
    }

    public enum QTYPE { TF, ShortAnswer, MultiChoice };
    public enum USER { Teacher, Student };
    public class Model
    {
        #region ModelValue
        public static bool devMode = false;
        #endregion
        #region IO
        /// <summary>
        /// Return's the full test path for all the test's in directory dir with the file extension fileEx
        /// </summary>
        /// <param name="dir">The folder path to store the Test</param>
        /// <param name="fileEx">The Test file extension</param>
        public static string[] LoadAvailableTest ( string dir, string fileEx )
        {
            String[] TestPack = {"Error"};
            try
            {
                // Only get files that end file extention .test
                TestPack = Directory.GetFiles(dir, "*." + fileEx);
                DebugLog("The number of files ending with ." + fileEx +" is " + TestPack.Length);
                foreach (string test in TestPack)
                {
                    DebugLog(test);
                }
                return TestPack;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                Console.WriteLine("No Test were found");
                return TestPack;
            }
        }
        /// <summary>
        /// Return's a Test Object from a json string
        /// </summary>
        /// <param name="json"></param>
        public static Test LoadTest( string json )
        {
            return JsonConvert.DeserializeObject<Test>( json );
        } 
        /// <summary>
        /// Saving the Test in json format in the dir/fileName.fileEx
        /// </summary>
        /// <param name="test">Test Object to be saved</param>
        /// <param name="dir">The folder path to store the Test</param>
        /// <param name="fileName">The test name's excluding the path and file extension</param>
        /// <param name="fileEx">The Test file extension</param>
        public static void SaveTest ( Test test, string dir, string fileName, string fileEx)
        {
            try
            {
                string newFileName = fileName.Replace(" ", "_");
                string json = JsonConvert.SerializeObject(test);
                System.IO.File.WriteAllText(dir + "/" + newFileName + "." + fileEx, json);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                Console.WriteLine("Error saving test");
            }
        }
        /// <summary>
        /// Return a string[] of just the test name's excluding the path and file extension
        /// </summary>
        /// <param name="testFileNames">List of all test name</param>
        /// <param name="dirName">The folder path to store the Test</param>
        /// <param name="extension">The Test file extension</param>
        public static string[] LoadTestNames(string[] testFileNames, string dirName, string extension)
        {
            string[] newFileNames = testFileNames;
            for (int i = 0; i < testFileNames.Length;i++)
            {
                newFileNames[i] = testFileNames[i].Substring(dirName.Length + 1, testFileNames[i].Length - dirName.Length - extension.Length - 2);
            }
            return newFileNames;
        }
        /// <summary>
        /// An Folder making function
        /// </summary>
        /// <param name="FolderName">Name of the folder to be made</param>
        public static bool makeFolder( string FolderName)
        {
            try
            {
                System.IO.Directory.CreateDirectory("./" + FolderName);
                DebugLog("New Folder: " + FolderName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process makeFolder failed: {0}", e.ToString());
                return false;
            }
        }
        /// <summary>
        /// Returns an users response to a question in to form of a string
        /// </summary>
        /// <param name="Question"></param>
        public static string CheckString( string Question )
        {
            bool loopControl = true;
            string response = "";

            while(loopControl)
            {
                Console.WriteLine(" ");
                Console.WriteLine(Question);

                // Read the user response
                response = Console.ReadLine();

                // TODO: add checking for / and ~
                if(response.Length > 0)
                {
                    loopControl = false;
                }
                else
                {
                    Console.WriteLine("Not A Valid Choise. Please Try Again");
                }
            }

            return response;
        }
        /// <summary>
        /// A robust CheckResponce function that insurse the user enters an acceptable response
        /// </summary>
        /// <param name="Question">Question for user to respond to</param>
        /// <param name="possible">An array of possible responses</param>
        public static string CheckResponce(string Question, string[] possible)
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
                int point;
                if(int.TryParse(response , out point)){
                    Model.DebugLog("point: " + point + " possible.Length" + possible.Length);
                    if( -1 < point && point < possible.Length)
                    {
                        response = possible[point];
                        loopControl = false;
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a number");
                }

                if(loopControl)
                {
                    Console.WriteLine("Not A Valid Choise. Please Try Again");
                }
            }

            return response;
        }
        /// <summary>
        /// A writeline for debug only and should not be visible in public releases
        /// </summary>
        /// <param name="Message">Debug message</param>
        public static void DebugLog( string Message)
        {
            if(devMode)
            {
                Console.WriteLine(Message);
            }
        }
        /// <summary>
        /// Add's a new empty line
        /// </summary>
        public static void DebugSpace()
        {
            Console.WriteLine(" ");
        }
        #endregion
        /// <example> 
        /// This sample shows how to call the these ModelHelper.
        /// <code>
        /// static void Main(string[] args)
        /// {
        ///     // Set Dev Mode
        ///     // Dev Mode will enable functions that are usfull for testing
        ///     // Should only be set true while in testing
        ///     devMode = true;
        /// 
        ///     // Make the Folders
        ///     makeFolder("Test");
        ///     makeFolder("StudentAnswer");
        /// 
        ///     // Load String[] of Test filepaths
        ///     LoadAvailableTest("./Test", "test");
        ///     LoadAvailableTest("./StudentAnswer", "testAnswer");
        /// 
        ///     // Making test object
        ///     // This will not be done here in the future
        ///     Test test = new Test();
        ///     test.key = "Eric";
        ///     test.TestName = "SE_Test_01";
        ///     test.AddQuestionTF( "How height is tall", true );
        ///     test.AddQuestionShort( "How height is tall", "very tall");
        ///     test.AddQuestionMulti( "How height is tall", new string[]{"very tall", "very much tall"}, new int[]{1,0});
        /// 
        ///     // Convert test object into json string
        ///     string json = JsonConvert.SerializeObject( test );
        /// 
        ///     // Printing json string
        ///     DebugLog(json);
        /// 
        ///     // Test Saving file
        ///     System.IO.File.WriteAllText("./Test/" + test.TestName + ".test", json);
        /// 
        ///     // Saving test data to file in test folder
        ///     SaveTest(test, "./Test", "SE_Test_02", "test");
        /// 
        ///     // Load an array of file paths as string
        ///     // Cycle through them 
        ///     // Print the json
        ///     foreach( string t in LoadAvailableTest("./Test", "test") )
        ///     {
        ///         string[] lines = File.ReadAllLines(@t);
        ///         DebugLog(lines[0]);
        ///     }
        /// }
        /// </code>
        /// </example>
    }
}
