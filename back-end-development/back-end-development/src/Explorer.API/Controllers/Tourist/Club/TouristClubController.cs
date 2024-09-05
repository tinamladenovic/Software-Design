using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Club;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace Explorer.API.Controllers.Tourist.Club
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/club/touristclub")]
    public class TouristClubController : BaseApiController
    {
        
        private readonly ITouristClubService _touristClubService;

        public TouristClubController(ITouristClubService touristClubService)
        {
            _touristClubService = touristClubService;
        }
        
        [HttpGet]
        public ActionResult<PagedResult<TouristClubDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize) 
        {
            var result = _touristClubService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult<TouristClubDto> Get(int id)
        {
            var result = _touristClubService.Get(id);
            return CreateResponse(result);
        }
        [HttpGet("OwnerClubs/{id:int}")]
        public ActionResult<List<TouristClubDto>> GetOwnerClubs(int id)
        {
            var result = _touristClubService.GetClubsForOwner(id);
            return CreateResponse(result);
        }

        [HttpPost("{id:int}"), DisableRequestSizeLimit]
        public ActionResult<TouristClubDto> Create(int id, [FromForm] TouristClubDto club, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null)
                {
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (imageFile.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(imageFile.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        // Save the image file to the server
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            imageFile.CopyTo(stream);
                        }

                        club.Image = fileName; // Store the image path in the database
                    }
                }
                else
                {
                    return BadRequest("No image uploaded.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            club.OwnerId = id;
            var result = _touristClubService.Create(club);
            return CreateResponse(result);
        }

        [HttpPost()]
        public ActionResult<TouristClubDto> Create([FromBody] TouristClubDto club)
        {
            var result = _touristClubService.Create(club);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<TouristClubDto> Update([FromBody] TouristClubDto club)
        {
            var result = _touristClubService.Update(club);
            return CreateResponse(result);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _touristClubService.Delete(id);
            return CreateResponse(result);
        }
    }
}
