using WebApiTask.Models;

namespace WebApiTask.Repositories.Interfaces
{
    public interface IColdDrinks : IDisposable
    {
        int InsertColdDrinks(ColdDrinks cold_drinks); //done

        int UpdateUnitPrice(string name, decimal new_unit_price);

        int DeleteColdDrinkByName(string name);

        IEnumerable<string> GetAllColdDrinkNames();

        int DeleteColdDrinksByQuantity(int quantity);

        decimal GetTotalPriceOfAllColdDrinks();
    }
}
