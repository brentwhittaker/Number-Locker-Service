using System;

namespace Micro.Common.Events
{
    public class ItemCreated2 : IEvent
    {
        public Guid Id { get; }
        public string Item { get; }
        public string Status { get; }
        public int Count { get; }

        protected ItemCreated2() { }
        public ItemCreated2(Guid id, string item, string status, int count)
        {
            Id = id;
            Item = item;
            Status = status;
            Count = count;
        }
    }
}
