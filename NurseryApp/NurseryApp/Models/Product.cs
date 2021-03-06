﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class Product
    {
        //properties
        public int ID { get; set; }
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter positive number.")]
        public int Quantity { get; set; }
        public PlantType Type { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public string Sku { get; set; }
        public bool Bulk { get; set; }

        public enum PlantType { Tree, Shrub, Flower, Houseplant };
    }
}
