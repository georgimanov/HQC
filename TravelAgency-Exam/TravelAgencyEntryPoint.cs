namespace TravelAgency
{
    using System;

    internal class TravelAgencyEntryPoint
    {
        private static void Main()
        {
            var ticketCatalog = new TicketCatalog();
            while (true)
            {
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    readLine = readLine.Trim();
                    var commandResult = ticketCatalog.parseCommand(readLine);
                    if (commandResult != null)
                    {
                        Console.WriteLine(commandResult);
                    }
                }
            }
        }
    }
}