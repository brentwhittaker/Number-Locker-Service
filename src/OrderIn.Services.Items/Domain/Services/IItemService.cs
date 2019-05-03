﻿using OrderIn.Services.Items.Domain.Models;
using System;
using System.Threading.Tasks;

namespace OrderIn.Services.Items.Domain.Services
{
    public interface IItemService
    {
        Task AddAsync(Guid id, string item, string status, int count);
        Task<xItem> UpdateAsync(xItem item);
        Task<xItem> GetAsync(string item);
    }
}
