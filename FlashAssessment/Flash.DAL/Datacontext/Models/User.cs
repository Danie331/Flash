
using ProtoBuf;

namespace Flash.DAL.Datacontext.Models
{
    [ProtoContract]
    public class User
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
    }
}
