using System;

namespace LinkUp.Domain
{
    public class PersonalChat
    {
        public Guid Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public DateTime CreateTime { get;set; }
    }
}
