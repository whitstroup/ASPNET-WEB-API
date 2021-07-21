using System;
using Microsoft.AspNetCore.Mvc;

namespace Mock_BestBuy_API
{
    public class Product
    {
        public Product()
        {
        }

        [BindProperty]
        public int ProductID { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public double Price { get; set; }

        [BindProperty]
        public int CategoryID { get; set; }

        [BindProperty]
        public int StockLevel { get; set; }

        [BindProperty]
        public bool OnSale { get; set; }



    }
}
