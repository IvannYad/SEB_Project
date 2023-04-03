using MyProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgram
{
    // Клас, який виконує основні операції з однозв'язним списком.
    public static class ListCommands
    {
        public static int BooksCnt { get; set; }
        public static int Pages { get; set; }

        // Метод додавання елемента(ів) в кінець однозв'язного списку.
        public static void Add(ref Node head)
        {
            Node current = head;
            if (head is not null)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
            }

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
                if (temp[0].Length > 80 || temp[1].Length > 80
                    || string.IsNullOrEmpty(temp[0]) || string.IsNullOrWhiteSpace(temp[0])
                    || string.IsNullOrEmpty(temp[1]) || string.IsNullOrWhiteSpace(temp[1]))
                {
                    Console.WriteLine("Error. String parameters are too long !!!! TRY again\n");
                    i--;
                    continue;
                }
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

                current.Information = infor;
                ListCommands.Pages += current.Information.Pages;
                ListCommands.BooksCnt += 1;
            }

            Console.WriteLine("\n\t === SUCCESS ===");
        }

        // Метод, що  видаляє всі книжки з однозв'язного списку, рік видання яких
        // менший за 2000 і кількість сторінок менша за 150.
        public static void Delete(ref Node head)
        {
            int numBooksDeleted = 0;
            
            while (head is not null && head.Information.YearOfPublishing < 2000 && head.Information.Pages < 150)
            {
                numBooksDeleted++;
                head = head.Next;
            }

            if (head is null)
            {
                Console.WriteLine($"\n{numBooksDeleted} Books were deleted");
                Console.WriteLine("ListCommands is empty now");
                Menu.IsInputPerformed = false;
                return;
            }
            Node current = head.Next;
            Node precurrent = head;
            while (current != null)
            {
                if (current.Information.YearOfPublishing < 2000 && current.Information.Pages < 150)
                {
                    numBooksDeleted++;
                    precurrent.Next = current.Next;
                    current = precurrent.Next;
                    if (current == null)
                    {
                        break;
                    }
                    continue;
                }
                if (current == null)
                {

                    break;
                }
                precurrent = precurrent.Next;
                current = current.Next;
            }

            if (numBooksDeleted == 0)
            {
                Console.WriteLine("\nNo books were deleted");
                return;
            }

            Console.WriteLine($"\n{numBooksDeleted} Books were deleted");
        }

        // Метод, яка сортує книжки з кількістю сторінок меншою за середню по року їх видання.
        public static void SortBooksWithPagesLessThanAverage(Node head)
        {
            int k_suitable = 0;
            Info temp = null;
            Node curr = head;
            while (curr != null)
            {
                if (curr.Information.Pages < Pages)
                {
                    k_suitable++;
                }
                curr = curr.Next;
            }

            curr = head;
            Node nextcurr = curr.Next;
            for (int i = 0; i < BooksCnt; i++)
            {
                curr = head;
                nextcurr = curr.Next;
                while (nextcurr != null)
                {
                    while (curr != null && curr.Next != null && curr.Information.Pages >= Pages / BooksCnt)
                    {
                        curr = curr.Next;

                    }
                    nextcurr = curr.Next;
                    while (nextcurr != null && nextcurr.Information.Pages >= Pages / BooksCnt)
                    {
                        nextcurr = nextcurr.Next;

                    }
                    if (nextcurr == null)
                    {
                        break;
                    }
                    if (curr.Information.YearOfPublishing > nextcurr.Information.YearOfPublishing)
                    {
                        temp = curr.Information;
                        curr.Information = nextcurr.Information;
                        nextcurr.Information = temp;
                    }
                    curr = nextcurr;
                    nextcurr = nextcurr.Next;

                }
            }

            Console.WriteLine("\n\t === SUCCESS ===");
        }
    }
}
