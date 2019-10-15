using System;
using System.Collections.Generic;
using System.Text;

namespace Airport.Domain
{
    public class Flight : Entity
    {
        public int FlightNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int SeatCnt { get; set; }
        public int TakenPlacesCnt { get; set; } = 0;
    }
}
