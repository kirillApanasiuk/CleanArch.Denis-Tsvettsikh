using Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IDbContext
    {
        DbSet<Order> Orders { get; }
        DbSet<Product> Products { get; }
        public DbSet<OrderItem> OrderItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }

}
