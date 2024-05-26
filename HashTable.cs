using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10;

namespace лабораторная_12_2_часть_хеш
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>[] table;
        public int Capacity => table.Length;

        //konsrtuct
        public MyHashTable(int length )
        {
            table = new Point<T>[length];
        }

        //public
        public void PrintTable()
        {
            try
            {


                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine($"{i+1}-ый элемент: ");
                    if (table[i] != null) //не пустая ссылка
                    {
                        Console.WriteLine(table[i].Data); //вывод инф пол
                        if (table[i].Next != null)//если цепочка не пустая
                        {
                            Point<T> current = table[i].Next;//двигаемся по цепочке выводя инф поле
                            while (current != null)
                            {
                                Console.WriteLine(current.Data);
                                current = current.Next;
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Таблица пуста");
            }
        }

        public int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }
        public int  AddPoint(T data)
        {
            if (table != null)
            {
                int index = GetIndex(data); //индекс в таблице
                if (table[index] == null) // в ячейке таблицы нет цепочки
                {
                    table[index] = new Point<T>(data); // добавление элемента

                    return 1;
                }
                else
                {
                    Point<T> current = table[index]; // "указатель" стоит на первом элементе в цепочке

                    while (current.Next != null)
                    {
                        if (current.Data.Equals(data)) // проверка на существование добавляемого элемента
                            return -1; // такой элемент уже есть
                        current = current.Next; 
                    }
                    current.Next = new Point<T>(data); // создаем новый элемент
                    current.Next.Pred = current; //связь предыдущего
                    return 1;
                }
            }
            return 0;
        }


        public Point<T> FindName(string name)
        {
            if (table == null)
            {
                return null;
            }
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null)
                {
                    if (table[i].Data is BankCard b && b.Name.Equals(name))
                        return table[i];
                    else if (table[i].Next != null)
                    {
                        Point<T> current = table[i].Next;
                        while (current != null)
                        {
                            if (current.Data is BankCard bank && bank.Name.Equals(name))
                                return current;
                            current = current.Next;
                        }
                    }
                }

            }
            return null;
        }

        public int SearchName(string name)
        {
            if (table == null)
            {
                return 0;
            }
            else
            {
                Point<T> point = FindName(name);
                if (point != null)
                {
                    int index = GetIndex(point.Data);
                    if (table[index] == null) //если цепочка пустая, искомого элемента нет
                        return -1;
                    else if (table[index].Data.Equals(point.Data))
                        return 1;
                    else  // идем по цепочке
                    {
                        Point<T> current = table[index];
                        while (current != null)
                        {
                            if (current.Data.Equals(point.Data))
                                return 1;
                            current = current.Next;
                        }


                    }
                }
                return -1;
            }

        }


        //public bool Contains( T data)
        //{
        //    int index = GetIndex(data);
        //    if (table == null) throw new Exception();
        //    if (table[index] == null)
        //        return false;
        //    if (table[index].Data.Equals(data))
        //        return true;
        //    else
        //    {
        //        Point<T> current = table[index];
        //        while (current != null)
        //        {
        //            if (current.Equals(data)) return true;
        //            current = current.Next;
        //        }
        //    }
        //    return false;
            
        //}

        

        public int RemoveData(string name)
        {
            if (table == null)
            {
                return 0;
            }
            else
            {
                Point<T> item = FindName(name);
                if (item != null)
                {
                    Point<T> current;
                    int index = GetIndex(item.Data);
                    if (table[index] == null) // пустая цепочка
                        return -1;
                    else if (table[index].Data.Equals(item.Data)) // если первый элемент в цепочке - искомый
                    {
                        if (table[index].Next == null) // один элемент в цепочке
                            table[index] = null; //"обнуляем" полностью цепочку
                        else // если элементов несколько
                        {
                            table[index] = table[index].Next; //ставим ссылку на слудющий эл-т
                            table[index].Pred = null;
                        }
                        return 1;
                    }
                    else // если искомый элемент в середине/конце цепочки
                    {
                        current = table[index];
                        while (current != null) //идем до конца цепочки
                        {
                            if (current.Data.Equals(item.Data))
                            {
                                Point<T> pred = current.Pred;
                                Point<T> next = current.Next;
                                pred.Next = next;
                                current.Pred = null;
                                if (next != null) //если такой элемнт сущ-т
                                    next.Pred = pred;
                                return 1;
                            }
                            current = current.Next;
                        }
                    }
                }
                return -1;
            }
        }


    }
}
 
