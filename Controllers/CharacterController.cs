using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_net.DataTransferObjects.Character;
using code_net.Models;
using code_net.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace code_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService service;
        public CharacterController(ICharacterService service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> GetAll()
        {
            return Ok(await service.GetAll());
        }

        [HttpGet]
        [Route("GetUnique/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetUnique(int id)
        {
            return Ok(await service.GetUnique(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AddCharacterDTO>>> AddCharacter(AddCharacterDTO character)
        {
            return Ok(await service.AddCharacter(character));
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO character)
        {
            var response = await service.UpdateCharacter(character);

            if (response.Data is null) 
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> DeleteCharacter(DeleteCharacterDTO character)
        {
            var response = await service.DeleteCharacter(character);

            if (response.Data is null) 
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}