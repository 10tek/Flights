using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Domain
{
    public class Ticket : Entity
    {
        public Guid UserId { get; set; }
        public Guid FlightId { get; set; }
    }
}
