
using System.Collections.Generic;

namespace Flash.DAL.Datacontext.Models
{
    class User
    {
        public User()
        {
            WorkItem = new HashSet<WorkItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
        public virtual ICollection<WorkItem> WorkItem { get; set; }
    }
}
