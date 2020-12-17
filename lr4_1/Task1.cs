using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lr4_1
{
    class Task1
    {
        private static readonly string defaultFile = $@"{Directory.GetCurrentDirectory()}\files\";
        private int sum;
        private int quantity;
        private int multiple;

        public Task1()
        {
            sum = 0;
            quantity = 0;
            multiple = 0;
        }

        public void Method()
        {
            try
            {
                openFiles();
                for (int i = 10; i < 30; i++)
                {
                    try
                    {
                        using (StreamReader file = new StreamReader($"{defaultFile}{i}.txt"))
                        {
                            int s1 = int.Parse(file.ReadLine()); ;
                            int s2 = int.Parse(file.ReadLine());
                            multiple = s1 * s2;
                            Console.WriteLine("The multiple of naumbers in the file {0}.txt is: ", i, multiple);
                            sum += multiple;
                            quantity++;
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine(i + " file.txt not found");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(i + " bad_data.txt");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine(i + "overflow.txt");
                    }
                }
                Console.WriteLine(sum / quantity);
            }
            catch (Exception e) { Console.Error.WriteLine(e.Message); }
        }

        private static void appendText(int numFile, string resultingFile, string text)
        {
            using (FileStream file = new FileStream(defaultFile + resultingFile, FileMode.Append))
            {
                using (StreamWriter stream = new StreamWriter(file))
                {
                    stream.WriteLine($"File {numFile}.txt - {text}");
                }
            }
        }

        private static void openFiles()
        {
            try
            {
                using (StreamWriter unused = File.CreateText(defaultFile + "no_file.txt"))
                {
                }

                using (StreamWriter unused = File.CreateText(defaultFile + "bad_data.txt"))
                {
                }

                using (StreamWriter unused = File.CreateText(defaultFile + "overflow.txt"))
                {
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception("Can't create file");
            }
        }
    }
}