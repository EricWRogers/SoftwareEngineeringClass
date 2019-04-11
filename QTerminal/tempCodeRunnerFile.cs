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
                        
                        
                        int j = 0;
                        foreach (string qsn in testObj.Question)
                        {
                            Label label = new Label(5, 10 + (j * 2), qsn);

                            studentWin.Add(label);
                            j++;
                        }
                    };
                    studentWin.Add(button);

                    i++;
                }
            };
