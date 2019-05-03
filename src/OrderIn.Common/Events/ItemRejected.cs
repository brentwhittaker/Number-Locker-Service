using System;

namespace OrderIn.Common.Events
{
    public class ItemRejected : IRejectedEvent
    {
        public Guid Id { get; set; }
        public string Reason { get; }
        public string Code { get; }

        protected ItemRejected() { }

        public ItemRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
