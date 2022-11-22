
namespace Client.Controllers
{
    internal class ClientController
    {
        internal void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Show shifts");
            Console.WriteLine("2. Add shift");
            Console.WriteLine("3. Delete shift");
            Console.WriteLine("4. Update shift");
            Console.WriteLine("5. Exit");
        }

        internal void Navigate(int Option)
        {
            switch (Option)
            {
                case 1:
                    ShowShift();
                    break;
                case 2:
                    AddShift();
                    break;
                case 3:
                    DeleteShift();
                    break;
                case 4:
                    UpdateShift();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong Option!");
                    break;
            }
        }

        private void ShowShift()
        {
            throw new NotImplementedException();
        }

        private void AddShift()
        {
            throw new NotImplementedException();
        }

        private void DeleteShift()
        {
            throw new NotImplementedException();
        }

        private void UpdateShift()
        {
            throw new NotImplementedException();
        }
    }
}
