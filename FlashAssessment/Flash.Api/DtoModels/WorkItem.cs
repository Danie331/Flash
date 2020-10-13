
namespace Flash.Api.DtoModels
{
    public class WorkItem
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public int StoryPoints { get; set; }
        public int StatusId { get; set; }
        public int? UserId { get; set; }
    }
}
