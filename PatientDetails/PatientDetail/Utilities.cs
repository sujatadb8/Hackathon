﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientDetail
{
    class Utilities
    {
        internal static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        internal static int GetNumber(string question)
        {
            //return int.Parse(Prompt(question));
            bool processing = false;
            int result;
            do
            {
                Console.WriteLine(question);
                processing = int.TryParse(Console.ReadLine(), out result);
            } while (!processing);
            return result;

        }
    }
}
