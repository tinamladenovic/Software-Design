using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Net.Http.Headers;
using System.Net.WebSockets;

namespace Explorer.API.Controllers
{
    //[Authorize(Policy = "touristAndAuthorPolicy")]
    [Route("api/person")]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;


        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        //[Authorize(Policy = "touristAndAdminPolicy")]
        [HttpGet("{id:int}")]
        public ActionResult<UpdatePersonDTO> Get(int id) 
        {
            var result = _personService.GetByUserId(id);
            return CreateResponse(result);
        }

        [Authorize(Policy = "touristAndAuthorPolicy")]
        [HttpPut("updateLocation")]
        public ActionResult<UpdatePersonDTO> UpdateLocation([FromBody] UpdatePersonDTO person)
        {
            var result = _personService.UpdatePerson(person, User.PersonId());
            return CreateResponse(result);
        }



        [HttpPut,DisableRequestSizeLimit]
        public ActionResult<UpdatePersonDTO>Update([FromForm] UpdatePersonDTO person,IFormFile image)
        {
            
            try
            {
                if(image != null)
                {
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    EnsureRepositoryFolderExists(pathToSave);

                    if (image.Length> 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            image.CopyTo(stream);
                        }

                        person.Image = fileName;

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

            var result = _personService.UpdatePerson(person, User.PersonId());
            return CreateResponse(result);
        }



        private void EnsureRepositoryFolderExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
