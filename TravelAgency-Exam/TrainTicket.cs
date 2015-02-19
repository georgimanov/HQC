namespace TravelAgency
{
    internal class TrainTicket : Ticket
    {
        public TrainTicket(string fromDepartureTown, string toArrivalTown, string dapartureDateAndTime, string regularTicketPrice, string studentTicketPrice)
        {
            FromDepartureTown = fromDepartureTown;
            ToArrivalTown = toArrivalTown;
            var dateAndTime = ParseDateTime(dapartureDateAndTime);
            DepartureDate = dateAndTime;
            var regularPrice = decimal.Parse(regularTicketPrice);
            Price = regularPrice;
            var studentPrice = decimal.Parse(studentTicketPrice);
            StudentPrice = studentPrice;
        }

        public TrainTicket(string fromDepartureTown, string toArrivalTown, string dapartureDateAndTime)
        {
            FromDepartureTown = fromDepartureTown;
            ToArrivalTown = toArrivalTown;
            var dateAndTime = ParseDateTime(dapartureDateAndTime);
            DepartureDate = dateAndTime;
        }

        public decimal StudentPrice { get; set; }

        public override string Type
        {
            get { return "train"; }
        }

        public override string getTicket
        {
            get
            {
                return Type + ";" + FromDepartureTown + ";" + ToArrivalTown + ";" + DepartureDate + ";";
            }
        }
    }
}