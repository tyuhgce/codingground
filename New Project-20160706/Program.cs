using System;
using System.Collections.Generic;
using DataWorks;

internal class Program
{
    private static void Main(string[] args)
    {
        // 1.Реализовать двусвязный список и написать функцию, 
        // возвращающую перевернутый двусвязный список произвольного размера)
        Console.WriteLine("Task 1:");

        var ll = new DataWorks.LinkedList<int>();

        // Переворачиваем пустой список
        ll.Reverse();
        var first = ll.AddFirst(2);
        ll.Reverse();

        ll.AddFirst(1);
        ll.AddLast(3);
        ll.AddLast(4);
        ll.AddLast(5);
        ll.AddLast(6);
        var end = ll.AddLast(7);

        ll.RemoveFirst();
        ll.RemoveLast();

        ll.AddBefore(first, 1);
        // end - удаленный узел, вставка не должна произойти.
        ll.AddAfter(end, 1);

        Console.WriteLine("Source List:: ");
        foreach (var v in ll)
            Console.Write(v + " ");
        Console.WriteLine();

        ll.Reverse();

        Console.WriteLine("Reverse List: ");
        foreach (var v in ll)
            Console.Write(v + " ");
        Console.WriteLine("\n");

        // 2. Сосчитать число ‘счастливых’ билетов, где число цифр в номере билета 2N. 
        // Счастливым считается билет, у которого сумма цифр первой половины 
        // номера равняется сумме цифр второй. 178321 – не счастливый (1+7+8 != 3+2+1), 
        // 252162 – счастливый (2+5+2 = 1+6+2). Нумерация начинается с номера из одних нолей.

        // Задача решена с помощью метода динимического программирования.
        // В качестве сильной стороны решения можно отметить, что>

        // a) на вход метод может принять список размерностей билетов, что позволяет
        // просчитывать количество счастливых их за одних проход, а не делать это каждый раз 
        // для каждой размерности.

        // b) класс хранит свое состояние, т.е. если было посчитано, например, до 10 размерности,
        // то есть возможность продолжить вычисления дальше именно с этого момента, а не
        // вычислять все заного.
        Console.WriteLine("Task 2:");

        var hp = new HappyTickets();
        var i = 2;

        foreach (var c in hp.GetCountTickets(new List<int> {2, 4, 6, 8, 10}))
        {
            Console.WriteLine("{0}: \t{1}", i, c);
            i += 2;
        }
        foreach (var c in hp.GetCountTickets(new List<int> {12, 14, 16, 18, 20}))
        {
            Console.WriteLine("{0}: \t{1}", i, c);
            i += 2;
        }
        try
        {
            hp.GetCountTickets(new List<int> {22});
        }
        catch (OverflowException exception)
        {
            Console.WriteLine("{0}: \t{1}", 22, exception.Message);
        }
        Console.WriteLine("\n");
        // 3.Написать функцию, которая переворачивает только гласные в строке. 
        // Пример «Привет»=>”Превит”

        // Алгоритм похож на тот, что используется в быстрой сортировке.
        Console.WriteLine("Task 3:");
        const string str = "Привет";
        const string str2 = "Hellow";
        Console.WriteLine("{0} --> {1}", str, str.ReverseVowels());
        Console.WriteLine("{0} --> {1}", str2, str2.ReverseVowels());
        Console.WriteLine("\n");

        // 4. Написать функцию, которая преобразует строку с римским числом в целое 
        // (иными словами, написать тело функции public int RomanToInt(string s)). 
        // Римское число не больше 3000.
        Console.WriteLine("Task 4:");

        string[] romanNumbers =
        {
            "I",
            "II",
            "III",
            "IV",
            "V",
            "VI",
            "VII",
            "VIII",
            "IX",
            "X",
            "XI",
            "XII",
            "XIII",
            "XIV",
            "XV",
            "XVI",
            "XVII",
            "XVIII",
            "XIX",
            "XX",
            "XXI",
            "XXX",
            "XL",
            "L",
            "LX",
            "LXX",
            "LXXX",
            "XC",
            "C",
            "CC",
            "CCC",
            "CD",
            "D",
            "DC",
            "DCC",
            "DCCC",
            "CM",
            "M",
            "MM",
            "MMM",
            "MMMIM",
            "MCMLXIII",
            "MCMLXIV",
            "LXXXVIII"
        };

        foreach (var s in romanNumbers)
            Console.WriteLine("{0}: \t{1}", s, Conventer.RomanToInt(s));
    }
}