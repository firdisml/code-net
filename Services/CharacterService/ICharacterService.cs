using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_net.Models;

namespace code_net.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAll();

        Task<ServiceResponse<Character>> GetUnique(int id);

        Task<ServiceResponse<Character>> AddCharacter(Character character);
    }
}