using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProgram;

namespace MyProgram
{
    public class Edit
    {
        // Голова однозв'язного списку.
        private Node _head;

        // Конструктор.
        public Edit(Node head)
        {
            _head = head is not null ? head : throw new ArgumentNullException(nameof(head));
        }

        // Метод виведення таблиці з даними в консоль з індексами.
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
                Console.WriteLine($"\t|{" " + i + ".", -10}| {current.Information.Author,-19}| " +
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

        // Метод для модифікації полів елемента типу string.
        private void StrFieldEdit(Node elementToModify, int fieldChoice) 
        {
            // fieldChoice == 1 міняємо поле Author; fieldChoice == 2 поле BookTitle.
            
            if (fieldChoice == 1)
            {
                string author;
                do
                {
                    Console.Write("Enter new Author :");
                    author = Console.ReadLine();
                    if (author.Length > 80 || string.IsNullOrEmpty(author) 
                        || string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("Error. Invalid Author input !!!! TRY again\n");
                        continue;
                    }
                    break;

                } while (true);

                elementToModify.Information.Author = author;
                return;
            }

            string bookTitle;
            do
            {
                Console.Write("Enter new BookTitle :");
                bookTitle = Console.ReadLine();
                if (bookTitle.Length > 80 || string.IsNullOrEmpty(bookTitle)
                    || string.IsNullOrWhiteSpace(bookTitle))
                {
                    Console.WriteLine("Error. Invalid BookTitle input !!!! TRY again\n");
                    continue;
                }

            } while (true);

            elementToModify.Information.BookTitle = bookTitle;
            return;
        }

        // Метод для модифікації полів елемента типу int.
        private void NumFieldEdit(Node elementToModify, int fieldChoice)
        {
            int newValue;
            do
            {
                Console.Write("Enter new value :");
                if (int.TryParse(Console.ReadLine(), out newValue))
                {
                    switch (fieldChoice)
                    {
                        case 1:
                            // Перевірка коректності newValue для поля YearOfPublishing.
                            if (newValue < 0 || newValue > 2023)
                            {
                                Console.WriteLine("Error. New YearOfPublishing is not correct!!!! TRY again\n");
                                continue;
                            }
                            break;
                        case 2:
                            // Перевірка коректності newValue для поля Pages.
                            if (newValue <= 0 || newValue > 4032)
                            {
                                Console.WriteLine("Error. New Pages are not correct!!!! TRY again\n");
                                continue;
                            }
                            break;
                        case 3:
                            // Перевірка коректності newValue для поля Price.
                            if (newValue <= 0 || newValue > 30800000)
                            {
                                Console.WriteLine("Error. New Price is not correct!!!! TRY again\n");
                                continue;
                            }
                            break;
                        default:
                            break;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            // Заміна вибраного поля на newValue.
            // fieldChoice == 1 міняємо поле YearOfPublishing; fieldChoice == 2 поле Pages,
            // fieldChoice == 3 поле Price.
            switch (fieldChoice)
            {
                case 1:
                    elementToModify.Information.YearOfPublishing = newValue;
                    break;
                case 2:
                    elementToModify.Information.Pages = newValue;
                    break;
                case 3:
                    elementToModify.Information.Price = newValue;
                    break;
                default:
                    break;
            }
        }

        // Основна функція для роботи з Edit запросом.
        public void EditFunc()
        {
            ShowTableIntoConsole();

            // Вибір елеметна, поле якого будемо модифікувати і виведення елеметна в консоль.
            int indexEditChoice;
            do
            {
                Console.Write("Enter index of element you wanna change : ");
                if (int.TryParse(Console.ReadLine(), out indexEditChoice))
                {
                    if (indexEditChoice < 0 || indexEditChoice >= ListCommands.BooksCnt)
                    {
                        Console.WriteLine("Error. Invalid number!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            Node current = _head;
            for (int i = 0; i < indexEditChoice; i++)
            {
                current = current.Next;
            }

            Console.WriteLine("Element you wanna edit : \n");
            Console.WriteLine("\t-------------------------------------------------------------------------------");
            Console.WriteLine($"\t| {current.Information.Author,-19}|" +
                    $" {current.Information.BookTitle,-29}|" +
                    $" {current.Information.YearOfPublishing,-6}|" +
                    $" {current.Information.Pages,-6} |" +
                    $" {current.Information.Price,-10}|");
            Console.WriteLine("\t-------------------------------------------------------------------------------\n");

            Console.WriteLine("Enter which field you wanna edit : ");
            Console.WriteLine("\t 1. Author");
            Console.WriteLine("\t 2. BookTitle");
            Console.WriteLine("\t 3. YearOfPublishing");
            Console.WriteLine("\t 4. Pages");
            Console.WriteLine("\t 5. Price\n");

            // Вибір поля вибраного елемента для модифікації.
            int fieldEditChoice;
            do
            {
                Console.Write("Your choice : ");
                if (int.TryParse(Console.ReadLine(), out fieldEditChoice))
                {
                    if (fieldEditChoice < 1 || fieldEditChoice > 5)
                    {
                        Console.WriteLine("Error. Invalid number!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            switch (fieldEditChoice)
            {
                case 1:
                    StrFieldEdit(current, 1); // Модифікація поля Author.
                    break;
                case 2:
                    StrFieldEdit(current, 2); // Модифікація поля BookTitle.
                    break;
                case 3:
                    NumFieldEdit(current, 1); // Модифікація поля YearOfPublishing.
                    break;
                case 4:
                    NumFieldEdit(current, 2); // Модифікація поля Pages.
                    break;
                case 5:
                    NumFieldEdit(current, 3); // Модифікація поля Price.
                    break;
                default:
                    break;
            }

            Console.WriteLine("Editted element : \n");
            Console.WriteLine("\t----------------------------------------------------------------------------------");
            Console.WriteLine($"\t| {current.Information.Author,-19}|" +
                    $" {current.Information.BookTitle,-29}|" +
                    $" {current.Information.YearOfPublishing,-6}|" +
                    $" {current.Information.Pages,-6} |" +
                    $" {current.Information.Price,-10}|");
            Console.WriteLine("\t----------------------------------------------------------------------------------\n");
        }
        
    }
}
