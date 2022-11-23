namespace Client
{
    internal class UserInput
    {
        static internal int GetInt(string title)
        {
            int x = 0;

            while (x == 0)
            {
                Console.WriteLine($"\nInput [{title}]: ");
                string? input = Console.ReadLine();

                Int32.TryParse(input, out x);

                if (x == 0) Console.WriteLine("Wrong format!");
            }

            return x;
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
