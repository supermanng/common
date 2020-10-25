using System.Threading;
using System.Threading.Tasks;

namespace Etechnosoft.Common.Infrastructure
{
    public interface IDataContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}