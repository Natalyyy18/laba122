using ClassLibrary10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace лабораторная_12_2_часть_хеш
{
    
    internal class Program
    {
        static MyHashTable<BankCard> MakeTable(MyHashTable<BankCard> hashTable)
        {
            BankCard b1 = new BankCard();
            b1.RandomInit();
            var milliseconds = 300;
            Thread.Sleep(milliseconds);
            BankCard b2 = new BankCard();
            b2.RandomInit();
            var milliseconds2 = 300;
            Thread.Sleep(milliseconds);
            CreditCard c1 = new CreditCard();
            c1.RandomInit();
            var milliseconds3 = 300;
            Thread.Sleep(milliseconds);
            CreditCard c2 = new CreditCard();
            c2.RandomInit();
            var milliseconds4 = 300;
            Thread.Sleep(milliseconds);
            YoungCard y1 = new YoungCard();
            y1.RandomInit();
            var milliseconds5 = 300;
            Thread.Sleep(milliseconds);
            YoungCard y2 = new YoungCard();
            y2.RandomInit();

            hashTable = new MyHashTable<BankCard>(6);
            hashTable.AddPoint(b1);
            hashTable.AddPoint(b2);
            hashTable.AddPoint(c1);
            hashTable.AddPoint(c2);
            hashTable.AddPoint(y1);
            hashTable.AddPoint(y2);
            return hashTable;
        }

        static void SearchElement(MyHashTable<BankCard> hashTable)
        {
            string name;
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();

            Point<BankCard> item = hashTable.FindName(name);
            int isExist = hashTable.SearchName(name);
            if (isExist == 0)
            {
                Console.WriteLine($"   Таблица пустая  ");
            }
            else if (isExist == -1)
            {
                Console.WriteLine($"  Элемента ' {name} ' нет в таблице   ");
            }
            else
            {
                Console.WriteLine($"Элемент '{name}' есть в таблице: ' {item} ' находится под индексом: {hashTable.GetIndex(item.Data) + 1}");
            }
        }

        static void DeleteElement(MyHashTable<BankCard> hashTable)
        {
            string name;
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();

            Point<BankCard> item = hashTable.FindName(name);
            int isExist = hashTable.RemoveData(name);
            if (isExist == 0)
            {
                Console.WriteLine($"   Таблица пустая  ");
            }
            else if (isExist == -1)
            {
                Console.WriteLine($"  Элемента ' {name} ' нет в таблице    ");
            }
            else
            {
                Console.WriteLine($"Элемент  '{name}': {item} удален");
            }
        }

        static void AddElem(MyHashTable<BankCard> hashTable)
        {
            BankCard b1 = new BankCard();
            b1.RandomInit();
            int checkAdd = hashTable.AddPoint(b1);
            if (checkAdd == 0)
                Console.WriteLine("Таблица пустая");
            else if (checkAdd == -1)
                Console.WriteLine("Такой элемент уже есть");
            else
                Console.WriteLine($" Элемент {b1} добавлен на место: {hashTable.GetIndex(b1) + 1}");
        }

        public static void PrintMenu()
        {
            Console.WriteLine("\n\t\t<<<<<Меню>>>>>\n");
            Console.WriteLine("1. Сформировать таблицу\n" +
                "2. Печать таблицы \n" +
                "3. Добавление элемента\n" +
                "4. Поиск элемента\n" +
                "5. Удаление элемента\n" +
                "");
        }
       
        static void Main(string[] args)
        {
            string answer = null;
            
            MyHashTable<BankCard> list = new MyHashTable<BankCard>(6);
            

            PrintMenu();

            while (answer != "6")
            {
                Console.Write("Ваш выбор: ");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        list = MakeTable(list);
                        
                        Console.WriteLine("хэш таблица сформирована");
                        break;
                    case "2":
                        try
                        {
                            list.PrintTable();
                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте хэш таблицу.");
                        }
                        break;
                    case "3": //Добавление
                        {
                            Console.WriteLine("Добавление элемента ");
                            AddElem(list);
                            break;
                        }
                    case "4": //Поиск элемента по ключу
                        {
                            Console.WriteLine("Поиск элемента по ключу");
                            SearchElement(list);
                            break;
                        }
                    case "5": //Удаление элемента по ключу
                        {
                            Console.WriteLine("Удаление элемента по ключу ");
                            DeleteElement(list);
                            break;
                        }
                       
                }
            }

        }
    }       
}
