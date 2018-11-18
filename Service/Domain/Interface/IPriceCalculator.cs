namespace Hawk_products_display.Service.Domain.Interface
{
    public interface IPriceCalculator
    {
         decimal GetWithVat(decimal price);
    }
}