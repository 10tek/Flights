using Airport.DataAccess;
using Airport.Domain;
using System;

namespace Airport.Service
{
    public class TicketSale
    {
        private readonly string connectionString;
        private readonly string providerInvariantName;

        public TicketSale(string connectionString, string providerInvariantName)
        {
            this.connectionString = connectionString;
            this.providerInvariantName = providerInvariantName;
        }

        public void BuyTicket()
        {
            Console.WriteLine("HELLO!");
            Console.WriteLine("Choose flightNumber: ");
            ShowFlights();
            var flightNumber = 0;
            int.TryParse(Console.ReadLine(), out flightNumber);
            Console.WriteLine("Enter your Name");
            Repository<User> userRepos = new Repository<User>(connectionString, providerInvariantName);
            Repository<Ticket> tickedRepos = new Repository<Ticket>(connectionString, providerInvariantName);
            User user = new User();
            Ticket ticket = new Ticket();
            user.FullName = Console.ReadLine();
            userRepos.Add(user);
            tickedRepos.Add(new Ticket
            {
                UserId = user.Id,

            });

        }

        public void ShowFlights()
        {
            Repository<Flight> repository = new Repository<Flight>(connectionString, providerInvariantName);
            var flights = repository.GetAll();

            foreach(var flight in flights)
            {
                Console.WriteLine($"FlightNumber: {flight.FlightNumber}, From: {flight.From}, To: {flight.To}, EmptyPlacesCnt: {flight.SeatCnt - flight.TakenPlacesCnt};");
            }
        }
    }
}
