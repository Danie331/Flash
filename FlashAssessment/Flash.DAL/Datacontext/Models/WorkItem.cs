
namespace Flash.DAL.Datacontext.Models
{
    public partial class WorkItem
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public int StoryPoints { get; set; }
        public int StatusId { get; set; }
        public int? UserId { get; set; }

        public virtual WorkItemStatus Status { get; set; }
        public virtual User User { get; set; }
    }
}
