using System;
using Hawk_products_display.Service.Code;
using Hawk_products_display.Service.Domain.Interface;

namespace Hawk_products_display.Service.Domain
{
    public class PriceCalculator : IPriceCalculator
    {
        public decimal GetWithVat(decimal price)
        {
            decimal priceWithVat = price*DefaultValue.VAT;
            return priceWithVat;
        }
    }
}