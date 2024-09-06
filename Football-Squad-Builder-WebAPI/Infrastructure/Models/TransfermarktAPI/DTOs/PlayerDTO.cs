namespace Infrastructure.Models.TransfermarktAPI.DTOs
{
    public class PlayerDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string DateOfBirth { get; set; }
        public string Age { get; set; }
        public string[] Nationality { get; set; }
        public string Height { get; set; }
        public string Foot { get; set; }
        public string SignedFrom { get; set; }
        public string Contract { get; set; }
        public string MarketValue { get; set; }
        public string JerseyNumber { get; set; }
        public string ImageURL { get; set; }
        public string GoalsThisSeason { get; set; } 
        public string AssistsThisSeason { get; set; } 





    }
}
