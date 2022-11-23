﻿namespace Client
{
    internal class UserInput
    {
        static internal int GetInt(string title)
        {
            int value = 0;

            while (value == 0)
            {
                Console.WriteLine($"\nInput [{title}]: ");
                string? input = Console.ReadLine();

                Int32.TryParse(input, out value);

                if (value == 0) Console.WriteLine("Wrong format!");
            }

            return value;
        }

        static internal decimal GetDecimal(string title)
        {
            decimal value = 0;

            while (value == 0)
            {
                Console.WriteLine($"\nInput [{title}]: ");
                string? input = Console.ReadLine();

                Decimal.TryParse(input, out value);

                if (value == 0) Console.WriteLine("Wrong format!");
            }

            return value;
        }

        static internal string GetString(string title)
        {
            string? input = "";

            while (input == "")
            {
                Console.WriteLine($"Input [{title}]: ");
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
