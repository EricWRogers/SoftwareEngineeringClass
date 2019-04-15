using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace testDotNet
{

    class Test
    {
        public string key { get; set; }
        public string TestName { get; set; }
        public List<Question> Questions = new List<Question>();
        public StudentsTest STest = new StudentsTest();
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
            Questions.Add( new Question{ Test_Question = question, Q_Type = QTYPE.MultiChoise, Answer = answer, C_Answers = correct});
        }
        public int HowManyQuestions()
        {
            return Questions.Count;
        }
        public Question GetQuestionByLocation(int location)
        {
            return Questions[location];
        }
        #endregion
    }
    class StudentsTest
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string StudentAnswer { get; set; }
    }
    class Question
    {
        public string Test_Question { get; set; }
        public QTYPE Q_Type { get; set; }
        public string[] Answer { get; set; }
        public int[] C_Answers { get; set; }
    }
    enum QTYPE { TF, ShortAnswer, MultiChoise };
    class Model
    {
        #region ModelValue
        private static bool devMode = false;
        #endregion
        #region IO
        public static string[] LoadAvailableTest ( string dir, string fileEx )
        {
            String[] TestPack = {"Error"};
            try
            {
                // Only get files that end file extention .test
                TestPack = Directory.GetFiles(dir, "*." + fileEx);
                MessageLog("The number of files ending with ." + fileEx +" is " + TestPack.Length);
                foreach (string test in TestPack)
                {
                    MessageLog(test);
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
        /* public static void SaveTest ( Test test, string file)
        {
            try
            {
                string json = JsonConvert.SerializeObject(test);
                System.IO.File.WriteAllText(file, json);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                Console.WriteLine("Error saving test");
            }
        }*/
        public static void SaveTest ( Test test, string dir, string fileName, string fileEx)
        {
            try
            {
                test.TestName = fileName;
                string json = JsonConvert.SerializeObject(test);
                System.IO.File.WriteAllText(dir + "/" + fileName + "." + fileEx, json);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                Console.WriteLine("Error saving test");
            }
        }
        private static bool makeFolder( string FolderName)
        {
            try
            {
                System.IO.Directory.CreateDirectory("./" + FolderName);
                MessageLog("New Folder: " + FolderName);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("The process makeFolder failed: {0}", e.ToString());
                return false;
            }
        }
        public static void MessageLog( string Message)
        {
            if(devMode)
            {
                Console.WriteLine(Message);
            }
        }
        #endregion
        static void Main(string[] args)
        {
            // Set Dev Mode
            // Dev Mode will enable functions that are usfull for testing
            // Should only be set true while in testing
            devMode = true;

            // Make the Folders
            makeFolder("Test");
            makeFolder("StudentAnswer");

            // Load String[] of Test filepaths
            LoadAvailableTest("./Test", "test");
            LoadAvailableTest("./StudentAnswer", "testAnswer");

            // Making test object
            // This will not be done here in the future
            Test test = new Test();
            test.key = "Eric";
            test.TestName = "SE_Test_01";
            test.AddQuestionTF( "How height is tall", true );
            test.AddQuestionShort( "How height is tall", "very tall");
            test.AddQuestionMulti( "How height is tall", new string[]{"very tall", "very much tall"}, new int[]{1,0});

            // Convert test object into json string
            string json = JsonConvert.SerializeObject( test );

            // Printing json string
            MessageLog(json);

            // Test Saving file
            System.IO.File.WriteAllText("./Test/" + test.TestName + ".test", json);

            // Saving test data to file in test folder
            SaveTest(test, "./Test", "SE_Test_02", "test");

            // Load an array of file paths as string
            // Cycle through them 
            // Print the json
            foreach( string t in LoadAvailableTest("./Test", "test") )
            {
                string[] lines = File.ReadAllLines(@t);
                MessageLog(lines[0]);
            }
        }//*/
    }
}
