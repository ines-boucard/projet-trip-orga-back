using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_trip_orga.DAL
{
    public class Activity_DAL
    {
        public int ID { get; set; }
        public List<Activity_DAL> Activities { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Localisation { get; set; }
        public int PhoneNumber { get; set; }
        public int Price { get; set; }

        public Activity_DAL(String description, String name, int duration, String localisation, int phoneNumber, int price)
                   => (Description, Name, Duration, Localisation, PhoneNumber, Price) = (description, name, duration, localisation, phoneNumber, price);
        public Activity_DAL(int idActivity, String description, String name, int duration, String localisation, int phoneNumber, int price)
                   => (ID, Description, Name, Duration, Localisation, PhoneNumber, Price) = (idActivity, description, name, duration, localisation, phoneNumber, price);
    }
}
