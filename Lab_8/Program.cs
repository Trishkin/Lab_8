using Lab_8.Interfaces;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class List<T> : IEnumerable<T>,IBookEnumerable<T> where T : class  // односвязный список
    {
        public Node<T> head; // головной/первый элемент
        public Node<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Info()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator >>(List<T> c1, int c2)
        {
            Node<T> head = c1.head;
            int trys = 1;
            while (trys != c2)
            {
                head = head.Next;
                trys++;
                if (head == null)
                {
                    return false;
                }
            }

            c1.Remove(head.Data);
            return true;
        }

        public static bool operator +(List<T> c1, T c3)
        {
            Node<T> node = new Node<T>(c3);
            Node<T> head = c1.head;
            Node<T> prev = c1.head;
            int trys = 1;
            Console.WriteLine();
            int c2 = Convert.ToInt32(Console.ReadLine());
            while (trys != c2)
            {
                prev = head;
                head = head.Next;
                trys++;
                if (head == null)
                {
                    c1.Add(c3);
                    return false;
                }
            }
            if (prev != head)
            {
                prev.Next = node;
                node.Next = head;

            }
            else
            {
                c1.AppendFirst(c3);
            }
            return true;

        }

        public static bool operator !=(List<T> c1, List<T> c2)
        {
            return c1.SequenceEqual(c2);
        }
        public static bool operator ==(List<T> c1, List<T> c2)
        {
            return c1.SequenceEqual(c2);
        }

        public class Owner
        {
            public string name;
            public int id;
            public string organization;
            public Owner(int id, string name, string organization)
            {
                this.id = id;
                this.name = name;
                this.organization = organization;
            }
        }

        public static class Date
        {
            static string str = "20.12.2001";
            public static void info()
            { Console.WriteLine(str); }
        }
    }

    public static class StringOperation
    {
        public static string Sum(this List<string> c1,string a, string b)
        {
            string sum;
            sum = a + b;
            c1.Add(sum);
            return sum;
        }
        public static int Difference(this List<string> c1)
        {
            int dif;
            string max= null, min = null;
            int max1=0, min1=0;
            Node<string> node = c1.head;
            while (node != null)
            {
               
                    if (min1 > node.Data.Length || min1 == 0)
                    {
                    min1 = node.Data.Length;
                    min = node.Data;
                    }
                if (max1 < node.Data.Length || max1 == 0)
                {
                    max1 = node.Data.Length;
                    max = node.Data;
                }

                node = node.Next;
            }
            Console.WriteLine($"max = {max}, min = {min}");
            dif = max1 - min1;
            return dif;
        }
        public static int CountElem(this List<string> c1)
        {
            int count = 0;
            Node<string> node = c1.head;
            while (node != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }
        public static string MaxWord(this List<string> c1)
        {
            Node<string> node = c1.head;
            string max = null;
            int maxcounter = 0;
            while (node != null)
            {


                string[] words = node.Data.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > maxcounter)
                    {
                        maxcounter = words[i].Length;
                        max = words[i];
                    }

                }
                node = node.Next;
            }
            return max;
        }
        public static bool DelLast(this List<string> c1)
        {
            c1.Remove(c1.tail.Data);
            return true;
        }
    }


    class Program
    {
        public static void StreamWrite(List<string> dataToWrite)
        {
            string writePath = @"D:\1111\hta.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.Write("");
            }
            try
            {
                foreach (var item in dataToWrite)
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(item);
                    }
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("I'm all");
            }
        }
        public static /*async*/ void StreamRead()
        {
        string path = @"D:\1111\hta.txt";
 
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }

                //using (StreamReader sr = new StreamReader(path))
                //{
                //    Console.WriteLine(await sr.ReadToEndAsync());
                //}
            }
            catch (Exception e)
            {
             Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("I'm all");
            }
        }
static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Abraam");
            list.Add("Linkoln");
            List<char[]> list2 = new List<char[]>();
            list2.Add(("Avraam").ToCharArray());
            list2.Add(("Linkoln").ToCharArray());
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            StreamWrite(list);
            StreamRead();
            //Console.WriteLine("equality");
            //Console.WriteLine(list == list2);
            //Boolean a = list + "sfdf sdfsqqe sdf";
            //Console.WriteLine();
            //Console.WriteLine("add elem");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //a = list >> 2;
            //Console.WriteLine();
            //Console.WriteLine("del elem");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();
            //Console.WriteLine("max word");
            //Console.WriteLine(list.MaxWord());
            //Console.WriteLine();
            //Console.WriteLine("del last elem");
            //Console.WriteLine(list.DelLast());
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //List<string>.Owner owner1 = new List<string>.Owner(1218, "Dima", "OOP");
            //Console.WriteLine($"id = {owner1.id}, name = {owner1.name}, organization = {owner1.organization}");
            //List<string>.Date.info();

            //Console.WriteLine($"Sum = {list.Sum("14", "4")}");
            //Console.WriteLine($"Difference = {list.Difference()}");
            //Console.WriteLine($"CountElem = {list.CountElem()}");
            Console.ReadKey();
        }
    }
}