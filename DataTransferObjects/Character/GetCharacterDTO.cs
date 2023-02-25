using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using code_net.Models;

namespace code_net.DataTransferObjects.Character
{
    public class GetCharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Axe";
        public int Hitpoints { get; set; } = 100;
        public int Strength { get; set; } = 20;
        public int Agility { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public CharacterClass Class { get; set; } = CharacterClass.Strength;
    }
}