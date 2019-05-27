using System;

namespace Micro.Common.Events
{
    public class ItemStatusUpdated2 : IEvent
    {
        public Guid Id { get; }
        public string Item { get; }
        public string Status { get; }
        public int Count { get; }

        protected ItemStatusUpdated2() { }
        public ItemStatusUpdated2(Guid id, string item, string status, int count)
        {
            Id = id;
            Item = item;
            Status = status;
            Count = count;
        }
    }
}
