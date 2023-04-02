using MyProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProgram
{
    // Клас для роботи з запитом Select головного меню.
    public class Select
    {
        // Голова однозв'язного списку.
        private Node _head;

        // Конструктор.
        public Select(Node head)
        {
            _head = head is not null ? head : throw new ArgumentNullException(nameof(head));
        }

        // Головний метод для роботи з Select запитом.
        public void SelectFunc()
        {
            Console.WriteLine("----------------------------------------\n");
            Console.WriteLine("Enter which field you wanna enter : ");
            Console.WriteLine("\t 1. Author");
            Console.WriteLine("\t 2. BookTitle");
            Console.WriteLine("\t 3. YearOfPublishing");
            Console.WriteLine("\t 4. Pages");
            Console.WriteLine("\t 5. Price\n");

            int selChoice;
            do
            {
                Console.Write("Your choice : ");
                if (int.TryParse(Console.ReadLine(), out selChoice))
                {
                    if (selChoice < 1 || selChoice > 5)
                    {
                        Console.WriteLine("Error. Invalid number!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            switch (selChoice)
            {
                case (int)Fields.Author: // Вибираємо елементи за полем Author.
                    AuthorSelect();
                    return;
                case (int)Fields.BookTitle: // Вибираємо елементи за полем BookTitle.
                    BookTitleSelect();
                    return;
                case (int)Fields.YearOfPublishing: // Вибираємо елементи за полем YearOfPublishing.
                    YearOfPublisingSelect();
                    return;
                case (int)Fields.Pages: // Вибираємо елементи за полем Pages.
                    PagesSelect();
                    return;
                case (int)Fields.Price: // Вибираємо елементи за полем Price.
                    PriceSelect();
                    return;
                default:
                    break;
            }
        }

        // Метод для роботи з запитом Select для поля Author.
        private void AuthorSelect()
        {
            string str;
            Console.Write("Enter string that Author field is containing : ");
            str = Console.ReadLine();
            if (str.Length > 20)
            {
                Console.WriteLine("No element in list has Author field with specific substring\n");
                return;
            }

            // Вибір елементів, які містять заданий підрядок str у полі Author.
            Node curAu = _head;
            List<Node> resAu = new List<Node>();
            while (curAu != null)
            {
                if (curAu.Information.Author.Contains(str))
                {
                    resAu.Add(curAu);
                }

                curAu = curAu.Next;
            }

            if (resAu.Count == 0)
            {
                Console.WriteLine("No element in list has Author field with specific substring\n");
                return;
            }

            ShowSelectedElements(resAu);
            return;
        }

        // Метод для роботи з запитом Select для поля BookTitle.
        private void BookTitleSelect()
        {
            string str;
            Console.Write("Enter string that BookTitle field is containing : ");
            str = Console.ReadLine();
            if (str.Length > 20)
            {
                Console.WriteLine("No element in list has Author field with specific substring\n");
                return;
            }

            // Вибір елементів, які містять заданий підрядок str у полі BookTitle.
            Node curBT = _head;
            List<Node> resBT = new List<Node>();
            while (curBT != null)
            {
                if (curBT.Information.Author.Contains(str))
                {
                    resBT.Add(curBT);
                }

                curBT = curBT.Next;
            }

            if (resBT.Count == 0)
            {
                Console.WriteLine("No element in list has Author field with specific substring\n");
                return;
            }

            ShowSelectedElements(resBT);
        }

        // Метод для роботи з запитом Select для поля YearOfPublishing.
        private void YearOfPublisingSelect()
        {
            int operChoice = OperatorChoice();

            // Введння року, з яким будемо порівнювати поле YearOfPublishing.
            int year;
            do
            {
                Console.Write("Enter year : ");
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    if (year < 0 || year > 2023)
                    {
                        Console.WriteLine("Error. Invalid year!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            Node current = _head;
            List<Node> res = new List<Node>();

            // Заповнення списку з результатом для умови YearOfPublishing < year.
            if (operChoice == 1)
            {
                while (current != null)
                {
                    if (current.Information.YearOfPublishing < year)
                    {
                        res.Add(current);
                    }

                    current = current.Next;
                }
            }

            // Заповнення списку з результатом для умови YearOfPublishing > year.
            if (operChoice == 2)
            {
                while (current != null)
                {
                    if (current.Information.YearOfPublishing == year)
                    {
                        res.Add(current);
                    }

                    current = current.Next;
                }
            }

            // Заповнення списку з результатом для умови YearOfPublishing == year.
            while (current != null)
            {
                if (current.Information.YearOfPublishing > year)
                {
                    res.Add(current);
                }

                current = current.Next;
            }

            // Виведення результатів по Select для поля YearOfPublishing.
            if (res.Count == 0)
            {
                Console.WriteLine($"No element in list has YearOfPublishing equal to {year}\n");
                return;
            }

            ShowSelectedElements(res);
        }

        // Метод для роботи з запитом Select для поля Pages.
        private void PagesSelect()
        {
            // Вибір оператора(>, =, <), за допомогою якого будемо роботи обмеження на Select
            // для поля Pages.
            int operChoice = OperatorChoice();

            // Введння к-сті сторінок, з якими будемо порівнювати поле Pages.
            int pages;
            do
            {
                Console.Write("Enter pages : ");
                if (int.TryParse(Console.ReadLine(), out pages))
                {
                    if (pages < 0 || pages > 4032)
                    {
                        Console.WriteLine("Error. Invalid pages!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            Node current = _head;
            List<Node> res = new List<Node>();

            // Заповнення списку з результатом для умови Pages < pages.
            if (operChoice == 1)
            {
                while (current != null)
                {
                    if (current.Information.Pages < pages)
                    {
                        res.Add(current);
                    }

                    current = current.Next;
                }
            }

            // Заповнення списку з результатом для умови Pages > pages.
            if (operChoice == 3)
            {
                while (current != null)
                {
                    if (current.Information.Pages > pages)
                    {
                        res.Add(current);
                    }

                    current = current.Next;
                }
            }

            // Заповнення списку з результатом для умови Pages == pages.
            while (current != null)
            {
                if (current.Information.Pages == pages)
                {
                    res.Add(current);
                }

                current = current.Next;
            }

            // Виведення результатів по Select для поля Pages.
            if (res.Count == 0)
            {
                Console.WriteLine($"No element in list has Pages equal to {pages}\n");
                return;
            }

            ShowSelectedElements(res);
        }

        // Метод для роботи з запитом Select для поля Pages.
        private void PriceSelect()
        {
            // Вибір оператора(>, =, <), за допомогою якого будемо роботи обмеження на Select
            // для поля Price.
            int operChoice = OperatorChoice();
            
            // Введння ціни, з якою будемо порівнювати поле Price.
            int price;
            do
            {
                Console.Write("Enter price : ");
                if (int.TryParse(Console.ReadLine(), out price))
                {
                    if (price < 0 || price > 30800000)
                    {
                        Console.WriteLine("Error. Invalid price!!!! TRY again\n");
                        continue;
                    }

                    break;
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            Node current = _head;
            List<Node> res = new List<Node>();

            // Заповнення списку з результатом для умови Price < price.
            if (operChoice == 1)
            {
                while (current != null)
                {
                    if (current.Information.Pages < price)
                    {
                        res.Add(current);
                    }

                    current = current.Next;
                }
            }
            else
            {
                // Заповнення списку з результатом для умови Price > price.
                if (operChoice == 3)
                {
                    while (current != null)
                    {
                        if (current.Information.Pages > price)
                        {
                            res.Add(current);
                        }

                        current = current.Next;
                    }
                }
                else
                {
                    // Заповнення списку з результатом для умови Price == price.
                    while (current != null)
                    {
                        if (current.Information.Pages == price)
                        {
                            res.Add(current);
                        }

                        current = current.Next;
                    }
                }
            }
            
            // Виведення результатів по Select для поля Price.
            if (res.Count == 0)
            {
                Console.WriteLine($"No element in list has Price equal to {price}\n");
                return;
            }

            ShowSelectedElements(res);
        }

        // Метод вибору оператора(>, =, <), за допомогою якого будемо роботи обмеження на поля.
        private int OperatorChoice()
        {
            Console.WriteLine("---------------------------------------------------------\n");
            Console.WriteLine("                      ~ Operator ~                     \n");
            Console.WriteLine("   1. '<'               2. '='                  3. '>'   \n");
            int operChoice;
            do
            {
                Console.Write("Your choice : ");
                try
                {
                    operChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Error invalid symblos for operator choice!!!! TRY again\n");
                    continue;
                }

                if (!(operChoice is 1 or 2 or 3))
                {
                    Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");
                    continue;
                }

                break;

            } while (true);

            return operChoice;
        }
        
        // Метод виведення елементів у консоль, вибраних за умовами, заданими в Select.
        private void ShowSelectedElements(List<Node> list)
        {
            Console.WriteLine($"\n{"",38}~~~ Selected Elements ~~~{"",38}");
            Console.WriteLine("\t-------------------------------------------------------------------------------");
            Console.WriteLine($"\t|{"",-20}|{"",-30}|{"",-7}|{"",-8}|{"",-8}|");
            Console.WriteLine($"\t|{"Author",-20}|{"BookName",-30}|{"Year",-7}|{"Pages",-8}|{"Price",-8}|");
            Console.WriteLine($"\t|{"",-20}|{"",-30}|{"",-7}|{"",-8}|{"",-8}|");
            Console.WriteLine("\t-------------------------------------------------------------------------------");
            foreach (var item in list)
            {
                Console.WriteLine($"\t|{item.Information.Author,-20}|" +
                    $"{item.Information.BookTitle,-30}|" +
                    $" {item.Information.YearOfPublishing,-6}|" +
                    $" {item.Information.Pages,-6} |" +
                    $" {item.Information.Price,-6} |");
                Console.WriteLine("\t-------------------------------------------------------------------------------");
            }
        }
    }

}
