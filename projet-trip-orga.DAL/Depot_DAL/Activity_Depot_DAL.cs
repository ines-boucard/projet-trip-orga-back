using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_trip_orga.DAL.Depot_DAL
{
    public class Activity_Depot_DAL : Depot_DAL<Activity_DAL>
    {
        public Activity_Depot_DAL()
            : base()
        {

        }
        public override List<Activity_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, name, description, duration, localisation, phone_number, price from activity";
            var reader = commande.ExecuteReader();

            var listeActivity = new List<Activity_DAL>();

            while (reader.Read())
            {
                var activity = new Activity_DAL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));

                listeActivity.Add(activity);
            }

            DetruireConnexionEtCommande();

            return listeActivity;
        }
        public override Activity_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, name, description, duration, localisation, phone_number, price from activity"
            + " where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var listActivities = new List<Activity_DAL>();

            Activity_DAL activity;
            if (reader.Read())
            {
                activity = new Activity_DAL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));
            }
            else
                throw new Exception($"Pas de activité dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return activity;
        }
        public override Activity_DAL Insert(Activity_DAL activity)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into activity (description, duration, localisation, name, phone_number, price)"
                                    + " values (@description, @duration, @localisation, @name, @phone_number, @price); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@description", activity.Description));
            commande.Parameters.Add(new SqlParameter("@duration", activity.Duration));
            commande.Parameters.Add(new SqlParameter("@localisation", activity.Localisation));
            commande.Parameters.Add(new SqlParameter("@name", activity.Name));
            commande.Parameters.Add(new SqlParameter("@phone_number", activity.PhoneNumber));
            commande.Parameters.Add(new SqlParameter("@price", activity.Price));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            activity.ID = ID;

            DetruireConnexionEtCommande();

            return activity;
        }

        public override Activity_DAL Update(Activity_DAL activity)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update activity set  description = @description, duration = @duration, localisation = @localisation, name = @name, phone_number = @phone_number, price = @price "
                                    + " where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", activity.ID));
            commande.Parameters.Add(new SqlParameter("@description", activity.Description));
            commande.Parameters.Add(new SqlParameter("@duration", activity.Duration));
            commande.Parameters.Add(new SqlParameter("@localisation", activity.Localisation));
            commande.Parameters.Add(new SqlParameter("@name", activity.Name));
            commande.Parameters.Add(new SqlParameter("@phone_number", activity.PhoneNumber));
            commande.Parameters.Add(new SqlParameter("@price", activity.Price));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'activite avec l'ID  {activity.ID}");
            }

            DetruireConnexionEtCommande();

            return activity;
        }
        public override void Delete(Activity_DAL activity)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from activity where id = @ID";
            commande.Parameters.Add(new SqlParameter("@ID", activity.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'activite avec l'ID {activity.ID}");
            }

            DetruireConnexionEtCommande();
        }

    }
}
