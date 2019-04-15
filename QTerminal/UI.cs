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

        
        static void Main(string[] args)
        {
            //initialize the application
            Application.Init();
            var top = Application.Top;
            Rect mainRect = new Rect(0, 1, top.Frame.Width, top.Frame.Height - 1);
            var mainWin = new Window(mainRect, "Class Test Application");
            var studentWin = new Window(mainRect, "Test Selection");
            var studentTakeWin = new Window(mainRect, "Test");
            var teacherWin = new Window(mainRect, "Test Creation");
            top.Add(mainWin);
           
            var nameStudent = new Label (3, 2, "Student Name: ");
            var nameStudentTxt = new TextField (17, 2, 40, "");
            var student = new Button(7, 14, "Student");
            var teacher = new Button(7, 14, "Teacher");
            String buttonString = "Next";
            var nextScn = new Button(80, 10, buttonString);
            var dialog = new Dialog("Selection", 60, 7, student, teacher);

            mainWin.Add(dialog);
            
            //var testView = new ListView(new Rect(4, 8, top.Frame.Width, 200), MovieDataSource.GetList(forKidsOnly.Checked, 0).ToList());



            student.Clicked = () =>
            {
                top.Remove(mainWin);
                top.Add(studentWin);
                //load tests available;

                string dirName = "./Test";
                string extension = "test";
                string chosenTest;
                string[] testFileNames = Model.LoadAvailableTest(dirName, extension);

                int i = 0;
                foreach (String test in testFileNames)
                {
                    string testName = test.Substring(dirName.Length + 1, test.Length - dirName.Length - extension.Length - 2);
                    // Console.WriteLine(testName);
                    Button button = new Button(5, 2 + (i * 2), testName);
                    
                    button.Clicked += () =>
                    {
                        
                        string jsonData = File.ReadAllText(test);
                        Test testObj = JsonConvert.DeserializeObject<Test>(jsonData);
                        chosenTest = testObj.TestName;
                           
                        studentWin.RemoveAll();
                        studentWin.Add(nameStudent,nameStudentTxt,nextScn);

                        nextScn.Clicked += () => 
                        {

                        if(!string.IsNullOrEmpty(nameStudentTxt.Text.ToString()))
                        {
                            //funciton to save students name to folder
                        }
                            studentWin.RemoveAll();
                        };
                        //Funtion to display the funcitons
                        /* 
                        foreach (string qsn in testObj.Questions)
                        {
                            Label label = new Label(5, 10 + (j * 2), qsn);

                            studentWin.Add(label);
                            j++;
                        }*/
                    };
                    studentWin.Add(button);

                    i++;
                }

                //get the name of each test returned in a string;
                




                //win.Add(testView);


            };
            teacher.Clicked = () =>
            {
                top.Remove(mainWin);
                top.Add(teacherWin);
                //load tests available;

                string dirName = "./Test";
                string extension = "test";
                string chosenTest;
                string[] testFileNames = Model.LoadAvailableTest(dirName, extension);

                int i = 0;
                foreach (String test in testFileNames)
                {
                    string testName = test.Substring(dirName.Length + 1, test.Length - dirName.Length - extension.Length - 2);
                    // Console.WriteLine(testName);
                    Button button = new Button(5, 2 + (i * 2), testName);

                    button.Clicked += () =>
                    {

                        string jsonData = File.ReadAllText(test);
                        Test testObj = JsonConvert.DeserializeObject<Test>(jsonData);
                        chosenTest = testObj.TestName;


                        
                        /* 
                        foreach (string qsn in testObj.Questions)
                        {
                            Label label = new Label(5, 10 + (j * 2), qsn);

                            teacherWin.Add(label);
                            j++;
                        }*/
                    };
                    teacherWin.Add(button);

                    i++;
                }
            };


            Application.Run();
        }
    }
}


