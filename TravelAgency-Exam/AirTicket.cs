namespace TravelAgency
{
    internal sealed class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string fromDepartureTown, string toArrivalTown, string airline, string dateAndTimeOfDeparture, string priceOfTicket)
        {
            this.FlightNumber = flightNumber;
            this.FromDepartureTown = fromDepartureTown;
            this.ToArrivalTown = toArrivalTown;
            this.TravelCompany = airline;
            this.DepartureDate = ParseDateTime(dateAndTimeOfDeparture);
            this.Price = decimal.Parse(priceOfTicket);
        }

        public AirTicket(string flightNumber)
        {
            this.FlightNumber = flightNumber;
        }

        public string FlightNumber { get; set; }

        public override string Type
        {
            get
            {
                return "air";
            }
        }

        public override string getTicket
        {
            get
            {
                return Type + ";" + this.FlightNumber;
            }
        }
    }
}