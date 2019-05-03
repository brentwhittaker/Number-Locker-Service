using OrderIn.Common.Exceptions;
using System;

namespace OrderIn.Services.Items.Domain.Models
{
    public class xItem
    {
        public Guid Id { get; protected set; }
        public string Item { get; protected set; }
        public string Status { get; protected set; }
        public int Count { get; protected set; }

        public void IncrementCount()
        {
            Count++;
        }

        protected xItem() { }
        public xItem(Guid id, string item, string status, int count)
        {
            if (string.IsNullOrEmpty(item))
            {
                throw new OrderInException("empty_item", $"Item cannot be empty.");
            }

            Id = id;
            Item = item;
            Status = status;
            Count = count;
        }
    }
}
