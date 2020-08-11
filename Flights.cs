using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class Flights
    {
        private int id;
        private int airlineid;
        private string departurecity;
        private string destinationcity;
        private string departuredate;
        private double flighttime;

        public Flights(int id, int airlineid, string departurecity, string destinationcity, string departuredate, double flighttime)
        {
            this.id = id;
            this.airlineid = airlineid;
            this.departurecity = departurecity;
            this.destinationcity = destinationcity;
            this.departuredate = departuredate;
            this.flighttime = flighttime;
        }

        public int Id { get => id; set => id = value; }
        public int Airlineid { get => airlineid; set => airlineid = value; }
        public string Departurecity { get => departurecity; set => departurecity = value; }
        public string Destinationcity { get => destinationcity; set => destinationcity = value; }
        public string Departuredate { get => departuredate; set => departuredate = value; }
        public double Flighttime { get => flighttime; set => flighttime = value; }
    }
    class FlightsMethods {

        public List<Flights> LoadFlights(List<Flights> flightList) {

            flightList.Add(new Flights(0, 2, "Toronto", "Newyork", "20-07-2020", 12.00));
            flightList.Add(new Flights(1, 5, "London", "Newyork", "20-08-2020", 24.00));
            flightList.Add(new Flights(2, 2, "Dehli", "Montrial", "30-09-2020", 1.00));
            flightList.Add(new Flights(3, 3, "Toronto", "Bombay", "20-12-2020", 9.00));
            flightList.Add(new Flights(4, 2, "Toronto", "China", "20-07-2020", 11.00));



            return flightList;
        
        }
    
    
    
    
    
    
    }
}
