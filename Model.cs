using System;  
using System.IO;  
using System.Collections;
using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;  
//using System.Xml.Serialization; 
using System.Collections.Generic;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;
//using System.Runtime.Serialization.Formatters;
//using System.Runtime.Serialization.Formatters.Binary;


namespace testDotNet
{
    class StudentsTestCopy
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string TestName { get; set; }
        public List<string> Question = new List<string>();
        public List<string[]> Answer = new List<string[]>();
        public List<string[]> StudentAnswer = new List<string[]>();
    }
    class Test
    {
        public string key { get; set; }
        public string TestName { get; set; }
        public List<string> Question = new List<string>();
        public List<string[]> Answer = new List<string[]>();
    }

    


    class Model
    {
        #region ClassValue
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
        public void SaveGoldCopy ()
        {

        }
        public void SaveStudentCopy ()
        {

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
        private static void MessageLog( string Message)
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
            LoadAvailableTest("./Test", "test");
            LoadAvailableTest("./StudentAnswer", "testAnswer");


            

            MessageLog("Hello World!, from Eric");

            Test test = new Test();
            test.key = "Eric";
            test.TestName = "SE_Test_01";
            test.Question.Add("How heigh is tall?");
            test.Answer.Add(new string[] {"Very tall"});

            string json = JsonConvert.SerializeObject(test);

            MessageLog(json);
            // Test Saving file
            System.IO.File.WriteAllText("./Test/" + test.TestName + ".test", json);
            // Test Loading Test
            foreach( string t in LoadAvailableTest("./Test", "test") )
            {
                string[] lines = File.ReadAllLines(@t);
                MessageLog(lines[0]);
            }

            //StudentsTestCopy playerCopy = JsonConvert.DeserializeObject<StudentsTestCopy>(json);
            //json = JsonConvert.SerializeObject(playerCopy);
            //MessageLog(json);
        }
    }
}
