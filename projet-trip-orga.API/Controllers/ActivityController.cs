using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projet_trip_orga.DTO;
using projet_trip_orga.Service;
using projet_trip_orga.Service.service;

namespace projet_trip_orga.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private IActivity service;
        public ActivityController()
        {
            this.service = new ActivityService();
        }

        [HttpGet]
        public IEnumerable<Activity_DTO> GetAllActivity()
        {
            return service.GetAllActivity().Select(a => new Activity_DTO()
            {
                ID = a.ID,
                Description = a.Description,
                Name = a.Name,
                Duration = a.Duration,
                Localisation = a.Localisation,
                PhoneNumber = a.PhoneNumber,
                Price = a.Price,
            });
        }

        [HttpPost]
        public Activity_DTO Insert(Activity_DTO a)
        {
            var a_metier = service.Insert(new Activity(a.ID,
                                                        a.Description,
                                                        a.Name,
                                                        a.Duration,
                                                        a.Localisation,
                                                        a.PhoneNumber,
                                                        a.Price));
            //Je récupère l'ID
            a.ID = a_metier.ID;
            //je renvoie l'objet DTO
            return a;
        }

        [HttpGet("{id}")]
        public Activity GetByID(int id)
        {
            return service.GetByID(id);
        }

        [HttpPut]
        public Activity Update(Activity_DTO a)
        {
            var a_metier = service.Update(new Activity(a.ID,
                                                        a.Description,
                                                        a.Name,
                                                        a.Duration,
                                                        a.Localisation,
                                                        a.PhoneNumber,
                                                        a.Price));
            //Je récupère l'ID
            a.ID = a_metier.ID;
            //je renvoie l'objet DTO
            return a_metier;
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            service.Delete(new Activity(id));
        }
    }
}
