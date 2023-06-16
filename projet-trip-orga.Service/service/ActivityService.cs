using projet_trip_orga.DAL;
using projet_trip_orga.DAL.Depot_DAL;

namespace projet_trip_orga.Service.service
{
    public class ActivityService : IActivity
    {
        private Activity_Depot_DAL depotActivity = new Activity_Depot_DAL();

        public List<Activity> GetAllActivity()
        {
            var result = new List<Activity>();

            foreach (var a in depotActivity.GetAll())
            {
                Activity activity = new Activity(a.ID,
                                                   a.Name,
                                                   a.Description,
                                                   a.Duration,
                                                   a.Localisation,
                                                   a.PhoneNumber,
                                                   a.Price);
                result.Add(activity);
            }
            return result;
        }
        public Activity GetByID(int idActivity)
        {
            var a = depotActivity.GetByID(idActivity);

            return new Activity(a.ID,
                                a.Name,
                                a.Description,
                                a.Duration,
                                a.Localisation,
                                a.PhoneNumber,
                                a.Price);
        }

        public Activity Insert(Activity a)
        {
            var activity = new Activity_DAL(a.ID,
                                            a.Name,
                                            a.Description,
                                            a.Duration,
                                            a.Localisation,
                                            a.PhoneNumber,
                                            a.Price);
            depotActivity.Insert(activity);

            a.ID = activity.ID;

            return a;
        }
        public Activity Update(Activity a)
        {
            var adherents = new Activity_DAL(a.ID,
                                            a.Name,
                                            a.Description,
                                            a.Duration,
                                            a.Localisation,
                                            a.PhoneNumber,
                                            a.Price);
            depotActivity.Update(adherents);

            return a;
        }
        public void Delete(Activity a)
        {
            var activityDAL = new Activity_DAL(a.ID,
                                            a.Name,
                                            a.Description,
                                            a.Duration,
                                            a.Localisation,
                                            a.PhoneNumber,
                                            a.Price);
            depotActivity.Delete(activityDAL);
        }
    }
}
