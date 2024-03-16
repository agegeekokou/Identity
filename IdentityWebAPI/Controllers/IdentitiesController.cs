using IdentityWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentitiesController : ControllerBase
    {
        private readonly IIdentityService service;
        public IdentitiesController(IIdentityService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAllIdentities()
        {
            var result = service.GetAllIdentities();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetIdentityById(int id)
        {
            var result = service.GetIdentityById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateIdentity(Models.DTO.AddIdentityRequest addIdentityRequest)
        {
            //Request (DTO) to domain model
            var identity = new Models.Domain.Identity()
            {
                Name = addIdentityRequest.Name,
                Age = addIdentityRequest.Age,
                City = addIdentityRequest.City,
                ImageId = addIdentityRequest.ImageId,
                Image = addIdentityRequest.Image
            };

            //Pass details to service
            identity = service.CreateIdentity(identity);

            //Convert back to DTO
            var identityDTO = new Models.DTO.Identity()
            {
                Id = identity.Id,
                Name = identity.Name,
                Age = identity.Age,
                City=identity.City,
                ImageId = identity.ImageId,
                Image = identity.Image
            };

            return CreatedAtAction(nameof(GetIdentityById), new { id = identityDTO.Id }, identityDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateIdentity([FromRoute] int id, [FromBody] Models.DTO.UpdateIdentityRequest updateIdentityRequest)
        {
            //Convert DTO to Domain model
            var identity = new Models.Domain.Identity()
            {
                Name = updateIdentityRequest.Name,
                Age = updateIdentityRequest.Age,
                City = updateIdentityRequest.City,
                ImageId = updateIdentityRequest.ImageId,
                Image = updateIdentityRequest.Image
            };

            //Update Identity using service
            identity = service.UpdateIdentity(id, identity);

            if(identity == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO
            var identityDTO = new Models.DTO.Identity()
            {
                Id = identity.Id,
                Name = identity.Name,
                Age = identity.Age,
                City = identity.City,
                ImageId= identity.ImageId,
                Image = identity.Image
            };

            return Ok(identityDTO);
        }

        [HttpDelete]
        public IActionResult DeleteIdentity(int id)
        {
            var identity = service.DeleteIdentity(id);

            if(identity == null)
            {
                return NotFound();
            }

            //Convert response back to DTO
            var identityDTO = new Models.DTO.Identity()
            {
                Id = identity.Id,
                Name = identity.Name,
                Age = identity.Age,
                City = identity.City,
                ImageId = identity.ImageId,
                Image = identity.Image
            };

            return Ok(identityDTO);
        }
    }
}
