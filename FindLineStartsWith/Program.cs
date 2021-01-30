using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindLineStartsWith
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("This application finds a text in a file.\nThe text must be found at the beginning of the line.\n" +
                    "It will return the line number where it finds the first coincidence.\nIf it does not find the text it will return 0.\n\n"+
                    "           0: Text has not been Found.\n"+
                    "          -1: An Error occurred (File missing probably)\n" +
                    "other number: line number where text was found.\n\n" +
                    "Example:\n" +
                    "FindLineStartsWith.exe \"Text to find\" Filename\n\n"+
                    "Written by patrik jacobs (m821926@gmail.com)");
                Console.ReadLine();
                return -1;
            }

            string textToFind = args[0];
            string fileToVerify = args[1];

            if (!File.Exists(fileToVerify))
            {
                Console.WriteLine("Error: File can not be found !");
                return -1;
            }
            
            IEnumerable<String> lines = File.ReadLines(fileToVerify);
            int lineNumber = 0;
            foreach (var line in lines)
            {
                if (line.StartsWith(textToFind))
                {
                    Console.WriteLine("The text '"+ textToFind + "' was found on line number " + lineNumber);
                    return lineNumber;
                }
                lineNumber++;
            }
            return 0;
        }
    }
}
