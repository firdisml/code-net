using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_net.DataTransferObjects.Character;
using code_net.Models;

namespace code_net.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAll();

        Task<ServiceResponse<GetCharacterDTO>> GetUnique(int id);

        Task<ServiceResponse<GetCharacterDTO>> AddCharacter(AddCharacterDTO character);
    }
}