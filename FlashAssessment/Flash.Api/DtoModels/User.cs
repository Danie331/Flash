
namespace Flash.Api.DtoModels
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public int TeamId { get; set; }
        public string TeamDescription { get; set; }
    }
}
