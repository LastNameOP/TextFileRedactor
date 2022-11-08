using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChange
{
    internal class UserTool
    {
        TextRedactor tr;

        public void StartWork()
        {
            while (true)
            {
                Console.WriteLine("Введите путь к файлу");
                string dir = Console.ReadLine();
                if (File.Exists(dir))
                {
                    tr = new TextRedactor(dir);
                    break;
                }
                else Console.WriteLine("Неверный путь");
            }
            Console.WriteLine("Работа с текстовым файлом");
            while (true)
            {
                try
                {
                    Console.WriteLine("\t1 - записать строку,\n\t2 - получить строку,\n\t3 - получить весь документ,\n\t4 - перезаписать строку\n");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("\nВведите строку: ");
                            tr.Write(Console.ReadLine());
                            Console.WriteLine("Строка записана...\n");
                            break;
                        case 2:
                            Console.WriteLine("\nВведите номер строки, которую хотите получить");
                            int line = int.Parse(Console.ReadLine());
                            if (line < 5000)
                                Console.WriteLine("\nВаша строка: " + tr.Read(line) + "\n");
                            else 
                                Console.WriteLine("Строка слишком далеко...");
                            break;
                        case 3:
                            Console.WriteLine("\nВаш файл:");
                            Console.WriteLine(tr.ReadAll() + "\n");
                            break;
                        case 4:
                            Console.WriteLine("Введите номер строки, которую хотите перезаписать");
                            int line1 = int.Parse(Console.ReadLine());
                            if (tr.Read(line1) != string.Empty)
                            {
                                Console.WriteLine("Введите строку:");
                                string mes = Console.ReadLine();
                                tr.ResetFile(line1, mes);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Что-то не так, попробуйте ещё раз");
                }
            }
        }
    }
}
