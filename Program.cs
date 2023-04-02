using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace MyProgram
{
    // Клас для збереження інформації про книжки.
    public class Info
    {
        public string Author;
        public string BookTitle;
        public int YearOfPublishing;
        public int Pages;
        public int Price;

        public Info(string au, string bt, int yop, int pg, int pc)
        {
            Author= au;
            BookTitle= bt;
            YearOfPublishing= yop;
            Pages=pg;
            Price= pc;
        }
    }

    // Клас, який представляє вузол однозв'язного списку.
    public class Node
    {
        public Node? Next;
        public Info? Information;
        public Node()
        {
            Next = null;
            Information = null;
        }
    }

    class Program
    {
        // Метод для відображання вікна входу в програму.
        static void EntryWindow()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\t\t\t ~~~ ENTRY WINDOW ~~~\n");
            Console.WriteLine("\t\t 1 - Open Menu          2 - Exit      \n");
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
            Console.WriteLine();
            if (inpChoice == 1)
            {
                Menu menu = new Menu();
                menu.MainMenu();

                EntryWindow();
            }

        }
        
        // Точка входу в програму.
        static void Main(string[] args)
        {
            EntryWindow();
        }
    }
}