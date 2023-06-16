using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_trip_orga.Service
{
    public interface IActivity
    {
        public List<Activity> GetAllActivity();

        public Activity GetByID(int idActivity);
        public Activity Insert(Activity a);
        public Activity Update(Activity a);
        public void Delete(Activity a);
    }
}
