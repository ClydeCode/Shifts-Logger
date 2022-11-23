using API.Models;
using System.Net.Http.Headers;

namespace Client.Controllers
{
    internal class ClientController
    {
        TableVisualisationEngine TableVisualisationEngine = new();
        static HttpClient client = new();

        internal void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Show shifts");
            Console.WriteLine("2. Add shift");
            Console.WriteLine("3. Delete shift");
            Console.WriteLine("4. Update shift");
            Console.WriteLine("5. Exit");
        }

        internal void Navigate(int option)
        {
            switch (option)
            {
                case 1:
                    ShowShifts();
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

        private async void ShowShifts()
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            List<Shift> shifts = GetAllShiftsAsync("api/shifts").Result;

            Console.Clear();
            TableVisualisationEngine.Clear();
            TableVisualisationEngine.Add(shifts);
            TableVisualisationEngine.Print();
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

        private async Task<List<Shift>> GetAllShiftsAsync(string path)
        {
            List<Shift> shifts = null;
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                shifts = await response.Content.ReadAsAsync<List<Shift>>();
            }
            return shifts;
        }
    }
}
