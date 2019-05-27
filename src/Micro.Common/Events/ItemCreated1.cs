using System;

namespace Micro.Common.Events
{
    public class ItemCreated1 : IEvent
    {
        public Guid Id { get; }
        public string Item { get; }
        public string Status { get; }
        public int Count { get; }

        protected ItemCreated1() { }
        public ItemCreated1(Guid id, string item, string status, int count)
        {
            Id = id;
            Item = item;
            Status = status;
            Count = count;
        }
    }
}
