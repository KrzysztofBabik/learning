using System;
using System.IO;


namespace CreateNewFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "myArrayTest.txt";
            try
            {
                Console.Write("\n\n Create a file named {0} in the disk :\n", fileName);
                Console.Write("------------------------------------------------\n");
                // Create the file.

                using (var fileStr = File.AppendText(fileName))
                {
                    Console.WriteLine(" A file created with name {0}\n\n", fileName);

                    int[] numbers = new int[] {8, 14, 54, 23, 11};

                    fileStr.WriteLine("Array of numbers: \n");
                    foreach (int number in numbers)
                        fileStr.WriteLine(number);
                }

            }
            catch (Exception MyExcep)
            {
                Console.WriteLine(MyExcep.ToString());
            }

            Console.ReadLine();
        }
    }
}
