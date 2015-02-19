namespace TravelAgency
{
    internal class BusTicket : Ticket
    {
        public BusTicket(string fromDepartureTown, string toArrivalTown, string travelTravelCompany, string departureDateAndTime, string priceOfTicket)
        {
            FromDepartureTown = fromDepartureTown;
            ToArrivalTown = toArrivalTown;
            TravelCompany = travelTravelCompany;
            DepartureDate = ParseDateTime(departureDateAndTime);
            Price = decimal.Parse(priceOfTicket);
        }

        public BusTicket(string fromDepartureTown, string toArrivalTown, string travelTravelCompany, string departureDateAndTime)
        {
            FromDepartureTown = fromDepartureTown;
            ToArrivalTown = toArrivalTown;
            TravelCompany = travelTravelCompany;
            DepartureDate = ParseDateTime(departureDateAndTime);
        }

        public override string Type
        {
            get { return "bus"; }
        }

        public override string getTicket
        {
            get
            {
                return Type + ";;" + FromDepartureTown + ";" + ToArrivalTown + ";" + TravelCompany + DepartureDate + ";";
            }
        }
    }
}
