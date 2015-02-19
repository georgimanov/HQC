namespace TravelAgency
{
    using System;
    using System.Globalization;

    internal abstract class Ticket : IComparable<Ticket>
    {
        public abstract string Type { get; }

        public virtual string FromDepartureTown { get; set; }

        public virtual string ToArrivalTown { get; set; }

        public virtual string TravelCompany { get; set; }

        public virtual DateTime DepartureDate { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal SpecialPrice { get; set; }

        public abstract string getTicket { get; }

        public string FromToKey
        {
            get
            {
                return CreateFromToKey(FromDepartureTown, ToArrivalTown);
            }
        }

        public int CompareTo(Ticket otherTicket)
        {
            var compareTo = DepartureDate.CompareTo(otherTicket.DepartureDate);
            if (compareTo == 0)
            {
                compareTo = Type.CompareTo(otherTicket.Type);
            }

            if (compareTo == 0)
            {
                compareTo = Price.CompareTo(otherTicket.Price);
            }
            
            return compareTo;
        }

        public override string ToString()
        {
            return "[" + DepartureDate.ToString("dd.MM.yyyy HH:mm") + "; " + Type + "; " + String.Format("{0:f2}", Price) + "]";
        }

        public static string CreateFromToKey(string from, string to)
        {
            return from + "; " + to;
        }

        public static DateTime ParseDateTime(string departureDate)
        {
            DateTime result = DateTime.ParseExact(departureDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            return result;
        }
    }
}