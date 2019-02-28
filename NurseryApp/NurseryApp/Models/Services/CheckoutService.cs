﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NurseryApp.Data;
using NurseryApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly NurseryDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckoutService(UserManager<ApplicationUser> userManager, NurseryDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task CreateCheckoutAsync(Checkout checkout)
        {
            _context.Checkouts.Add(checkout);
            await _context.SaveChangesAsync();
        }

        public async Task<Checkout> GetCheckoutByUserId(string userID)
        {
            return await _context.Checkouts.FirstOrDefaultAsync(c => c.UserID == userID);

        }

        public async Task UpdateCheckoutAsync(Checkout checkout)
        {
            _context.Checkouts.Update(checkout);
            await _context.SaveChangesAsync();
        }
    }
}
