using System;
using System.Collections.Generic;
using System.IO;

namespace Budget_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            #region FIELDS
            StreamReader input = null;
            List<string>  lines = new List<string>();
            string line = null;
            string columnNames = null;
            #endregion

            Console.WriteLine("Enter input filename including file extension:  ");
            string inputFilename = Console.ReadLine();
            Console.WriteLine("Enter output filename including file extension:  ");
            string outputFilename = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();

            try
            {
                //Open the CSV file
                input = File.OpenText(inputFilename);
                Console.WriteLine("CSV file opened.");
                //Read the first line
                string columnTitles = input.ReadLine();
                columnNames = ',' + columnTitles;
                Console.WriteLine("First line read");
                
                //Continue to read the lines of data
                
                line = input.ReadLine();

                while (line != null)
                {
                    Console.WriteLine("Read line: " + line);
                    lines.Add(line);
                    line = input.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                if (input != null)
                {
                    input.Close();
                    Console.WriteLine("Input File closed.");
                }
            }
            //lines list now contains all of the lines except for the column titles
            List<string> newList = new List<string>();
            for(int i = 0; i < lines.Count; i++)
            {
                //Add a comma to each line before the first space
                int location = lines[i].IndexOf(' ');
                Console.WriteLine("The first space is located at index " + location);
                string str1 = lines[i].Substring(0, location);
                Console.WriteLine("The first substring is:" + str1);
                string str2 = lines[i].Substring(location + 1);
                Console.WriteLine("The second substring is:" + str2);
                string newString = str1 + ',' + str2;
                Console.WriteLine("The newString is:" + newString);
                newList.Add(newString);
            }
            

            //Output all of the values in the newList back into a file.
            
            try
            {
                using (StreamWriter writer = new StreamWriter(outputFilename))
                {
                    writer.WriteLine(columnNames);

                    for (int i = 0; i < newList.Count; i++)
                    {
                        writer.WriteLine(newList[i]);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
