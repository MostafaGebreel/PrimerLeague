using PrimerLeague.Models;
using System.ComponentModel.DataAnnotations;

namespace PrimerLeague.DTOs
{
    public class TeamDTO
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; } 

        public string Stadium { get; set; } 

        public string City { get; set; }
        public List<PlayerProfileDto> players { get; set; } = new();
    }
}
