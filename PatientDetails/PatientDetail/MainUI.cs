using System;
using PatientDetail;
namespace PatientDetail
{
    
    namespace UILayer
    {
        
        class UIComponent
        {
            public const string menu = "﻿~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~PATIENT DISEASE DATABASE SOFTWARE~~~~~~~~~~~~~~~~~~~\n1. TO ADD NEW DISEASE------------------------>PRESS 1\n 2. TO ADD SYMPTOM--------------->PRESS 2\n3. TO CHECKDETAILS----------------->PRESS 3\n4. PS: ANY OTHER KEY IS CONSIDERED AS EXIT............................";


            public  static DiseaseDataBase repo;

            public static string SymptomName { get; private set; }

            public static void Run()
            {
                int size = Utilities.GetNumber("enter the no of patient details ");
                repo = new DiseaseDataBase(size);
                bool processing = true;
                do
                {
                    string choice = Utilities.Prompt(menu);
                    processing = Processmenu(choice);
                } while (processing);
                Console.WriteLine("tHANK YOU  FOR USING OUR APPLICATION ");
            }

            private static bool Processmenu(string choice)
            {
                switch (choice)
                {
                    case "1":
                        Add();
                        break;
                    case "2":
                       AddSymptom();
                        break;
                    case "3":
                        CheckDetails();
                        break;
                    default:
                        return false;

                }
                return true;
            }
            private static void CheckDetails()
            {
                string SymptonName = Utilities.Prompt("Enter the SymtomName ");
                try
                {

                    Console.WriteLine($"The details of the Disease");
                    Symptom[] symptoms = repo.CheckDetail(SymptomName);
                    for (int i = 0; i < symptoms.Length; i++)
                    {
                        string content = $"The Symptom Id : {symptoms[i].SymptomId}\nThe patient Name : {symptoms[i].PatientName}";
                        Console.WriteLine(content);
                    }
                    Utilities.Prompt("Press enter to clear the screen");
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public static void Add()
            {
                int id = Utilities.GetNumber("Enter the id of the Disease");
                string diseaseName = Utilities.Prompt("Enter the name of the disease");
                string cause= Utilities.Prompt("Enter cause name");
                string servirity = Utilities.Prompt("Enter the servirity");
               string description= Utilities.Prompt($"Enter the description of the minimum length 30  ");
                if (description.Length < 30)
                {
                    Console.WriteLine("Description should be more than 30 characters");
                    return;
                }
                Disease disease= new Disease { DiseaseId = id, DiseaseName = diseaseName, Cause = cause, Severity =servirity,Description = description };
                repo.AddDisease(disease);
                Utilities.Prompt("Press enter to clear the screen");
                Console.Clear();
            }
            public static void AddSymptom()
            {
                int id = Utilities.GetNumber("Enter the id of the symptom");
                string symptomName = Utilities.Prompt("Enter the name of the symptom");
                string description = Utilities.Prompt($"Enter the description of the minimum length 30");
                if (description.Length < 30)
                {
                    Console.WriteLine("Description should be more than 30 characters");
                    return;
                }
                Symptom symp = new Symptom { SymptomId = id,SymptomName =symptomName, Description = description };
                repo.AddSymptoms(symp);
                Utilities.Prompt("Press enter to clear the screen");
                Console.Clear();
            }

        }


    }

    namespace TestingApp
    {
        class App
        {
            static void Main(string[] args)
            {
                UILayer.UIComponent.Run();
            }
        }
    }


}
