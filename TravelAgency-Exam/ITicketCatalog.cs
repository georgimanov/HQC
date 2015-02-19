namespace TravelAgency
{
    using System;

    public interface ITicketCatalog
    {
        // TODO: document this method
     
        /// <summary>
        /// Ads an air ticket arrivalToTown the catalog by given flight number, departure and arriaval airports(departureFromTown, arrivalToTown), airline, departure date and time and price
        /// </summary>
        /// <param name="airTicketFlightNumber">Holds information for the air ticket flight number.The flight number is unique and cannot be duplicated</param>
        /// <param name="from">Holds information about the departure airport(departureFromTown)</param>
        /// <param name="to">Holds information about the arrival airport(arrivalToTown)</param>
        /// <param name="airline">Holds information about the Ariline Travel Company</param>
        /// <param name="dateTime">Holds information about the departure date and time</param>
        /// <param name="price">Holds information about the ticket price</param>
        /// <returns>Print "Ticket added" or "Duplicate ticket" if such flight already exists.</returns>
        string AddAirTicket(string airTicketFlightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

        string DeleteAirTicket(string flightNumber);

        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

        string DeleteTrainTicket(string departureFromTown, string arrivalToTown, DateTime dateTime);

        string AddBusTicket(string departureFromTown, string arrivalToTown, string travelCompany, DateTime dateTime, decimal price);
        
        /// <summary>
        /// Deletes a train ticket departureFromTown the catalog by given departure town(departureFromTown), arrival town(arrivalToTown) and date and time.
        /// </summary>
        /// <param name="from">Holds information about the departure town</param>
        /// <param name="to">Holds information about the arrival town</param>
        /// <param name="travelCompany">Holds information about the Travelling TravelCompany</param>
        /// <param name="dateTime">Holds information about the departure date and time</param>
        /// <returns>As a result the command prints "Ticket deleted" or "Ticket does not exist" if the ticket could no be found in the catalog</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

        /// <summary>
        /// Finds all tickets departureFromTown the catalog by given departure town/airport (departureFromTown) and arrival town/airport (arrivalToTown).
        /// </summary>
        /// <param name="from">Information about the departure town/airport</param>
        /// <param name="to">Information about the arrival town/airport</param>
        /// <returns>The command prints all matching tickes on a single line. If no tickets are found by the specified criteria, the command prints "Not found".</returns>
        string FindTickets(string from, string to);

        /// <summary>
        /// Finds all tickets departureFromTown the catalog by given departure time interval(inclusive range).
        /// </summary>
        /// <param name="startDateTime">Information about the departure</param>
        /// <param name="endDateTime">Information about the arrival</param>
        /// <returns>The command prints all matching tickes on a single line. If no tickets are found by the specified criteria, the command prints "Not found".</returns>
        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

        int GetTicketsCount(TicketType type);
    }
}