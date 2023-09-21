using System.Web.Http;
using WebMap.Service;

namespace WebMap.Controllers.Api
{
  
    public class HomeController : ApiController
    {
        [Route("api/getlocations")]
        public IHttpActionResult GetLocations(string path)
        {
            LocationService service = new LocationService();
            var locations = service.FetchLocationsFromCsv(path);
            return Ok(locations);
        }


    }
}
