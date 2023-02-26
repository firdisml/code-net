using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using code_net.Data;
using code_net.DataTransferObjects.Character;
using code_net.Models;
using Microsoft.EntityFrameworkCore;

namespace code_net.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private readonly IMapper mapper;
        private readonly DataContext context;
        public CharacterService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }   

        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 1, Name = "Earthshaker"}
        };

        public async Task<ServiceResponse<GetCharacterDTO>> AddCharacter(AddCharacterDTO character)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            context.Characters.Add(mapper.Map<Character>(character));
            serviceResponse.Data = mapper.Map<GetCharacterDTO>(character);
            context.SaveChanges();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            var db_characters = await context.Characters.ToListAsync();
            serviceResponse.Data = db_characters.Select(c => mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetUnique(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            var character = characters.FirstOrDefault(c => c.Id == id);

            serviceResponse.Data = mapper.Map<GetCharacterDTO>(character);

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO update)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            try
            {

                var character = characters.FirstOrDefault(c => c.Id == update.Id);
                
                if(character is null)
                {
                    throw new Exception($"Character not found");
                }

                var map = mapper.Map(update, character);

                serviceResponse.Data = mapper.Map<GetCharacterDTO>(map);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;                
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<GetCharacterDTO>> DeleteCharacter(DeleteCharacterDTO delete)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            try
            {

                var character = characters.FirstOrDefault(c => c.Id == delete.Id);
                
                if(character is null)
                {
                    throw new Exception($"Character not found");
                }

                characters.Remove(character);

                serviceResponse.Data = mapper.Map<GetCharacterDTO>(character);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;                
            }

            return serviceResponse;
        }
    }
}