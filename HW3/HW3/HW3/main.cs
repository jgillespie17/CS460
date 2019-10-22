using System;
using System.IO;
using System.Text;

namespace HW3
{
    public class Main
    {
        private static void printUsage()
        {
            Console.WriteLine("Usage is :\n" +
                "\tjava Main C inputfile outpujfile\n\n" +
                "where:" +
                "   C is the column number to fit to \n" +
                "   inputfile is the input text file \n" +
                "   outputfile is the new output file base name containing the wrapped text. \n" +
                "e.g. java Main i72 myfile.txt myfile_wrapped.txt");
        }

        public static void main(String[] args)
        {
            int C = 72;
            String inputFilename;
            String outputFilename = "output.txt";

            if(args.Length != 3)
            {
                printUsage();
                System.exit(1);

            }
            try
            {
                C = Interger.parseInt(args[0]);
                inputFilename = args[1];
                outputFilename = args[2];
                using (StreamReader reads = new StreamReader(inputFilename))
                {
                    string word;
                    while((word = reads.ReadLine()) != null)
                    {
                        word = reads.ReadLine();
                        words.push(word);
                    }
                }

            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Count not find the input file.");
                exit(1);
            }
            catch(Exception e)
            {
                Console.WriteLine("Something is wrong with the input.");
                printUsage();
                exit();
            }

            QueueInterface<String> words = new LinkedQueue<String>();

            int spacesRemaining = wrapSimply(words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);


        }

        private static int wrapSimply(QueueInterface<String> words, int columnLength, String outputFilename)
        {

            StreamWriter writerOut;

            try
            {
                writerOut = new StreamWriter(ouptutFilename);
            }
            catch( FileNotFoundException e)
            {
                Console.WriteLine("Cannon create or open " + outputFilename + " for writing. Using standard output instead.");
                writerOut = new StreamWriter(Console.WriteLine());
            }

            int col = 1;
            int spacesRemaining = 0;
            while ( !words.isEmpty() )
            {
                String str = words.peek();
                int len = str.Length();

                if (col == 1)
                {
                    writerOut.print(str);
                    col += len;
                    words.pop();
                }
                else if ((col + len) >= columnLength)
                {
                    Console.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {
                    writerOut.print(" ");
                    writerOut.print(str);
                    col += (len + 1);
                    words.pop();
                }

            }
            writerOut.WriteLine();
            writerOut.flush();
            writerOut.close();
            return spacesRemaining;
        }
    }
}