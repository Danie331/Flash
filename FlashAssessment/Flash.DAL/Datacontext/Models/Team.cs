
using System.Collections.Generic;

namespace Flash.DAL.Datacontext.Models
{
    class Team
    {
        public Team()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
