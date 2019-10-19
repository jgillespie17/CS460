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
            //scanner equivalent goes here

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
                //scanner equivalent goes here

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

            while(/*scanner equialent goes here*/)
            {
                String word = /*scanner equivalent goes here*/;
                words.push(word);
            }


            int spacesRemaining = wrapSimply(words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);


        }

        private static int wrapSimply(QueueInterface<String> words, int columnLength, String outputFilename)
        {
            PrintWriter out;

            try
            {
                outputFilename = new printWriter(ouptutFilename);
            }
            catch( FileNotFoundException e)
            {
                Console.WriteLine("Cannon create or open " + outputFilename + " for writing. Using standard output instead.");
                outputFilename = new PrintWriter(Console.WriteLine());
            }

            int col = 1;
            int spacesRemaining = 0;
            while (!words.isEmpty())
            {
                String str = words.peek();
                int len = str.Length();

                if (col == 1)
                {
                    out.print(str);
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
                    out.print(" ");
                    out.print(str);
                    col += (len + 1);
                    words.pop();
                }

            }
            out.println();
            out.flush();
            out.close();
            return spacesRemaining;
        }
    }
}