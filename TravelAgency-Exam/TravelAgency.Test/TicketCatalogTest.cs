namespace TravelAgency.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketCatalogTests
    {
        private ITicketCatalog ticketCatalog;

        [TestInitialize]
        public void InitializeTravelAgency()
        {
            this.ticketCatalog = new TicketCatalog(); 
        }

        [TestMethod]
        public void AddTicketShouldReturnTicketAddedMessage()
        {
            var entry = new TicketCatalog();
            var result = entry.AddAirTicket("FX215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2005, 8, 18), 200);
            Assert.AreEqual("Ticket added", result);
        }

        [TestMethod]
        public void AddTicketShouldReturnDuplicateTicketMessage()
        {
            ticketCatalog.AddAirTicket("X215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2005, 8, 18), 200);

            var result = ticketCatalog.AddAirTicket("X215", "Sofia", "Athens", "Bulgaria Air", new DateTime(2005, 8, 18), 200);
            Assert.AreEqual("Duplicate ticket", result);
        }

        // TODO: remove emtry entry
        [TestMethod]
        public void AddEmptyTicketShouldReturnErrorMessage()
        {
            var result = ticketCatalog.AddAirTicket("", "", "", "", new DateTime(), 0);

            Assert.AreEqual("Incorrect command", result);
        }

        [TestMethod]
        public void FindTicketShouldReturnNotFoundMessage()
        {
            var result = ticketCatalog.FindTickets("Sofia", "Kaspichan");

            Assert.AreEqual("Not found", result);
        }

        [TestMethod]
        public void DeleteBusShouldReturnTicketDoesNotExistMessage()
        {
            var result = ticketCatalog.DeleteBusTicket("Sofia", "Athens", "Group plus", new DateTime(2005, 8, 18));

            Assert.AreEqual("Ticket does not exist", result);
        }
    }
}