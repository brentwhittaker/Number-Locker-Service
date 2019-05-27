using System;

namespace Micro.Common.Events
{
    public class ItemCountUpdated : IEvent
    {
        public Guid Id { get; }
        public string Item { get; }
        public string Status { get; }
        public int Count { get; }

        protected ItemCountUpdated() { }
        public ItemCountUpdated(Guid id, string item, string status, int count)
        {
            Id = id;
            Item = item;
            Status = status;
            Count = count;
        }
    }
}
