﻿using API.Models;
using System.Net;
using System.Net.Http.Headers;

namespace Client.Controllers
{
    internal class ClientController
    {
        TableVisualisationEngine TableVisualisationEngine = new();
        static HttpClient client = new();

        internal ClientController()
        {
            client.BaseAddress = new Uri("https://localhost:44312/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Show shifts");
            Console.WriteLine("2. Add shift");
            Console.WriteLine("3. Delete shift");
            Console.WriteLine("4. Update shift");
            Console.WriteLine("5. Exit");
        }

        internal void Print(List<Shift> shifts)
        {
            Console.Clear();
            TableVisualisationEngine.Clear();
            TableVisualisationEngine.Add(shifts);
            TableVisualisationEngine.Print();
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
            List<Shift> shifts = GetAllShiftsAsync("api/shifts").Result;

            Print(shifts);
        }

        private void AddShift()
        {
            DateTime startTime = UserInput.GetDate("Start Time");
            DateTime endTime = UserInput.GetDate("End Time");
            decimal pay = UserInput.GetDecimal("Pay");
            decimal minutes = UserInput.GetDecimal("Minutes");
            string location = UserInput.GetString("Location");

            var shift = new Shift {
                Start = startTime,
                End = endTime,
                Pay = pay,
                Minutes = minutes,
                Location = location
            };

            CreateShiftAsync(shift).Wait();
        }

        private void DeleteShift()
        {
            ShowShifts();

            string id = UserInput.GetIntToString("ID");

            var response = DeleteShiftAsync(id).Result;

            if (response == HttpStatusCode.NotFound)
                Console.WriteLine("ERROR: This record doesn't exist!");
            else if (response == HttpStatusCode.NoContent)
                Console.WriteLine("SUCCESS: Record was deleted");
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

        private async Task CreateShiftAsync(Shift shift)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/shifts", shift);

                response.EnsureSuccessStatusCode();

                Console.WriteLine("Operation was successful!");
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    Console.WriteLine("ERROR: Start date can't be greater than End date...");
                else
                    Console.WriteLine(e);
            }
        }

        private async Task<HttpStatusCode> DeleteShiftAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/shifts/{id}");

            return response.StatusCode;
        }

        private async Task<HttpStatusCode> UpdateShiftAsync(Shift shift)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"shifts/api/{shift.ShiftID}", shift);

            return response.StatusCode;
        }
    }
}
