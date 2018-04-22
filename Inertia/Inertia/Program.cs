using System;
using System.IO;
using System.Collections.Generic;

namespace Inertia
{
    class Program
    {
        public static void Main()
        {
            Console.Clear();
            TextReader reader1 = new StreamReader("../../logo.txt");
            string line;
            int y = 7;
            while ((line = reader1.ReadLine()) != null) {
                Console.SetCursorPosition(15, y);
                Console.WriteLine(line);
                y++;
            }
            reader1.Close();
            Console.SetCursorPosition(25, y + 1);
            Console.Write("Enter the number of level: ");
            int level = Convert.ToInt32(Console.ReadLine());
            while (level != 1 && level != 2 && level != 3)
            {
                Console.SetCursorPosition(25, y + 1);
                Console.Write("Sorry, this level wasn't wound!");
                Console.SetCursorPosition(25, y + 2);
                Console.Write("Enter another number of level: ");
                level = Convert.ToInt32(Console.ReadLine());
            }
            
            List<string> matrix = new List<string>();
            TextReader reader2 = new StreamReader($"../../Levels/level{level:00}.txt");
            while ((line = reader2.ReadLine()) != null) {
               matrix.Add(line);
            }
            reader2.Close();
            
            Game level01 = new Game(matrix);
            level01.Start();
        }
    }
}