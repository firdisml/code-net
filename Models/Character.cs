using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace code_net.Models
{
    public class Character
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }  = "Axe";
        public int Hitpoints { get; set; } = 100;
        public int Strength{ get; set; } = 20;
        public int Agility { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public CharacterClass Class { get; set; } = CharacterClass.Strength;

    }
}