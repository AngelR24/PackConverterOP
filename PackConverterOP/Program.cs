using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic;

namespace PackConverterOP
{
    public class Program
    {

        public static string PackConverter(string input)
        {
            string ret = "";

            var charInput = input.ToCharArray().ToList();
            bool inAWord = false;
            bool endOfWord = false; 
            List<int> remove = new List<int>();

            for (int i = 0; i < charInput.Count; i++)
            {
                if (inAWord)
                {
                    if (charInput[i] == ' ')
                    {
                        inAWord = false;
                        remove.Add(i);
                    }
                    else if (charInput[i + 1] != ' ')
                    {
                        inAWord = false;
                    }
                    
                }
                else
                {
                    if (i == 0 && charInput[i] == ' ')
                    {
                        continue;
                    }
                    if (charInput[i] != ' ')
                    {
                        inAWord = true;
                    }

                    foreach (var rem in remove)
                    {
                        charInput.RemoveAt(rem);
                    }
                }
            }

            ret = String.Concat(input.Where(q => charInput.Contains(q) ));
            return ret;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(PackConverter("Hello          World"));
            Console.ReadKey();

        }
    }
}
