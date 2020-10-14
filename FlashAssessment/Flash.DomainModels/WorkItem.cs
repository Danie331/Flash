
namespace Flash.DomainModels
{
    public class WorkItem
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public int StoryPoints { get; set; }
        public int? UserId { get; set; }
        public WorkItemStatus Status { get; set; }
        public User User { get; set; }
    }
}
