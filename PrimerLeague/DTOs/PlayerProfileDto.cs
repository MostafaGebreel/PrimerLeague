namespace PrimerLeague.DTOs
{
    public class PlayerProfileDto
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string BirthDay { get; set; }  
        public string Position { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public string PreferredFoot { get; set; }
        public int MarketValue { get; set; }
        public string? PlayerImage { get; set; }

        public string CountryName { get; set; }
        public string? TeamName { get; set; }
    }
}
