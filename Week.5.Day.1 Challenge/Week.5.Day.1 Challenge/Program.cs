using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week._5.Day._1_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileContents = System.IO.File.ReadAllText(@"C:\TIY\Projects\Week5.Day1\names.txt").Split(',').ToList();
            fileContents.Sort();

            for (int i = 0; i < fileContents.Count(); i++)
            {
                Names ns = new Names();
                ns.Name = fileContents[i].Trim('\"');
            }
            Console.WriteLine("Total Score = {0}", names.Sum(x => x.);
        }

    }
    class Names
    {
        public string Name { get; set; }
        public int LetterScore
        {
            get
            {
                int score = 0;
                var array = Name.ToUpper().ToCharArray();
                foreach (var letter in array)
                {
                    score += letter - 'A' + 1;
                }
                return score;
            }
        }
    }
    class SetValue
    {
        public int MyProperty { get; set; }
    }
    
}
