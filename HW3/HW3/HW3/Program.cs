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
    
            Console.WriteLine("Please enter wrap width: ");
            string C = Console.ReadLine();

            string directory = Directory.GetCurrentDirectory();

            Console.WriteLine("Please enter the input file name: ");
            Console.WriteLine("Automatically uses current directory of exe for path");
            string inputFilename = Console.ReadLine();
            inputFilename = Path.Combine(directory, inputFilename);

            Console.WriteLine("Automatically uses current directory of exe for path");
            Console.WriteLine("Please enter the output file name: ");
            string outputFilename = Console.ReadLine();
            outputFilename = Path.Combine(directory, outputFilename);

            //Console.WriteLine(C);

            //string inputFilename = Path.Combine(Directory.GetCurrentDirectory(), "WarOfTheWorlds.txt");
            //Console.WriteLine(inputFilename);
            //string outputFilename = Path.Combine(Directory.GetCurrentDirectory(), "output.txt");
            //Console.WriteLine(outputFilename);
            int C2 = int.Parse(C);
            args = new string[3];
            args[0] = C;
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
                using (StreamReader reads = new StreamReader(inputFilename))
                {
                    string book = reads.ReadToEnd();
                    foreach(string word in book.Split(' '))
                    {
                        words.Push(word);
                    }
                    reads.Close();
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the input file.");
                PrintUsage();
                Environment.Exit(1);
            }
            catch (Exception)
            {
                Console.WriteLine("Something is wrong with the input.");
                PrintUsage();
                Environment.Exit(1);
            }

            int spacesRemaining = WrapSimply(words, C2, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();

        
        }


        private static void PrintUsage()
        {
            Console.WriteLine("Usage is :\n" +
                "\t C 'enter' inputfile 'enter' outputfile\n\n" +
                "where:" +
                "   C is the column number to fit to \n" +
                "   inputfile is the input text file \n" +
                "   outputfile is the new output file base name containing the wrapped text. \n" +
                "e.g. 72 \n" +
                "WarOfTheWorlds.txt \n" +
                "output.txt");
        }
        private static int WrapSimply(IQueueInterface<string> words, int columnLength, string outputFilename)
        {
       
            StreamWriter writerOut = new StreamWriter(outputFilename);
            try
            {
                writerOut.Flush();
                writerOut.Close();
                StreamWriter streamWriter = writerOut = new StreamWriter(outputFilename);
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
                //Console.WriteLine(len);
                if (col == 1)
                {
                    
                    writerOut.Write(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {
                    writerOut.WriteLine();
                    spacesRemaining += (columnLength - col + 1);
                    col = 1;
                }
                else
                {
                    writerOut.Write(" ");
                    writerOut.Write(str);
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
