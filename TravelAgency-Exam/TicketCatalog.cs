using System.Linq;

namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class TicketCatalog : ITicketCatalog
    {
        private readonly MultiDictionary<string, Ticket> ticketsCatalog = new MultiDictionary<string, Ticket>(true);

        private Dictionary<string, Ticket> Tickets = new Dictionary<string, Ticket>();

        private OrderedMultiDictionary<DateTime, Ticket> TicketsListDate = new OrderedMultiDictionary<DateTime, Ticket>(true);

        public int airTicketsCount;
        public int busTicketsCount;
        public int trainTicketsCount;

        public string FindTickets(string from, string to)
        {
            var fromToKey = Ticket.CreateFromToKey(from, to);
            if (ticketsCatalog.ContainsKey(fromToKey))
            {
                var ticketsFound = new List<Ticket>();
                foreach (var ticket in ticketsCatalog.Values)
                {
                    if (ticket.FromToKey == fromToKey)
                    {
                        ticketsFound.Add(ticket);
                    }
                }

                var ticketsAsString = GetTickets(ticketsFound);

                return ticketsAsString;
            }

            return "Not found";
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = TicketsListDate.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                var ticketsAsString = GetTickets(ticketsFound);

                return ticketsAsString;
            }

            return "Not found";
        }

        public string AddAirTicket(string airTicketFlightNumber, string from, string to, string airline,
            DateTime dateTime, decimal price)
        {
            return AddAirTicket(airTicketFlightNumber, from, to, airline, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
        }

        string ITicketCatalog.DeleteAirTicket(string airTicketFlightNumber)
        {
            return DeleteAirTicket(airTicketFlightNumber);
        }

        public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
        {
            return AddTrainTicket(from, to, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString(),
                studentPrice.ToString());
        }

        public string DeleteTrainTicket(string departureFromTown, string arrivalToTown, DateTime dateTime)
        {
            return DeleteTrainTicket(departureFromTown, arrivalToTown, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public string AddBusTicket(string departureFromTown, string arrivalToTown, string travelCompany, DateTime dateTime, decimal price)
        {
            return AddBusTicket(departureFromTown, arrivalToTown,
                travelCompany, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
        }

        public string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime)
        {
            return DeleteBusTicket(from, to, travelCompany, dateTime.ToString("dd.MM.yyyy HH:mm"));
        }

        public int GetTicketsCount(TicketType type)
        {
            if (type == TicketType.Air)
            {
                return airTicketsCount;
            }

            if (type == TicketType.Bus)
            {
                return busTicketsCount;
            }

            return trainTicketsCount;
        }

        internal string AddDeleteTicket(Ticket ticket, bool isAdd)
        {
            if (isAdd)
            {
                var key = ticket.getTicket;
                if (Tickets.ContainsKey(key))
                {
                    return "Duplicate ticket";
                }

                Tickets.Add(key, ticket);
                var fromToKey = ticket.FromToKey;
                ticketsCatalog.Add(fromToKey, ticket);
                TicketsListDate.Add(ticket.DepartureDate, ticket);

                return "Ticket added";
            }
            else
            {
                var key = ticket.getTicket;
                if (Tickets.ContainsKey(key))
                {
                    Tickets.Remove(key);
                    var fromToKey = ticket.FromToKey;
                    ticketsCatalog.Remove(fromToKey, ticket);
                    TicketsListDate.Remove(ticket.DepartureDate, ticket);
                
                    return "Ticket deleted";
                }

                return "Ticket does not exist";
            }
        }

        public string AddAirTicket(string airTicketFlightNumber, string from, string to, string airline, string dt,
            string pp)
        {
            var ticket = new AirTicket(airTicketFlightNumber, from, to, airline, dt, pp);
            var result = AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                airTicketsCount++;
            }

            return result;
        }

        protected string DeleteAirTicket(string airTicketFlightNumber)
        {
            var ticket = new AirTicket(airTicketFlightNumber);
            var result = AddDeleteTicket(ticket, false);
            if (result.Contains("deleted"))
            {
                airTicketsCount--;
            }

            return result;
        }

        public string AddTrainTicket(string from, string to, string dt, string pp, string studentpp)
        {
            var ticket = new TrainTicket(from, to, dt, pp, studentpp);
            var result = AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                trainTicketsCount++;
            }

            return result;
        }

        private string DeleteTrainTicket(string departureFromTown, string arrivalToTown, string departureDateAndTime)
        {
            var ticket = new TrainTicket(departureFromTown, arrivalToTown, departureDateAndTime);
            var result = AddDeleteTicket(ticket, false);
            if (result.Contains("deleted"))
            {
                trainTicketsCount--;
            }

            return result;
        }

        protected string AddBusTicket(string departureFromTown, string arrivalToTown, string travelCompany, string departureDateAndTime, string ticketPrice)
        {
            var busTicket = new BusTicket(departureFromTown, arrivalToTown, travelCompany, departureDateAndTime, ticketPrice);
            var key = busTicket.getTicket;
            string result;
            if (Tickets.ContainsKey(key))
            {
                result = "Duplicate ticket";
            }
            else
            {
                Tickets.Add(key, busTicket);
                var fromToKey = busTicket.FromToKey;
                ticketsCatalog.Add(fromToKey, busTicket);
                TicketsListDate.Add(busTicket.DepartureDate, busTicket);
                result = "Ticket added";
            }

            if (result.Contains("added"))
            {
                busTicketsCount++;
            }

            return result;
        }

        private string DeleteBusTicket(string from, string to, string travelCompany, string departureDateAndTime)
        {
            var ticket = new BusTicket(from, to, travelCompany, departureDateAndTime);
            var result = AddDeleteTicket(ticket, false);
            if (result.Contains("deleted"))
            {
                busTicketsCount--;
            }

            return result;
        }

        internal static string GetTickets(ICollection<Ticket> tickets)
        {
            // Comment: Bottleneck description "Removed unnecessary loop"
            var sortedTickets = new List<Ticket>(tickets);
            sortedTickets.Sort();
            var separator = " ";

            return String.Join(separator, sortedTickets);
        }

        public string findTicketsInInterval(string startDateTimeStr, string endDateTimeStr)
        {
            var startDateTime = Ticket.ParseDateTime(startDateTimeStr);
            var endDateTime = Ticket.ParseDateTime(endDateTimeStr);
            var ticketsAsString = FindTicketsInInterval(startDateTime, endDateTime);
            
            return ticketsAsString;
        }

        public string FindTicketsInInterval2(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = TicketsListDate.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                var ticketsAsString = GetTickets(ticketsFound);

                return ticketsAsString;
            }

            return "Not found";
        }

        internal string parseCommand(string userInput)
        {
            if (userInput == "")
            {
                return "Invalid command!";
            }

            var firstSpaceIndex = userInput.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return "Invalid command!";
            }

            var commandLine = "";
            var userCommand = userInput.Substring(0, firstSpaceIndex);
            switch (userCommand)
            {
                case "AddAir":
                    var allParameters = userInput.Substring(firstSpaceIndex + 1);
                    var parameters = allParameters.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = AddAirTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
                    break;

                case "DeleteAir":
                    allParameters = userInput.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = DeleteAirTicket(parameters[0]);
                    break;

                case "AddTrain":
                    allParameters = userInput.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = AddTrainTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;

                case "DeleteTrain":
                    allParameters = userInput.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);
                    break;

                case "AddBus":
                    allParameters = userInput.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = AddBusTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                    break;

                case "DeleteBus":
                    allParameters = userInput.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = DeleteBusTicket(parameters[0], parameters[1], parameters[2], parameters[3]);
                    break;

                case "FindTickets":
                    allParameters = userInput.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = FindTickets(parameters[0], parameters[1]);
                    break;

                case "FindTicketsInInterval":
                    allParameters = userInput.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }

                    commandLine = findTicketsInInterval(parameters[0], parameters[1]);
                    break;
                case "": break;
            }

            return commandLine;
        }
    }
}