using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProgram;

namespace MyProgram
{
    public sealed class Input
    {
        // Головний метод для роботи з Input запитом.
        public Node InputFunc()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("                  ~ Input ~               \n");
            Console.WriteLine("   1 - From Console       2 - From File    \n");

            int inpChoice;
            do
            {
                Console.Write("Your choice : ");
                if (int.TryParse(Console.ReadLine(), out inpChoice))
                {
                    if (inpChoice < 1 || inpChoice > 2)
                    {
                        Console.WriteLine("Error. Invalid number!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            if (inpChoice == 1)
            {
                Node head = FromConsoleToLinkedList();
                Console.WriteLine("\n\t === SUCCESS ===");
                return head;
            }

            string path = @"C:\Users\User\Desktop\ПЗ\ВІПЗ лаби\Сама програма\Information.txt";
            Node headd = FromFileToLinkedList(path);
            Console.WriteLine("\n\t  === SUCCESS ===");
            return headd;
        }

        // Метод, що зчитує дані з файла(шлях до файла передаємо через параметри функції)
        // та запихає їх в однозв'яний список та повертає список.
        private Node FromFileToLinkedList(string path)
        {
            string[] temp = new string[5];
            ListCommands.BooksCnt = 0;
            Node head = null;
            Node current = null;
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                temp = (reader.ReadLine()).Split('/');
                if (current == null)
                {
                    current = new Node();
                    head = current;
                }
                else
                {
                    current.Next = new Node();
                    current = current.Next;
                }
                current.Information = new Info(temp[0], temp[1], int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]));
                ListCommands.Pages += current.Information.Pages;
                ListCommands.BooksCnt += 1;
            }

            reader.Close();
            return head;
        }

        // Метод, що зчитує дані з консолі, 
        // запихає їх в однозв'яний список та повертає список.
        private Node FromConsoleToLinkedList()
        {
            Node head = null;
            Node curr = null;
            ListCommands.BooksCnt = 0;
            int n;

            do
            {
                Console.Write("Enter how many elements you wanna enter : ");
                try
                {
                    n = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("You entered wrong symbols for number of rows!!!! TRY again\n");
                    continue;
                }

                if (n <= 0 || n > 100)
                {
                    Console.WriteLine("You entered invalid number of rows!!!! TRY again\n");
                    continue;
                }

                break;
            } while (true);
            
            Console.WriteLine();
            string[] rows = new string[n];
            Console.WriteLine("Enter rows. Format : <Author><BookTitle><YearOfPublishing><Pages><Price>\n");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter {i + 1} row : ");
                string row = Console.ReadLine();
                char[] separator = { '<', '>' };
                string[] temp = row.Split(separator);
                temp = temp.Where(x => x != "").ToArray();
                if (temp[0].Length > 20 || temp[1].Length > 50)
                {
                    Console.WriteLine("Error. String parameters are too long !!!! TRY again\n");
                    i--;
                    continue;
                }
                if (curr == null)
                {
                    curr = new Node();
                    head = curr;
                }
                else
                {
                    curr.Next = new Node();
                    curr = curr.Next;
                }

                Info infor;
                try
                {
                    infor = new Info(temp[0], temp[1], int.Parse(temp[2]), int.Parse(temp[3]), int.Parse(temp[4]));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error. Input are not correct!!!! TRY again\n");
                    i--;
                    continue;
                }

                if (infor.YearOfPublishing < 0 || infor.YearOfPublishing > 2023)
                {
                    Console.WriteLine("Error. YearOfPublishing is not correct!!!! TRY again\n");
                    i--;
                    continue;
                }

                if (infor.Pages <= 0 || infor.Pages > 4032)
                {
                    Console.WriteLine("Error. Pages are not correct!!!! TRY again\n");
                    i--;
                    continue;
                }

                if (infor.Price <= 0 || infor.Price > 30800000)
                {
                    Console.WriteLine("Error. Price is not correct!!!! TRY again\n");
                    i--;
                    continue;
                }

                curr.Information = infor;
                ListCommands.Pages += curr.Information.Pages;
                ListCommands.BooksCnt += 1;
            }

            return head;
        }
    }
}
