using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class Airlines
    {
        private int id;
        private string name;
        private string airplane;
        private int seataAvailable;
        private string mealAvailable;

        public Airlines(int id, string name, string airplane, int seataAvailable, string mealAvailable)
        {
            this.id = id;
            this.name = name;
            this.airplane = airplane;
            this.seataAvailable = seataAvailable;
            this.mealAvailable = mealAvailable;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Airplane { get => airplane; set => airplane = value; }
        public int SeataAvailable { get => seataAvailable; set => seataAvailable = value; }
        public string MealAvailable { get => mealAvailable; set => mealAvailable = value; }
    }

    class AirlineMethods
    {
        public List<Airlines> LoadAirline(List<Airlines> airList)
        {
            airList.Add(new Airlines(0, "AirCanada", "Boeing 777", 275, "Chicken"));
            airList.Add(new Airlines(1, "AirIndia", "Airbus A380", 868, "Sushi"));
            airList.Add(new Airlines(2, "Lufthansa", "Airbus A380", 868, "Salad"));
            airList.Add(new Airlines(3, "SunWing", "Airbus A380", 868, "Pasta"));
            airList.Add(new Airlines(4, "Jet Airways", "Boeing 777", 275, "Pasta"));

            return airList;
        }

    }

}
