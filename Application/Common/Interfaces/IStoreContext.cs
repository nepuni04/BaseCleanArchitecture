using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Entities.PurchaseAggregate;
using Core.Entities.SaleAggregate;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IStoreContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Supplier> Suppliers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
