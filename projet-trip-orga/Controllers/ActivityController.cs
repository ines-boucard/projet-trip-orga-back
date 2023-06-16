//using Microsoft.AspNetCore.Mvc;
//using projet_trip_orga.Service.service;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using projet_trip_orga.Service;
//using projet_trip_orga.DTO;

//namespace projet_trip_orga.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ActivityController : Controller
//    {
//        private IActivity service;

//        public ActivityController(IActivity srv)
//        {
//            service = srv;
//        }
        

//        [HttpGet]
//        public IEnumerable<Activity_DTO> GetAllActivities()
//        {
//            return service.GetAllActivity().Select(a => new Activity_DTO()
//            {
//                ID = a.ID,
//                Description = a.Description,
//                Name = a.Name,
//                Duration = a.Duration,
//                Localisation = a.Localisation,
//                PhoneNumber = a.PhoneNumber,
//                Price = a.Price,

//            });
//        }
//    }


//}
