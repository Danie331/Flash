using System.Collections.Generic;

namespace Flash.DAL.Datacontext.Models
{
    class WorkItemStatus
    {
        public WorkItemStatus()
        {
            WorkItem = new HashSet<WorkItem>();
        }

        public int Id { get; set; }
        public string StatusDescription { get; set; }

        public virtual ICollection<WorkItem> WorkItem { get; set; }
    }
}
