using Micro.Common.Exceptions;
using System;

namespace Micro.Services.Worker.Domain.Models
{
    public class xItem
    {
        public Guid Id { get; protected set; }
        public string Item { get; protected set; }
        public string Status { get; protected set; }
        public int Count { get; protected set; }

        public void UpdateStatus(string status)
        {
            Status = status;
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
