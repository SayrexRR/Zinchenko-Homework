﻿using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Controlls
{
    public class DbController
    {
        public static string GetProductSales(string productName, int month)
        {
            using (var context = new TestContext())
            {
                var productSales = from order in context.Orders
                                   join orderPosition in context.OrderPositions on order.Id equals orderPosition.OrderId
                                   join product in context.Products on orderPosition.ProductId equals product.Id
                                   where product.Name == productName && order.Date.Month == month
                                   select new { Qty = orderPosition.Qty, Total = orderPosition.Qty * product.Price };

                var totalQty = productSales.Sum(p => p.Qty);
                var totalSum = productSales.Sum(p => p.Total);

                return $"Product: {productName}, Qountity: {totalQty}, Total Price: {totalSum:C}";
            }
        }
    }
}
