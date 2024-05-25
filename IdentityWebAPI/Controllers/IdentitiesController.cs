using IdentityWebAPI.CustomActionFilters;
using IdentityWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace IdentityWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentitiesController : ControllerBase
    {
        private readonly IIdentityService service;
        private readonly ILogger<IdentitiesController> logger;
        public IdentitiesController(IIdentityService service, ILogger<IdentitiesController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader,Writer")]
        public IActionResult GetAllIdentities([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            //logger.LogTrace("This is a Trace log, the most detailed information.");
            //logger.LogDebug("This is a Debug log, useful for debugging.");           
            logger.LogInformation("GetAllIdentities action method was invoked");
            //logger.LogWarning("This is a Warning log, indicating a potential issue.");
            //logger.LogError("This is an Error log, indicating a failure in the current operation.");
            //logger.LogCritical("This is a Critical log, indicating a serious failure in the application.");

            var results = service.GetAllIdentities(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            logger.LogInformation($"Finished GetAllIdentities request with data: {JsonSerializer.Serialize(results)}");

            return Ok(results);
        }

        [HttpGet]
        [Route("{id:int}")]
        //[Authorize(Roles = "Reader,Writer")]
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
        //[Authorize(Roles = "Writer")]
        [ValidateModel]
        public IActionResult CreateIdentity(Models.DTO.AddIdentityRequestDto addIdentityRequestDto)
        {
            //Request (DTO) to domain model
            var identity = new Models.Domain.Identity()
            {
                Name = addIdentityRequestDto.Name,
                Age = addIdentityRequestDto.Age,
                City = addIdentityRequestDto.City,
                ImageId = addIdentityRequestDto.ImageId,
                Image = addIdentityRequestDto.Image
            };

            //Pass details to service
            identity = service.CreateIdentity(identity);

            //Convert back to DTO
            var identityDTO = new Models.DTO.IdentityDto()
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
        //[Authorize(Roles = "Writer")]
        [ValidateModel]
        public IActionResult UpdateIdentity([FromRoute] int id, [FromBody] Models.DTO.UpdateIdentityRequestDto updateIdentityRequestDto)
        {
            //Convert DTO to Domain model
            var identity = new Models.Domain.Identity()
            {
                Name = updateIdentityRequestDto.Name,
                Age = updateIdentityRequestDto.Age,
                City = updateIdentityRequestDto.City,
                ImageId = updateIdentityRequestDto.ImageId,
                Image = updateIdentityRequestDto.Image
            };

            //Update Identity using service
            identity = service.UpdateIdentity(id, identity);

            if(identity == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO
            var identityDTO = new Models.DTO.IdentityDto()
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
        //[Authorize(Roles = "Writer")] 
        public IActionResult DeleteIdentity(int id)
        {
            var identity = service.DeleteIdentity(id);

            if(identity == null)
            {
                return NotFound();
            }

            //Convert response back to DTO
            var identityDTO = new Models.DTO.IdentityDto()
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
