using System.Linq;
using WebApiTask.Data;
using WebApiTask.Models;
using WebApiTask.Repositories.Interfaces;

namespace WebApiTask.Repositories.Implementaions
{
    public class ColdDrinksRepository : IColdDrinks
    {
        private readonly ColdDrinksDBContext _context;
        public ColdDrinksRepository(ColdDrinksDBContext db)
        {
            _context = db;
        }

            //insert Cold Drink
        public int InsertColdDrink(ColdDrinks cold_drink)
        {
            if (cold_drink == null)
            {
                return 0;
            }

            _context.ColdDrinks.Add(cold_drink);
            _context.SaveChanges();
            return cold_drink.ColdDrinksId;
        }

            //update Unit Price
        public int UpdateUnitPrice(string name, decimal newUnitPrice)
        {
            var drink = _context.ColdDrinks.FirstOrDefault(d => d.strColdDrinksName == name);
            if (drink != null)
            {
                drink.numUnitPrice = newUnitPrice;
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }

            //delete Cold Drinks
        public int DeleteColdDrinkByName(string name)
        {
            var drink = _context.ColdDrinks.FirstOrDefault(d => d.strColdDrinksName == name);
            if (drink != null)
            {
                _context.ColdDrinks.Remove(drink);
                _context.SaveChanges();
                return 1; 
            }
            return 0;
        }

            //Get Remaining Products Name
        public IEnumerable<string> GetAllColdDrinkNames()
        {
            return _context.ColdDrinks.Select(d => d.strColdDrinksName).ToList();
        }

            //Delete products, If Quantity less than 
        public int DeleteColdDrinksByQuantity(int quantity)
        {
            var drinksToDelete = _context.ColdDrinks.Where(d => d.numQuantity < quantity).ToList();

            int deletedCount = 0;
            foreach (var drink in drinksToDelete)
            {
                _context.ColdDrinks.Remove(drink);
                deletedCount++;
            }
            _context.SaveChanges();
            
            return deletedCount;
        }

        //Total Price of All Products
        public decimal GetTotalPriceOfAllColdDrinks()
        {
            //return _context.ColdDrinks.Sum(d => d.numQuantity * d.numUnitPrice);
            var allProducts = _context.ColdDrinks.Select(d => d).ToList();
            int totalPrice = 0;

            foreach (var d in allProducts)
            {
                totalPrice += (d.numQuantity * d.numUnitPrice);
            }
            return totalPrice;
        }


        //byDefault
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
