namespace Hawk_products_display.Service.Domain
{
    public interface IPriceCalculator
    {
         decimal GetWithVat(decimal price);
    }
}