using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_trip_orga.Service
{
    public class Activity
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Localisation { get; set; }
        public int PhoneNumber { get; set; }
        public int Price { get; set; }

        public Activity(int idActivity, String description, String name, int duration, String localisation, int phoneNumber, int price)
                   => (ID, Description, Name, Duration, Localisation, PhoneNumber, Price) = (idActivity, description, name, duration, localisation, phoneNumber, price);

        public Activity(int id)
        {
            ID = id;
        }

    }
}
