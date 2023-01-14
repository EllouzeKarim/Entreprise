using Entreprise.Models;

namespace Entreprise.Data.RStock
{
    public interface IStockRepository : IRepository<Stock>
    {
        public IEnumerable<Stock> GetStocks();

    }
}
