using System;
using System.Collections.Generic;
using System.Printing.IndexedProperties;
using System.Text;

namespace Midterm
{
    class Passenger
    {
        private int id;
        private int customerId;
        private int flightId;

        public Passenger(int id, int customerId, int flightId)
        {
            this.id = id;
            this.customerId = customerId;
            this.flightId = flightId;
        }

        public int Id { get => id; set => id = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int FlightId { get => flightId; set => flightId = value; }
    }
    class PasssengerMethods
    {
        public List<Passenger> LoadPassenger(List<Passenger> passengerList)
        {
            passengerList.Add(new Passenger(0, 2, 3));
            passengerList.Add(new Passenger(1, 1, 2));
            passengerList.Add(new Passenger(2, 3, 3));
            passengerList.Add(new Passenger(3, 4, 1));
            passengerList.Add(new Passenger(4, 2, 3));


            return passengerList;
        }
    }
}
