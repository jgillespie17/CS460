using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW3
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            int C = 72;
            string inputFilename = Path.Combine(Directory.GetCurrentDirectory(), "WarOfTheWorlds.txt");
            Console.WriteLine(inputFilename);
            string outputFilename = Path.Combine(Directory.GetCurrentDirectory(), "output.txt");
            Console.WriteLine(outputFilename);
            string C2 = C.ToString();
            args = new string[3];
            args[0] = C2;
            args[1] = inputFilename;
            args[2] = outputFilename;

            LinkedQueue<string> words = new LinkedQueue<string>();

            if (args.Length != 3)
            {
                PrintUsage();
                Environment.Exit(1);
            }
            try
            {
                C = int.Parse(args[0]);
                inputFilename = args[1];
                outputFilename = args[2];
                using (StreamReader reads = new StreamReader(inputFilename))
                {
                    string word;
                    while ((word = reads.ReadLine()) != null)
                    {
                        word = reads.ReadLine();
                        words.Push(word);
                    }
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the input file.");
                Environment.Exit(1);
            }
            catch (Exception)
            {
                Console.WriteLine("Something is wrong with the input.");
                PrintUsage();
                Environment.Exit(1);
            }
            int spacesRemaining = WrapSimply(words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);


        }


        private static void PrintUsage()
        {
            Console.WriteLine("Usage is :\n" +
                "\tjava Main C inputfile outputfile\n\n" +
                "where:" +
                "   C is the column number to fit to \n" +
                "   inputfile is the input text file \n" +
                "   outputfile is the new output file base name containing the wrapped text. \n" +
                "e.g. java Main 72 myfile.txt myfile_wrapped.txt");
        }
        private static int WrapSimply(LinkedQueue<string> words, int columnLength, String outputFilename)
        {
            StreamWriter writerOut = new StreamWriter(outputFilename);
            try
            {
                writerOut = new StreamWriter(outputFilename);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannon create or open " + outputFilename + " for writing. Using standard output instead.");
            }

            int col = 1;
            int spacesRemaining = 0;
            while (!words.IsEmpty())
            {
                String str = words.Peek();
                int len = str.Length;
                if (col == 1)
                {
                    
                    writerOut.WriteLine(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {
                    Console.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {
                    writerOut.WriteLine(" ");
                    writerOut.WriteLine(str);
                    col += (len + 1);
                    words.Pop();
                }

            }
            writerOut.WriteLine();
            writerOut.Flush();
            writerOut.Close();
            return spacesRemaining;
        }
    }
}
