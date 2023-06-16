using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_trip_orga.DTO
{
    public class Activity_DTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Localisation { get; set; }
        public int PhoneNumber { get; set; }
        public int Price { get; set; }

    }
}
