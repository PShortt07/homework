
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
        //Creates a new structure to hold all information about a piece of homework
        struct homework
        {
            public string subject;
            public string desc;
            public DateTime date;
            public bool complete;
        }
        //Displays the menu on the console
        static void DisplayMenu()
        {
            Console.Clear();
            int x = 0;
            //Creates a new list containing all homework already on the file
            List<homework> homeworkList = new List<homework>();
            homeworkList = listGenerator(homeworkList);
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
                        DisplayHomework(homeworkList);
                        Console.ReadLine();
                        break;
                    case 2:
                        //Checks if the limit of 20 has been reached
                        if (homeworkList.Count < 20)
                        {
                            AddHomework();
                        }
                        else
                        {
                            Console.WriteLine("Maximum of 20 pieces of homework reached.");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        CompleteHomework(homeworkList);
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
        static List<homework> listGenerator(List<homework> homeworkList)
        {
            //Opens file to be read
            StreamReader fileReader = new StreamReader("homework.txt");
            int x = 0;
            //Creates a new 'homework' variable to be used to take in information from the file and put it into the list
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
                //Only adds if the homework is due in the future
                if (x == 4 && homework.date > DateTime.Today)
                {
                    //Adds to list
                    homeworkList.Add(homework);
                    homework = new homework();
                    x = 0;
                }
            }
            fileReader.Close();
            return homeworkList;
        }
        //Displays all homework
        static void DisplayHomework(List<homework> homeworkList)
        {
            int x = 1;
            foreach (homework i in homeworkList)
            {
                //Displays in red if it is due in less than 3 days and incomplete
                if (i.date.Day - DateTime.Today.Day <= 3 && i.complete == false)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (i.complete == true)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.Write($"{x}. ");
                Console.WriteLine(i.subject);
                Console.WriteLine(i.desc);
                Console.WriteLine(i.date);
                //Checks if work is complete
                if (i.complete == true)
                {
                    Console.WriteLine("Done");
                }
                else
                {
                    Console.WriteLine("Not Done");
                }
                x++;
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        //Adds a piece of homework to the file
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
            fileWriter.WriteLine(date.ToString());
            fileWriter.WriteLine("false");
            fileWriter.Close();
        }
        //Allows user to mark a piece of homework as complete
        static void CompleteHomework(List<homework> homeworkList)
        {
            int num = 0;
            do
            {
                //Displays homework
                DisplayHomework(homeworkList);
                Console.WriteLine("Enter homework number:");
                try
                {
                    num = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error");
                    num = 0;
                }
                //Checks if the chosen homework exists
                if (num < 1 || num > homeworkList.Count)
                {
                    Console.WriteLine("Error");
                    Console.ReadLine();
                    Console.Clear();
                    num = 0;
                }
            } while (num == 0);
            //Changes the 'complete' value of the chosen homework in the list to true
            for (int i = 1; i <= homeworkList.Count; i++)
            {
                if (i == num)
                {
                    homework x = homeworkList[i-1];
                    x.complete = true;
                    homeworkList[i-1] = x;
                }
            }
            //Writes the new value to the file
            StreamWriter fileWriter = new StreamWriter("homework.txt");
            foreach (homework homework in homeworkList)
            {
                fileWriter.WriteLine(homework.subject.ToString());
                fileWriter.WriteLine(homework.desc.ToString());
                fileWriter.WriteLine(homework.date.ToString());
                fileWriter.WriteLine(homework.complete.ToString());
            }
            fileWriter.Close();
        }
        //Exits the program
        static void Quit()
        {
            Environment.Exit(0);
        }
        static void Main(string[] args)
        {
            //Keeps the menu in a loop
            int x = 0;
            while (x == 0)
            {
                DisplayMenu();
            }
        }
    }
}
