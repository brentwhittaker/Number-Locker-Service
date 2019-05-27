using System;

namespace Micro.Common.Commands
{
    public class xItem : ICommand
    {
        public Guid Id { get; set; }
        public string Item { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
