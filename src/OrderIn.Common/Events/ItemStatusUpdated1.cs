using System;
using System.Collections.Generic;
using System.Text;

namespace OrderIn.Common.Events
{
    public class ItemStatusUpdated1 : IEvent
    {
        public Guid Id { get; }
        public string Item { get; }
        public string Status { get; }
        public int Count { get; }

        protected ItemStatusUpdated1() { }
        public ItemStatusUpdated1(Guid id, string item, string status, int count)
        {
            Id = id;
            Item = item;
            Status = status;
            Count = count;
        }
    }
}
