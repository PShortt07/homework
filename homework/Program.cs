
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    internal class Program
    {
        struct homework
        {
            public string subject;
            public string desc;
            public DateTime date;
            public bool complete;
        }
        static void DisplayMenu()
        {
            int x = 0;
            while (x == 0)
            {
                Console.WriteLine("1. View Homework\n2. Add Homework\n3. Complete Homework\n4. Quit");
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error");
                    x = 0;
                }
                switch (x)
                {
                    case 1:
                        DisplayHomework();
                        break;
                    case 2:
                        AddHomework();
                        break;
                    case 3:
                        CompleteHomework();
                        break;
                    case 4:
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Error");
                        x = 0;
                        break;
                }
            }
        }
        static void DisplayHomework()
        {
            StreamReader fileReader = new StreamReader("homework.txt");
            List<homework> homeworkList = new List<homework>();
            int x = 0;
            homework homework = new homework();
            while (!fileReader.EndOfStream)
            {
                if (x == 2)
                {
                    homework.date = DateTime.Parse(fileReader.ReadLine());
                }
                else if (x == 3)
                {
                    homework.complete = bool.Parse(fileReader.ReadLine());
                }
                else
                {
                    homework.subject = fileReader.ReadLine();
                    homework.desc = fileReader.ReadLine();
                    x++;
                }
                x++;
                if (x == 4)
                {
                    homeworkList.Add(homework);
                    homework = new homework();
                    x = 0;
                }
            }
        }
        static void AddHomework()
        {
            StreamWriter fileWriter = new StreamWriter("homework.txt", true);
            Console.WriteLine("Enter subject:");
            fileWriter.WriteLine(Console.ReadLine());
            Console.WriteLine("Enter description:");
            fileWriter.WriteLine(Console.ReadLine());
            DateTime date = DateTime.Now;
            do
            {
                Console.WriteLine("Enter date due (DD/MM/YYYY):");
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error");
                    date = DateTime.Now;
                }
                if (date < DateTime.Now)
                {
                    Console.WriteLine("Invalid. Date is in the past");
                    date = DateTime.Now;
                }
            } while (date == DateTime.Now);
            fileWriter.WriteLine("false");
        }
        static void CompleteHomework()
        {

        }
        static void Quit()
        {
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            DisplayMenu();
            //while (!fileReader.EndOfStream)
            {
                //if (x % 2 == 0)
                {
                    //DateTime date = DateTime.Parse(fileReader.ReadLine());
                    //if (date < DateTime.Today)
                    {
                        //StreamWriter fileWriter = new StreamWriter("homework.txt", true);
                    }
                    //else
                    {
                        //if (date.Day - DateTime.Today.Day <= 3)
                        {
                            //Console.BackgroundColor = ConsoleColor.Red;
                            //Console.Write(date);
                            //Console.BackgroundColor = ConsoleColor.Black;
                        }
                        //else
                        {
                            //Console.Write(date);
                        }
                    }
                }
                //else if (x % 3 == 0)
                {
                    //string workComplete = fileReader.ReadLine();
                    //if (workComplete == "done")
                    {
                        //Console.BackgroundColor = ConsoleColor.Green;
                        //Console.WriteLine(workComplete);
                        //Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
                //else
                {
                    //Console.Write(fileReader.ReadLine());
                }
                //x++;
            }
            //Console.ReadLine();
        }
    }
}
