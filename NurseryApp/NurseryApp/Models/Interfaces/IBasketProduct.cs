﻿using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models.Interfaces
{
    public interface IBasketProduct
    {

        Task AddBasketProduct(int id, int quantity, string userID);

        Task<List<BasketProductViewModel>> GetBasket(string userID);

        Task<BasketProduct> GetBasketProductByID(string userID, int productID);

        Task UpdateQuantity(BasketProduct basketProduct);

        Task DeleteBasketProductByID(string userID, int productID);
    }
}
