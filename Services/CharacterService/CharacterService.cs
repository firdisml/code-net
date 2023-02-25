using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_net.Models;

namespace code_net.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 1, Name = "Earthshaker"}
        };

        public async Task<ServiceResponse<Character>> AddCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<Character>();
            characters.Add(character);
            serviceResponse.Data = character;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetUnique(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();

            var character = characters.FirstOrDefault(c => c.Id == id);

            serviceResponse.Data = character;

            return serviceResponse;

        }
    }
}