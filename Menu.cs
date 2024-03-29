﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProgram
{
    public sealed class Menu
    {
        // Змінна-маркер, яка показує чи відбувався запис інформації з файлу або консолі.
        public static bool IsInputPerformed = false;

        // Голова списку.
        private  static Node s_head;

        // Змінна для роботи з Select запитом.
        private Select _select;

        // Змінна для роботи з Input запитом.
        private Input _input;

        // Змінна для роботи з Output запитом.
        private Output _output;

        // Змінна для роботи з Edit запитом.
        private Edit _edit;

        // Метод показу меню в консоль і повернення вибору.
        private int DispLayMenuAndChoose(bool isInputPerformed)
        {
            if (!isInputPerformed)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("\t\t\t    ~~~ MENU ~~~\n");
                Console.WriteLine("\t 1. Input");
                Console.WriteLine("\t 2. Add");
                Console.WriteLine("\t 3. Edit");
                Console.WriteLine("\t 4. Select");
                Console.WriteLine("\t 5. Delete");
                Console.WriteLine("\t 6. Sort");
                Console.WriteLine("\t 7. Output");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("\t\t\t    ~~~ MENU ~~~\n");
                Console.WriteLine("\t 1. Add");
                Console.WriteLine("\t 2. Edit");
                Console.WriteLine("\t 3. Select");
                Console.WriteLine("\t 4. Delete");
                Console.WriteLine("\t 5. Sort");
                Console.WriteLine("\t 6. Output");
                Console.WriteLine();
            }

            int choice;
            do
            {
                Console.Write("Your choice : ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (!isInputPerformed)
                    {
                        if (choice < 1 || choice > 7)
                        {
                            Console.WriteLine("Error. Invalid number!!!! TRY again\n");
                            continue;
                        }

                        if (choice >= 3 && choice <= 7)
                        {
                            Console.WriteLine("Error. Invalid operation choosed(list is empty). TRY again\n");
                            continue;
                        }

                        break;
                    }
                    else
                    {
                        if (choice < 1 || choice > 6)
                        {
                            Console.WriteLine("Error. Invalid number!!!! TRY again\n");
                            continue;
                        }

                        break;
                    }
                }

                Console.WriteLine("Error, you entered invalid symbols!!!! TRY again\n");

            } while (true);

            return isInputPerformed ? choice + 1 : choice;
        }

        // Основна функція для роботи з командами меню.
        public void MainMenu()
        {
            int choice = DispLayMenuAndChoose(IsInputPerformed);

            switch (choice)
            {
                case (int)Commands.Input:
                    _input = new Input();
                    s_head = _input.InputFunc();
                    break;

                case (int)Commands.Add:
                    IsInputPerformed = true;
                    ListCommands.Add(ref s_head);
                    break;

                case (int)Commands.Select:
                    _select = new Select(s_head);
                    _select.SelectFunc();
                    break;

                case (int)Commands.Delete:
                    ListCommands.Delete(ref s_head);
                    break;

                case (int)Commands.Sort:
                    ListCommands.SortBooksWithPagesLessThanAverage(s_head);
                    break;

                case (int)Commands.Output:
                    _output = new Output(s_head);
                    _output.OutputFunc();
                    break;

                case (int)Commands.Edit:
                    _edit = new Edit(s_head);
                    _edit.EditFunc();
                    break;

                default:
                    break;
            }
        }
    }

    public enum Fields
    {
        Author = 1,
        BookTitle,
        YearOfPublishing,
        Pages,
        Price
    }

    public enum Commands
    {
        Input = 1,
        Add,
        Edit,
        Select,
        Delete,
        Sort,
        Output,
    }
}
