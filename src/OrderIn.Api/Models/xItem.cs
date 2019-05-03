using System;

namespace OrderIn.Api.Models
{
    public class xItem
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
