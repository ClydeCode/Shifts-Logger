using ConsoleTableExt;

using API.Models;

namespace Client
{
    internal class TableVisualisationEngine
    {
        private readonly List<List<object>> TableData = new();

        internal void Print()
        {
            ConsoleTableBuilder
                .From(TableData)
                .WithTitle("ShiftLogger-App", ConsoleColor.Yellow, ConsoleColor.Black)
                .WithColumn("ID", "Start", "End", "Pay", "Minutes", "Location")
                .ExportAndWriteLine();
        }

        internal void Add(List<Shift> List)
        {
            foreach (Shift Entity in List)
            {
                TableData.Add(
                    new List<object>
                    {
                        Entity.ShiftID,
                        Entity.Start,
                        Entity.End,
                        Entity.Pay,
                        Entity.Minutes,
                        Entity.Location
                    }
                );
            }
        }

        internal void Clear()
        {
            TableData.Clear();
        }
    }
}
