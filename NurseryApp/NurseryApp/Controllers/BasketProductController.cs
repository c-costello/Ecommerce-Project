﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NurseryApp.Data;
using NurseryApp.Models;
using NurseryApp.Models.Interfaces;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Controllers
{
    public class BasketProductController : Controller
    {
        private readonly IBasketProduct _context;


        public BasketProductController(IBasketProduct context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userID = User.Claims.First(name => name.Type == "id").Value;

            var products = await _context.GetBasket(userID);

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity)
        {
            string userID = User.Claims.First(name => name.Type == "id").Value;

            await _context.AddBasketProduct(id, quantity, userID);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, int quantity)
        {
            string userID = User.Claims.First(name => name.Type == "id").Value;
            
            BasketProduct basketProduct = await _context.GetBasketProductByID(userID, id);
            basketProduct.Quantity = quantity;
            await _context.UpdateQuantity(basketProduct);
            return RedirectToAction("Index", "BasketProduct");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            string userID = User.Claims.First(name => name.Type == "id").Value;

            await _context.DeleteBasketProductByID(userID, id);
            return RedirectToAction("Index", "BasketProduct");
        }
    }
}
