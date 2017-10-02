// Main.cs
// RSSFeedMaker
// Yannick Bungers
// 7/20/2011 12:16
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace YB
{
    static class Program
    {
        static string FilePath;
        static YB.VirtualRSSXmlFile VirtualRSSFile1;
        static string[] Introduction = { "Warning", "RSSXmlFeedMaker [0.0.0.1] by Yannick Bungers", "Copyright (c) 2011 Tool corp." };
        static string[] Help = { "" };
        static int Main(string[] args)
        {
            System.Console.Title = "RSSFeedMaker";
            MakeOutput(Introduction);
            bool End = false;
            while (true)
            {
                string Input = System.Console.ReadLine();
                string[] InputArray = Input.Split(new char[] { ' ' });
                string Instruction = InputArray[0].ToLower();
                switch (Instruction)
                {
                    case "time":
                    case "zeit":
                        string[] Output = { "Info", DateTime.Now.ToUniversalTime().ToString("r") };
                        MakeOutput(Output);
                        break;
                    #region // WINDOW Loader
                    //case "window":
                    //case "fenster":
                    //case "gui":
                    //    RSSFeedMaker.WindowMain test = new RSSFeedMaker.WindowMain();

                    //    YB.Program Thread = new Program();

                    //    System.Threading.Thread Window = new System.Threading.Thread(new System.Threading.ThreadStart(Thread.StartWindow));
                    //    Window.SetApartmentState(System.Threading.ApartmentState.STA);
                    //    Window.Start();
                    //    //System.

                    //    break;
                    #endregion
                    case "!":
                    case "info":
                    case "information":
                        MakeOutput(GetInfo(InputArray));
                        break;
                    case "?":
                    case "hilfe":
                    case "help":
                        MakeOutput(GetHelp(InputArray));
                        break;
                    case "new":
                    case "neu":
                        MakeOutput(New(InputArray));
                        break;
                    case "add":
                    case "hinzufügen":
                        MakeOutput(Add(InputArray));
                        break;
                    case "set":
                    case "setze":
                        MakeOutput(Set(InputArray));
                        break;
                    case "load":
                    case "laden":
                    case "lade":
                        MakeOutput(Load(InputArray));
                        break;
                    case "save":
                    case "speichern":
                        MakeOutput(Save(InputArray));
                        break;
                    case "getall":
                    case "alles":
                    case "all":
                        MakeOutput(GetAll(InputArray));
                        break;
                    case "end":
                    case "ende":
                    case "exit":
                    case "quit":
                    case "beenden":
                    case "stop":
                        End = true;
                        break;
                    case "":
                        break;
                    default:
                        string[] ErrorInput = { "Error", "The instruction \"" + Instruction + "\" isn't matched against any funktion!" };
                        MakeOutput(ErrorInput);
                        break;
                }
                if (End)
                {
                    break;
                }
            }
            return 0;
        }

        static string[] GetHelp(string[] Parameters) //TODO:
        {
            List<string> Output = new List<string>();
            Output.Add("Help for RSSFeedMaker");
            return Output.ToArray();
        }
        static string[] GetInfo(string[] Parameters) //TODO:
        {
            List<string> Output = new List<string>();
            return Output.ToArray();
        }
        static string[] New(string[] Parameters)
        {
            List<string> Output = new List<string>();
            VirtualRSSFile1 = new VirtualRSSXmlFile();
            Output.Add("Info");
            Output.Add("New Projekt was created!");
            return Output.ToArray();
        }
        static string[] Add(string[] Parameters)
        {
            List<string> Output = new List<string>();
            VirtualRSSFile1.AddItem();
            Output.Add("Info");
            Output.Add("Item " + VirtualRSSFile1.GetItemCount().ToString());
            return Output.ToArray();
        }
        static string[] Set(string[] Parameters)
        {
            List<string> Output = new List<string>();
            if (Parameters.Length > 1)
            {
                switch (Parameters[1].ToLower())
                {
                    case "file":
                    case "rssfile":
                    case "main":
                        SetTagVirtualFile(Parameters);
                        break;



                    default:
                        int ItemNumber;
                        if (Int32.TryParse(Parameters[1], out ItemNumber))
                        {
                            if (ItemNumber < VirtualRSSFile1.GetItemCount())
                            {
                                SetTagItemVirtualFile(Parameters, ItemNumber);
                            }
                        }
                        else
                        {
                            int Number = Parameters.Length + 1;
                            string[] ModedParameters = new string[Number];
                            ModedParameters[0] = Parameters[0];
                            ModedParameters[1] = "main";
                            for (int i = 1; i < Parameters.Length; i++)
                            {
                                ModedParameters[(i + 1)] = Parameters[i];
                            }
                            if (SetTagVirtualFile(ModedParameters) == 0)
                            {
                                Output.Add("Error");
                                Output.Add("Invalid parameter!");
                            }
                        }
                        break;
                }
            }
            else
            {
                Output.Add("Error");
                Output.Add("No projekt open!");
            }
            return Output.ToArray();
        }
        static string[] Load(string[] Parameters)
        {
            List<string> Output = new List<string>();
            string FilePath = Program.ArrayToString(Parameters, 1);

            if (File.Exists(FilePath))
            {
                VirtualRSSFile1 = VirtualRSSXmlFile.Load(FilePath);

                Output.Add("Info");
                Output.Add("File \"" + FilePath + "\" was loaded.");
                Program.FilePath = FilePath;
            }
            else
            {
                Output.Add("Error");
                Output.Add("File \"" + FilePath + "\" can not be found.");
            }
            return Output.ToArray();
        }
        static string[] Save(string[] Parameters)
        {
            List<string> Output = new List<string>();
            if (VirtualRSSFile1 != null)
            {
                string FilePathInput = ArrayToString(Parameters, 1);
                if (FilePathInput == "")
                {
                    if (FilePath == "")
                    {
                        Output.Add("Error");
                        Output.Add("There must be a file path!");

                    }
                    else
                    {
                        VirtualRSSFile1.WriteToFile(FilePath);
                        Output.Add("");
                        Output.Add("Succesfull write to file: " + FilePath);
                    }
                }
                else
                {
                    VirtualRSSFile1.WriteToFile(FilePathInput);
                    Output.Add("");
                    Output.Add("Succesfull write to file: " + FilePathInput);
                }
            }
            else
            {
                Output.Add("Error");
                Output.Add("No projekt open!");
            }

            return Output.ToArray();
        }
        static string[] GetAll(string[] Parameters)
        {
            List<string> Output = new List<string>();
            if (VirtualRSSFile1 != null)
            {
                Output.Add("");
                Output.Add("Main: " + VirtualRSSFile1.Title);
                Output.Add("\n=> " + VirtualRSSFile1.Link);
                Output.Add(VirtualRSSFile1.Description);
                Output.Add("Generator: " + VirtualRSSFile1.Generator);
                Output.Add("Docs: " + VirtualRSSFile1.Docs);
                Output.Add("Language: " + VirtualRSSFile1.Language);
                Output.Add("PublicationDate: " + VirtualRSSFile1.PublicationDate);
                Output.Add("LastBuildDate: " + VirtualRSSFile1.LastBuildDate);
                Output.Add("");

                if (VirtualRSSFile1.ItemList != null)
                {
                    int i = 0;
                    foreach (YB.VirtualRSSXmlFile.item Item in VirtualRSSFile1.ItemList)
                    {
                        i++;
                        Output.Add("\nItem " + i.ToString() + ":\n" + Item.Title);
                        Output.Add("=> " + Item.Link);
                        Output.Add(Item.Description);
                        Output.Add(Item.PublicationDate);
                    }
                }
            }
            else
            {
                Output.Add("Error");
                Output.Add("No projekt open");
            }
            return Output.ToArray(); 
        }



        static int MakeOutput(string[] Output)
        {
            if (Output.Length > 0)
            {
                switch (Output[0])
                {
                    case "Error":
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Info":
                        System.Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "Warning":
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                }
                for (int i = 1; i < Output.Length; i++)
                {
                    System.Console.WriteLine(Output[i]);
                }
                System.Console.ForegroundColor = ConsoleColor.Gray;

                return Output.Length;
            }
            return 0;
        }
        static int SetTagVirtualFile(string[] Parameters)
        {
            int StartText = 3;
            switch (Parameters[2])
            {
                
                case "title":
                case "titel":
                    VirtualRSSFile1.Title = ArrayToString(Parameters, StartText);
                    break;

                case "link":
                    VirtualRSSFile1.Link = ArrayToString(Parameters, StartText);
                    break;

                case "description":
                case "Beschreibung":
                    VirtualRSSFile1.Description = ArrayToString(Parameters, StartText);
                    break;

                case "pubdate":
                case "publicationdate":
                case "publikationsdatum":
                case "herausgabedatum":
                    VirtualRSSFile1.PublicationDate = ArrayToString(Parameters, StartText);
                    break;
                
                case "generator":
                case "ersteller":
                    VirtualRSSFile1.Generator = ArrayToString(Parameters, StartText);
                    break;

                case "docs":
                case "documents":
                case "dokumente":
                    VirtualRSSFile1.Docs = ArrayToString(Parameters, StartText);
                    break;

                case "language":
                case "sprache":
                    VirtualRSSFile1.Language = ArrayToString(Parameters, StartText);
                    break;

                case "lastbuilddate":
                case "letzterbuilddatum":
                    VirtualRSSFile1.LastBuildDate = ArrayToString(Parameters, StartText);
                    break;
                default:
                    return 0;
            }
            return 1;
        }
        static int SetTagItemVirtualFile(string[] Parameters, int ItemNumber)
        {
             int StartText = 3;
            switch (Parameters[2])
            {
                case "title":
                case "titel":
                    VirtualRSSFile1.ItemList[ItemNumber].Title = ArrayToString(Parameters, StartText);
                    break;

                case "link":
                    VirtualRSSFile1.ItemList[ItemNumber].Link = ArrayToString(Parameters, StartText);
                    break;

                case "description":
                case "Beschreibung":
                    VirtualRSSFile1.ItemList[ItemNumber].Description = ArrayToString(Parameters, StartText);
                    break;

                case "pubdate":
                case "publicationdate":
                case "publikationsdatum":
                case "herausgabedatum":
                    VirtualRSSFile1.ItemList[ItemNumber].PublicationDate = ArrayToString(Parameters, StartText);
                    break;
                default:
                    return 0;
            }
            return 1;
        }
        static string ArrayToString(string[] Text, int Start)
        {
            string Current ="";
            if (Start < Text.Length)
            {
                Current = Text[Start];
                if (Start < (Text.Length-1))
                {
                    for (int i = (Start + 1); i < Text.Length; i++)
                    {
                        Current = Current + " " + Text[i];
                    }
                }
            }
            return Current;
        }
        //void StartWindow()
        //{
        //    RSSFeedMaker.WindowMain test = new RSSFeedMaker.WindowMain();
        //    Application.EnableVisualStyles();
        //    Application.Run(test);
            
        //}
    }
}
