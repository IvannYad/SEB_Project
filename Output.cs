using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProgram;

namespace MyProgram
{
    public class Output
    {
        // Голова однозв'язного списку.
        private Node _head;
        
        // Конструктор.
        public Output(Node head)
        {
            _head = head is not null ? head : throw new ArgumentNullException(nameof(head));
        }

        // Головний метод для роботи з Output запитом.
        public void OutputFunc()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("                  ~ Output ~               \n");
            Console.WriteLine("   1 - To Console       2 - To File    \n");

            int outChoice;
            do
            {
                Console.Write("Your choice : ");
                if (int.TryParse(Console.ReadLine(), out outChoice))
                {
                    if (outChoice < 1 || outChoice > 2)
                    {
                        Console.WriteLine("Error. Invalid number!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            if (outChoice == 1)
            {
                ShowTableIntoConsole();
                return;
            }

            string path = @"C:\Users\User\Desktop\ПЗ\ВІПЗ лаби\Сама програма\Information.txt";
            ShowTableIntoFile();
            Console.WriteLine("\tSUCCESS");
        }

        // Метод виведення таблиці з даними в консоль.
        private void ShowTableIntoConsole()
        {
            Node current = _head;
            Console.WriteLine($"{"",50}~~~ {"List"} ~~~{"",38}");
            Console.WriteLine("\t---------------------------------------------------------------------------------------------");
            Console.WriteLine($"\t|{"",-10}|{"",-20}|{"",-30}|{"",-7}|{"",-8}|{"",-11}|");
            Console.WriteLine($"\t|{" Index",-10}|{" Author",-20}|{" BookName",-30}|{" Year",-7}|{" Pages",-8}|{" Price",-11}|");
            Console.WriteLine($"\t|{"",-10}|{"",-20}|{"",-30}|{"",-7}|{"",-8}|{"",-11}|");
            Console.WriteLine("\t---------------------------------------------------------------------------------------------");
            int i = 0;
            while (current != null)
            {
                Console.WriteLine($"\t|{" " + i + ".",-10}| {current.Information.Author,-19}| " +
                    $"{current.Information.BookTitle,-29}|" +
                    $" {current.Information.YearOfPublishing,-6}|" +
                    $" {current.Information.Pages,-7}|" +
                    $" {current.Information.Price,-10}|");
                Console.WriteLine("\t---------------------------------------------------------------------------------------------");
                current = current.Next;
                i++;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        // Метод виведення таблиці з даними в файл.
        private void ShowTableIntoFile()
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\User\\Desktop\\ПЗ\\ВІПЗ лаби\\Сама програма\\Result.txt", true);
            Node current = _head;
            writer.WriteLine($"{"",50}~~~ {"List"} ~~~{"",38}");
            writer.WriteLine("\t---------------------------------------------------------------------------------------------");
            writer.WriteLine($"\t|{"",-10}|{"",-20}|{"",-30}|{"",-7}|{"",-8}|{"",-11}|");
            writer.WriteLine($"\t|{" Index",-10}|{" Author",-20}|{" BookName",-30}|{" Year",-7}|{" Pages",-8}|{" Price",-11}|");
            writer.WriteLine($"\t|{"",-10}|{"",-20}|{"",-30}|{"",-7}|{"",-8}|{"",-11}|");
            writer.WriteLine("\t---------------------------------------------------------------------------------------------");
            int i = 0;
            while (current != null)
            {
                writer.WriteLine($"\t|{" " + i + ".",-10}| {current.Information.Author,-19}| " +
                    $"{current.Information.BookTitle,-29}|" +
                    $" {current.Information.YearOfPublishing,-6}|" +
                    $" {current.Information.Pages,-7}|" +
                    $" {current.Information.Price,-10}|");
                writer.WriteLine("\t---------------------------------------------------------------------------------------------");
                current = current.Next;
                i++;
            }
            writer.WriteLine();
            writer.WriteLine();
            writer.Close();
        }
    }
}
