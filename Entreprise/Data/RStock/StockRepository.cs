

using Entreprise.Models;
using Microsoft.EntityFrameworkCore;

namespace Entreprise.Data.RStock
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        private readonly ProjectContext context;
        public StockRepository()
        {
            this.context = ProjectContext.Instance(); ;
        }
        public IEnumerable<Stock> GetStocks()
        {
            return this.context.Stock.ToList();
        }
    
    }
}
